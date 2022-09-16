using API_Events.Core.Interfaces.IEvents;
using API_Events.Core.Interfaces.IReservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Events.Filters
{
    public class ConfirmStatusActionFilter : ActionFilterAttribute
    {
        public ICityEventService _cityEventService;
        public IEventReservationService _eventReservationService;
        public ConfirmStatusActionFilter(ICityEventService cityEventService, IEventReservationService eventReservationService)
        {
            _cityEventService = cityEventService;
            _eventReservationService = eventReservationService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            long idEvent = (long)context.ActionArguments["idEvent"];
            if(_cityEventService.ConsultReservation(idEvent) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status406NotAcceptable);
            }
        }
    }
}
