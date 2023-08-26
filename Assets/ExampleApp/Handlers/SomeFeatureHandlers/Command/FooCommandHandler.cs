using ExampleApp.DataAccess;
using Mediator.Interfaces;

namespace ExampleApp.Operations.Command
{
    public class FooCommandHandler : ICommandHandler<FooCommand>
    {
        private readonly Storage _storage;

        public FooCommandHandler(Storage storage)
        {
            _storage = storage;
        }
            
        public void Handle(FooCommand command)
        {
            _storage.Dictionary[command.Num] = command.Flag;
        }
    }
}