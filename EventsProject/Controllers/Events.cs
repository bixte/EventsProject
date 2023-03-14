using EventsProject.Features.Events.Commands.AddEvent;
using EventsProject.Features.Events.Commands.DeleteEvent;
using EventsProject.Features.Events.Commands.UpdateEvent;
using EventsProject.Features.Events.Queries.DTO;
using EventsProject.Features.Events.Queries.GetEvent;
using EventsProject.Features.Events.Queries.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventsProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Events : ControllerBase
    {
        private readonly IMediator mediator;
        public Events(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetEventsQuery();
            var responce = await mediator.Send(query);
            return Ok(responce);
        }
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetEventQuery();
            EventDTO responce;
            query.Id = id;
            try
            {
                responce = await mediator.Send(query);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(responce);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddEventCommand addEventCommand)
        {
            try
            {
                await mediator.Send(addEventCommand);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            try
            {
                await mediator.Send(updateEventCommand);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteEventCommand();
            command.Id = id;
            try
            {
                await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
