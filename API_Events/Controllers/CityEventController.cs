using API_Events.Core.Interfaces.IEvents;
using API_Events.Core.Models;
using API_Events.Filters;
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

        [HttpGet("buscar/eventos")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityEvent>>> GetAllEvents()
        {
            return Ok(await _cityEventService.GetAllEvents());
        }

        [HttpGet("buscar/evento/id")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public async Task<ActionResult<CityEvent>> GetEventById(long idEvent)
        {
            return Ok(await _cityEventService.GetEventById(idEvent));
        }

        [HttpGet("buscar/evento/nome")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityEvent>>> GetEventByTitle(string title)
        {
            return Ok(await _cityEventService.GetEventByTitle(title));
        }

        [HttpGet("buscar/evento/local/data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityEvent>>> GetEventByLocalDate(string local, DateTime dateEvent)
        {
            return Ok(await _cityEventService.GetEventByLocalDate(local, dateEvent));
        }

        [HttpGet("buscar/evento/preco/data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityEvent>>> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent)
        {
            return Ok(await _cityEventService.GetEventByPriceDate(priceMin, priceMax, dateHourEvent));
        }

        [HttpPost("adicionar/evento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEvent>> InsertCityEvent(CityEvent newCityEvent)
        {
            ActionResult<CityEvent> events = (!await _cityEventService.InsertCityEvent(newCityEvent)) ? 
                BadRequest() : Ok(newCityEvent);
            return events;
        }

        [HttpPut("atualizar/evento/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public async Task<ActionResult<CityEvent>> UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {
            ActionResult<CityEvent> events = (!await _cityEventService.UpdateCityEvent(idEvent, cityEvent)) ? 
                new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok(cityEvent);
            return events;
        }

        [HttpPut("atualizar/{status}/evento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public async Task<ActionResult<CityEvent>> UpdateEventStatus(long idEvent)
        {
            ActionResult<CityEvent> events = (!await _cityEventService.UpdateEventStatus(idEvent)) ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok();
            return events;
        }

        [HttpDelete("deletar/evento/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEvent>> DeleteCityEvent(long idEvent)
        {
            ActionResult<CityEvent> events = (!await _cityEventService.DeleteCityEvent(idEvent)) ?
                BadRequest() : Ok();
            return events;
        }

    }
}