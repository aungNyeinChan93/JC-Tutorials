using Login.WebApi.Controllers;
using Login.WebApi.Services;
using Newtonsoft.Json;

namespace Login.WebApi.MIddlewares
{
    public class AccessTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public AccessTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly string[] AllowPath = ["/api/auth/login", "/weatherforecast"];
        public async Task InvokeAsync(HttpContext context)
        {
            if (AllowPath.Contains(context.Request.Path.ToString().ToLower()))
            {
                goto Result;
            }

            
            var result = context.Request.Headers.TryGetValue("Authorization", out var accessToken);
            if(!result)
            {
                context.Response.StatusCode = 401;
                return;
            }
            if(accessToken.Count <= 0)
            {
                context.Response.StatusCode = 400;
                return;
            }
            var hashService = context.RequestServices.GetRequiredService<HashService>();
            var decryptedStr = hashService.Decrypt(accessToken.ToString());
            var loginModel = JsonConvert.DeserializeObject<LoginModel>(decryptedStr);
            if(loginModel!.SessionExpire < DateTime.Now)
            {
                context.Response.StatusCode = 401;
                return;
            }

            Result:

            await _next(context);

        }
    }

    public static class AccessTokenMiddlewareExtension
    {
        public static void UseAccessTokenMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AccessTokenMiddleware>();
        }
    }
}
