using API_Events.Core.Interfaces;
using API_Events.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
        public ICityEventService _cityEventService;

        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet("buscar-todos-eventos")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEvent> GetCityEvents()
        {
            var cityEvents = _cityEventService.GetCityEvents();
            ActionResult<CityEvent> events = cityEvents != null ? Ok(cityEvents) : BadRequest();
            return events;
        }


        [HttpGet("buscar-evento-por-nome")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEvent> GetEventByTitle(string title)
        {
            var cityEvents = _cityEventService.GetEventByTitle(title);
            ActionResult<CityEvent> events = (cityEvents != null) ? Ok(cityEvents) : BadRequest();
            return events;
        }

        [HttpPost("adicionar-evento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> InsertCityEvent(CityEvent newCityEvent)
        {
            ActionResult<CityEvent> events = (!_cityEventService.InsertCityEvent(newCityEvent)) ? BadRequest() : Ok(newCityEvent);
            return events;
        }

        [HttpPut("atualizar-evento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> UpdateCityEvent(long id, CityEvent cityEvent)
        {
            ActionResult<CityEvent> events = (!_cityEventService.UpdateCityEvent(id, cityEvent)) ? BadRequest() : Ok(cityEvent);
            return events;
        }
    }
}