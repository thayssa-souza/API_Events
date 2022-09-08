using API_Events.Core.Interfaces;
using API_Events.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityEventController : ControllerBase
    {
        public ICityEventService _cityEventService;

        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet(Name = "buscar-todos-eventos")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEvent> GetCityEvents()
        {
            var cityEvents = _cityEventService.GetCityEvents();
            ActionResult<CityEvent> events = cityEvents != null ? Ok(cityEvents) : BadRequest("Não há eventos cadastrados");
            return events;
        }


        [HttpGet(Name = "buscar-evento-especifico")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public CityEvent GetSpecificEvent(long id)
        {
            var cityEvents = _cityEventService.GetSpecificEvent(id);
            object events = cityEvents != null ? Ok(cityEvents) : BadRequest("Lamento, evento não cadastro.");
            return (CityEvent)events;
        }
    }
}