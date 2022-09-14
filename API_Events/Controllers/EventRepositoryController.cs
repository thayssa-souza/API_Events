using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventRepositoryController : ControllerBase
    {
        public IEventReservationService _eventReservationService;
        public EventRepositoryController(IEventReservationService eventReserationService)
        {
            _eventReservationService = eventReserationService;
        }

        [HttpGet("bucar-evento-nome-reserva")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EventReservation> GetReservationList()
        {
            var eventReservation = _eventReservationService.GetReservationList();
            ActionResult<EventReservation> events = eventReservation != null ? Ok(eventReservation) : BadRequest();
            return events;
        }
    }
}
