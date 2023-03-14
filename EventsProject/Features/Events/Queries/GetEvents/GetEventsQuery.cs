using MediatR;

namespace EventsProject.Features.Events.Queries.GetEvents
{
    public class GetEventsQuery : IRequest<EventsListVM>
    {
    }
}
