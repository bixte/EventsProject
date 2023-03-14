using EventsProject.Commons.Exceptions;
using EventsProject.Models;
using FluentValidation;
using MediatR;

namespace EventsProject.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IDataBase dataBase;
        private readonly IValidator<DeleteEventCommand> validator;

        public DeleteEventCommandHandler(IDataBase dataBase, IValidator<DeleteEventCommand> validator)
        {
            this.dataBase = dataBase;
            this.validator = validator;
        }
        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                validator.ValidateAndThrow(request);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            var @event = dataBase.EventRepository.Find(request.Id);
            if (@event == null)
                throw new NotFoundException();

            dataBase.EventRepository.Remove(@event);
        }
    }
}
