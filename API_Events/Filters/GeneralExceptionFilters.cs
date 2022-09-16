using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;
using System.Reflection;

namespace API_Events.Filters
{
    public class GeneralExceptionFilters : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 500,
                Title = "Erro inesperado.",
                Detail = "Ocorreu um erro inesperado na solicitação.",
                Type = context.Exception.GetType().Name
            };

            switch(context.Exception)
            {
                case SqlException:
                    problem.Status = 503;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    Console.WriteLine("Erro inesperado ao se comunicar com o banco de dados, tente novamente.");
                    break;
                case NullReferenceException:
                    problem.Status = 417;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    Console.WriteLine("Erro ao adicionar um valor não válido. Tente novamente");
                    break;
                default:
                    problem.Status = 500;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    Console.WriteLine("Erro inesperado no sistema. Tente novamente");
                    break;

            }
        }
    }
}
