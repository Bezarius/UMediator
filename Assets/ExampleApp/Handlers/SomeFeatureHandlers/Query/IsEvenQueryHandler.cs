using ExampleApp.Feature.SomeFeature.Requests;
using Mediator.Interfaces;

public class IsEvenQueryHandler : IQueryHandler<IsEvenQuery, int>
{
    public int Handle(IsEvenQuery query)
    {
        return query.Num % 2;
    }
}