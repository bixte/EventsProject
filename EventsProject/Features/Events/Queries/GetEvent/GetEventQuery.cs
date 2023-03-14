using EventsProject.Features.Events.Queries.DTO;
using MediatR;

namespace EventsProject.Features.Events.Queries.GetEvent
{
    public class GetEventQuery : IRequest<EventDTO>
    {
        public Guid Id { get; set; }
    }
}
