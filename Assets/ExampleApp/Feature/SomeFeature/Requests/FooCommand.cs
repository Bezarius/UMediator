namespace ExampleApp.Operations.Command
{
    public class FooCommand
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