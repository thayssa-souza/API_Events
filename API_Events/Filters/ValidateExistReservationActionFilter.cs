using API_Events.Core.Interfaces.IReservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Events.Filters
{
    public class ValidateExistReservationActionFilter : ActionFilterAttribute
    {
        public IEventReservationService _eventReservationService;

        public ValidateExistReservationActionFilter(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long idReservation = (long)context.ActionArguments["idReservation"];
            if (_eventReservationService.GetReservationById(idReservation) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            };
        }

    }
}
