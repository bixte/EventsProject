using EventsProject.Features.Events.Queries.DTO;

namespace EventsProject.Features.Events.Queries.GetEvents
{
    public class EventsListVM
    {
        public IList<EventDTO> Events { get; set; } = null!;
    }
}
