using Mediator.Interfaces;

namespace ExampleApp.Operations.Command
{
    public class FooCommand : ICommand
    {
        public int Num { get; }
        public bool Flag { get; }

        public FooCommand(int num, bool flag)
        {
            Num = num;
            Flag = flag;
        }
    }
}