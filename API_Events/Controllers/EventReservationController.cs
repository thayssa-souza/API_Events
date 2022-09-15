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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EventReservation> GetReservationList()
        {
            var eventReservation = _eventReservationService.GetReservationList();
            ActionResult<EventReservation> events = eventReservation != null ? Ok(eventReservation) : BadRequest();
            return events;
        }

        [HttpGet("buscar/reserva/evento/pessoa")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EventReservation> GetReservationEventByPerson(string title, string personName)
        {
            var eventReservation = _eventReservationService.GetReservationEventByPerson(title, personName);
            ActionResult<EventReservation> events = eventReservation != null ? Ok(eventReservation) : BadRequest();
            return events;
        }

        [HttpPost("adicionar/reserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public ActionResult<EventReservation> InsertReservation(long idEvent, EventReservation newEventReservation)
        {
            ActionResult<EventReservation> events = (!_eventReservationService.InsertReservation(newEventReservation)) ? 
                BadRequest() : Ok(newEventReservation);
            return events;
        }

        [HttpPut("alterar/reserva/{idReservation}/{quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidateExistReservationActionFilter))]
        public ActionResult<EventReservation> UpdateQuantityReservation(long idReservation, EventReservation eventReservation)
        {
            ActionResult<EventReservation> events = (!_eventReservationService.UpdateQuantityReservation(idReservation, eventReservation)) ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok(eventReservation);
            return events;
        }

        [HttpDelete("deletar/reserva/{idReservation}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ServiceFilter(typeof(ValidateExistReservationActionFilter))]
        public ActionResult<EventReservation> DeleteReservation(long idReservation)
        {
            ActionResult<EventReservation> events = (!_eventReservationService.DeleteReservation(idReservation)) ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok();
            return events;
        }
    }
}
