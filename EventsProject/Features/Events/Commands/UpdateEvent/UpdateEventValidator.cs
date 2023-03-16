using EventsProject.Models;
using FluentValidation;

namespace EventsProject.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventValidator:AbstractValidator<UpdateEventCommand>
    {
        private readonly IDataBase dataBase;

        public UpdateEventValidator(IDataBase dataBase)
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e=>e.Description).NotEmpty();
            RuleFor(e=>e.DateStart).NotEmpty().LessThan(e=>e.DateEnd);
            RuleFor(e=>e.DateEnd).NotEmpty().GreaterThan(e=>e.DateStart);
            RuleFor(e => e.PictureId).NotNull().Must(BeInPictureRepository);
            RuleFor(e => e.PlaceId).NotNull().Must(BeInPlaceRepository);
            this.dataBase = dataBase;
        }
        private bool BeInPictureRepository(Guid id)
        {
            return dataBase.PictureRepository.Find(id) != null;
        }
        private bool BeInPlaceRepository(Guid id)
        {
            return dataBase.PlaceRepository.Find(id) != null;
        }
    }
}
