using System;

namespace Mediator.Interfaces
{
    public interface ICommand{}
    
    public interface IQuery<TResult>
    {
    }
    
	public interface IMediatorResolver
    {
        object Resolve(Type contractType);
        void SetModuleResolver(object moduleResolver);
    }
    
    public interface IMediator
    {
        TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        IObservable<TCommand> Subscribe<TCommand>();
    }
    
    // Interfaces for Command and Query Handlers
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }

    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery query);
    }
    
    public interface IEventPublisher
    {
        /// <summary>
        /// Send Message to all receiver.
        /// </summary>
        void Publish<T>(T message);
    }

    public interface IEventReceiver
    {
        /// <summary>
        /// Subscribe typed message.
        /// </summary>
        IObservable<T> Receive<T>();
    }

    public interface IEventBroker : IEventPublisher, IEventReceiver
    {
    }
}