namespace ExampleApp.Feature.SomeFeature.Requests
{
    public class IsEvenQuery
    {
        public readonly int Num;

        public IsEvenQuery(int num)
        {
            Num = num;
        }
    }
}