using AutoMapper;
using EventsProject.Features.Events.Queries.DTO;
using EventsProject.Models.Data;

namespace EventsProject.Commons.AutoMapping
{
    public static class Mapps
    {
        public static IMapperConfigurationExpression Create(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<Event, EventDTO>();
            return mapperConfigurationExpression;
        }
    }
}
