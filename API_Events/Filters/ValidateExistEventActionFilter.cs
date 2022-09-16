using API_Events.Core.Interfaces.IEvents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Events.Filters
{
    public class ValidateExistEventActionFilter : ActionFilterAttribute
    {
        public ICityEventService _cityEventService;

        public ValidateExistEventActionFilter(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long idEvent = (long)context.ActionArguments["idEvent"];
            if (_cityEventService.GetEventById(idEvent) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
