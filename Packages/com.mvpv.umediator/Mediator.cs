using System;
using Mediator.Interfaces;

namespace Mediator.Impl
{
    public class Mediator : IMediator
    {
        private readonly IMediatorResolver _resolver;
        
        private readonly IEventBroker _eventBroker;

        public Mediator(IMediatorResolver resolver, IEventBroker eventBroker)
        {
            _resolver = resolver;
            _eventBroker = eventBroker;
        }
        
        public TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _resolver.Resolve(typeof(IQueryHandler<TQuery, TResult>));
            return ((IQueryHandler<TQuery, TResult>)handler).Handle(query);
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _resolver.Resolve(typeof(ICommandHandler<TCommand>));
            ((ICommandHandler<TCommand>)handler).Handle(command);
            _eventBroker.Publish(command);
        }

        public IObservable<TCommand> Subscribe<TCommand>()
        {
            return _eventBroker.Receive<TCommand>();
        }
    }
}