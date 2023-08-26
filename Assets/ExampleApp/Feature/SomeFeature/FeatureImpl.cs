using System;
using ExampleApp.Feature.SomeFeature.Requests;
using ExampleApp.Operations.Command;
using Mediator.Interfaces;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace ExampleApp.Feature.SomeFeature
{
    public class FeatureImpl : IInitializable, IDisposable
    {
        private readonly IMediator _mediator;
        private readonly SingleAssignmentDisposable _disposable = new();

        public FeatureImpl(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Initialize()
        {
            _disposable.Disposable =
                _mediator
                    .Subscribe<FooCommand>()
                    .Subscribe(cmd =>
                    {
                        if(cmd.Flag)
                            Debug.Log($"FooCommand: {cmd.Num}");
                    });
        
            var isEven = _mediator.Query<IsEvenQuery, bool>(new(42));
            if (isEven)
            {
                _mediator.Send(new FooCommand(42, true));
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
