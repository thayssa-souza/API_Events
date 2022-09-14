using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
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

        [HttpGet("bucar-reservas")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EventReservation> GetReservationList()
        {
            var eventReservation = _eventReservationService.GetReservationList();
            ActionResult<EventReservation> events = eventReservation != null ? Ok(eventReservation) : BadRequest();
            return events;
        }

        [HttpPost("adicionar-nova-reserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EventReservation> InsertReservation(long idEvent, EventReservation newEventReservation)
        {
            ActionResult<EventReservation> events = (!_eventReservationService.InsertReservation(newEventReservation)) ? BadRequest() : Ok(newEventReservation);
            return events;
        }

        [HttpPut("alterar-quantidade-reserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EventReservation> UpdateQuantityReservation(long idReservation, EventReservation eventReservation)
        {
            ActionResult<EventReservation> events = (!_eventReservationService.UpdateQuantityReservation(idReservation, eventReservation)) ? BadRequest() : Ok(eventReservation);
            return events;
        }

        [HttpDelete("deletar-reserva")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EventReservation> DeleteReservation(long idReservation)
        {
            ActionResult<EventReservation> events = (!_eventReservationService.DeleteReservation(idReservation)) ? BadRequest() : Ok();
            return events;
        }
    }
}
