using AutoMapper;
using EventsProject.Features.Events.Queries.DTO;
using EventsProject.Models;
using EventsProject.Models.Data;
using MediatR;

namespace EventsProject.Features.Events.Queries.GetEvents
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, EventsListVM>
    {
        private readonly IDataBase dataBase;
        private readonly IMapper mapper;

        public GetEventsQueryHandler(IDataBase dataBase, IMapper mapper)
        {
            this.dataBase = dataBase;
            this.mapper = mapper;
        }
        public Task<EventsListVM> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = dataBase.EventRepository.Entities;
            var eventDTO = mapper.Map<IList<Event>, List<EventDTO>>(events);
            return Task.FromResult(new EventsListVM() { Events = eventDTO });
        }
    }
}
