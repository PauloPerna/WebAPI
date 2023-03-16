using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Presentation.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AcceptProfilesAttribute : ActionFilterAttribute
    {
        public AcceptProfilesAttribute(params string[] profile)
        {
            _profiles = profile;
        }
        private readonly string[] _profiles;

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var mensagem = "Você não possui acesso à esse recurso.";
            var profileHeader = context.HttpContext.Request.Headers["Profile"];
            if (string.IsNullOrEmpty(profileHeader))
            {
                context.Result = new JsonResult(mensagem){
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            if (!_profiles.Contains((string)profileHeader))
            {
                context.Result = new JsonResult(mensagem){
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}