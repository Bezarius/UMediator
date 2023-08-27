using Mediator.Interfaces;

namespace ExampleApp.Feature.SomeFeature.Requests
{
    public class IsEvenQuery : IQuery<bool>
    {
        public readonly int Num;

        public IsEvenQuery(int num)
        {
            Num = num;
        }
    }
}