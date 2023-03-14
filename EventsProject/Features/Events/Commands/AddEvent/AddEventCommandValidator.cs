﻿using EventsProject.Models;
using FluentValidation;

namespace EventsProject.Features.Events.Commands.AddEvent
{
    public class AddEventCommandValidator :AbstractValidator<AddEventCommand>
    {
        public AddEventCommandValidator(IDataBase dataBase)
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Description).NotEmpty();
            RuleFor(e => e.DateStart).NotEmpty().LessThan(e => e.DateEnd);
            RuleFor(e => e.DateEnd).NotEmpty().GreaterThan(e => e.DateStart);
            RuleFor(e => e.PictureId).NotNull().Must(id => dataBase.PictureRepository.Find(id) != null);
            RuleFor(e => e.PlaceId).NotNull().Must(id => dataBase.PlaceRepository.Find(id) != null);
        }
    }
}
