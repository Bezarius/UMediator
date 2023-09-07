using ExampleApp.Feature.SomeFeature.Requests;
using Mediator.Interfaces;

public class IsEvenQueryHandler : IQueryHandler<IsEvenQuery, bool>
{
    public bool Handle(IsEvenQuery query)
    {
        return query.Num % 2 == 0;
    }
}