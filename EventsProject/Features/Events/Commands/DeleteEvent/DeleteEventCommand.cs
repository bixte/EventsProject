using MediatR;

namespace EventsProject.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand :IRequest
    {
        public Guid Id { get; set; }
    }
}
