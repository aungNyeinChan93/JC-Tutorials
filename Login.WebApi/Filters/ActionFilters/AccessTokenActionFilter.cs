using Login.WebApi.Controllers;
using Login.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Login.WebApi.Filters.ActionFilters
{
    public class AccessTokenActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var accessToken);

            if (!result)
            {
                context.Result = new BadRequestResult();
                return;
            }
            if (accessToken.Count <= 0) 
            { 
                context.Result = new UnauthorizedResult();
                return;
            }

            var hashService = context.HttpContext.RequestServices.GetRequiredService<HashService>();

            var decryptedStr = hashService.Decrypt(accessToken.ToString());
            var loginModel = JsonConvert.DeserializeObject<LoginModel>(decryptedStr);

            if(loginModel!.SessionExpire < DateTime.Now)
            {
                context.Result = new UnauthorizedResult();
                return;
            }



            await next();

        }
    }
}
