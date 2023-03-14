using AutoMapper;
using EventsProject.Commons.Exceptions;
using EventsProject.Features.Events.Queries.DTO;
using EventsProject.Models;
using EventsProject.Models.Data;
using MediatR;

namespace EventsProject.Features.Events.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventDTO>
    {
        private readonly IDataBase dataBase;
        private readonly IMapper mapper;

        public GetEventQueryHandler(IDataBase dataBase, IMapper mapper)
        {
            this.dataBase = dataBase;
            this.mapper = mapper;
        }
        public async Task<EventDTO> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var @event = dataBase.EventRepository.Find(request.Id);
            if (@event is null)
                throw new NotFoundException();
            var eventDTO = mapper.Map<Event, EventDTO>(@event);
            return await Task.FromResult(eventDTO);
        }
    }
}
