using EventsProject.Commons.Exceptions;
using EventsProject.Models;
using FluentValidation;
using MediatR;

namespace EventsProject.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IDataBase dataBase;
        private readonly IValidator<UpdateEventCommand> validator;

        public UpdateEventCommandHandler(IDataBase dataBase, IValidator<UpdateEventCommand> validator)
        {
            this.dataBase = dataBase;
            this.validator = validator;
        }
        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = dataBase.EventRepository.Find(request.Id);
            if (@event == null)
                throw new NotFoundException();

            try
            {
                validator.ValidateAndThrow(request);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            @event.Name = request.Name;
            @event.Description = request.Description;
            @event.DateStart = request.DateStart;
            @event.DateEnd = request.DateEnd;
            @event.PictureId = request.PictureId;
            @event.PlaceId = request.PlaceId;
            await Task.CompletedTask;
        }
    }
}
