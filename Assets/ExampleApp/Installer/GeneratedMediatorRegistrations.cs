 // *** GENERATED ***
using VContainer;

namespace ExampleApp.Operations
{
    public static class VContainerCustomMediatorRegistration
    {
        public static void RegisterMediatorHandlers(this IContainerBuilder builder)
        {
           builder
              .Register<ExampleApp.Operations.Command.FooCommandHandler>(Lifetime.Transient)
              .As(typeof(Mediator.Interfaces.ICommandHandler<ExampleApp.Operations.Command.FooCommand>));

        }
    }
}
