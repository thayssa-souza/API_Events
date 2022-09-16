using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
using API_Events.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API_Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        public IEventReservationService _eventReservationService;
        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }

        [HttpGet("consultar/reservas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventReservation>>> GetReservationList()
        {
            return Ok(await _eventReservationService.GetReservationList());
        }

        [HttpGet("buscar/reserva/{idReservation}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidateExistReservationActionFilter))]
        public async Task<ActionResult<EventReservation>> GetReservationById(long idReservation)
        {
            return Ok(await _eventReservationService.GetReservationById(idReservation));
        }


        [HttpGet("buscar/reserva/evento/pessoa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventReservation>>> GetReservationEventByPerson(string title, string personName)
        {
            return Ok(await _eventReservationService.GetReservationEventByPerson(title, personName));
        }

        [HttpPost("adicionar/reserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public async Task<ActionResult<EventReservation>> InsertReservation(long idEvent, string personName, long quantity)
        {
            ActionResult<EventReservation> events = (!await _eventReservationService.InsertReservation(idEvent, personName, quantity)) ? 
                BadRequest() : Ok();
            return events;
        }

        [HttpPut("alterar/reserva/{idReservation}/{quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidateExistReservationActionFilter))]
        public async Task<ActionResult<EventReservation>> UpdateQuantityReservation(long idReservation, long quantity)
        {
            ActionResult<EventReservation> events = (!await _eventReservationService.UpdateQuantityReservation(idReservation, quantity)) ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok();
            return events;
        }

        [HttpDelete("deletar/reserva/{idReservation}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EventReservation>> DeleteReservation(long idReservation)
        {
            ActionResult<EventReservation> events = (!await _eventReservationService.DeleteReservation(idReservation)) ?
                BadRequest() : Ok();
            return events;
        }
    }
}
