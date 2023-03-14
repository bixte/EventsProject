using EventsProject.Commons.Exceptions;
using EventsProject.Models;
using EventsProject.Models.Data;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventsProject.Features.Events.Commands.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand>
    {
        private readonly IDataBase dataBase;
        private readonly IValidator<AddEventCommand> validator;

        public AddEventCommandHandler(IDataBase dataBase, IValidator<AddEventCommand> validator)
        {
            this.dataBase = dataBase;
            this.validator = validator;
        }
        public async Task Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                validator.ValidateAndThrow(request);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            dataBase.EventRepository.Add(new Event()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                DateEnd = request.DateEnd,
                DateStart = request.DateStart,
                PictureId = request.PictureId,
                PlaceId = request.PlaceId,
            });
        }
    }
}
