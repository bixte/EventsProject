using FluentValidation;

namespace EventsProject.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(e=>e.Id).NotEmpty();
        }
    }
}
