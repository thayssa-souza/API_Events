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
        public ActionResult<CityEvent> GetAllEvents()
        {
            return Ok(_cityEventService.GetAllEvents());
        }

        [HttpGet("buscar/evento/id")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public ActionResult<CityEvent> GetEventById(long idEvent)
        {
            return Ok(_cityEventService.GetEventById(idEvent));
        }

        [HttpGet("buscar/evento/nome")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEvent> GetEventByTitle(string title)
        {
            var cityEvents = _cityEventService.GetEventByTitle(title);
            ActionResult<CityEvent> events = (cityEvents != null) ? Ok(cityEvents) : NotFound();
            return events;
        }

        [HttpGet("buscar/evento/local/data")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEvent> GetEventByLocalDate(string local, DateTime dateEvent)
        {
            var cityEvents = _cityEventService.GetEventByLocalDate(local, dateEvent);
            ActionResult<CityEvent> events = (cityEvents != null) ? Ok(cityEvents) : NotFound();
            return events;
        }

        [HttpGet("buscar/evento/preco/data")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEvent> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent)
        {
            var cityEvents = _cityEventService.GetEventByPriceDate(priceMin, priceMax, dateHourEvent);
            ActionResult<CityEvent> events = (cityEvents != null) ? Ok(cityEvents) : NotFound();
            return events;
        }

        [HttpPost("adicionar/evento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> InsertCityEvent(CityEvent newCityEvent)
        {
            ActionResult<CityEvent> events = (!_cityEventService.InsertCityEvent(newCityEvent)) ? 
                BadRequest() : Ok(newCityEvent);
            return events;
        }

        [HttpPut("atualizar/evento/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidateExistEventActionFilter))]
        public ActionResult<CityEvent> UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {
            ActionResult<CityEvent> events = (!_cityEventService.UpdateCityEvent(idEvent, cityEvent)) ? 
                new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok(cityEvent);
            return events;
        }

        [HttpDelete("deletar/evento/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> DeleteCityEvent(long idEvent)
        {
            ActionResult<CityEvent> events = (!_cityEventService.DeleteCityEvent(idEvent)) ?
                BadRequest() : Ok();
            return events;
        }

    }
}