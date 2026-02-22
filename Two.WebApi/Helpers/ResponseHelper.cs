
using Microsoft.AspNetCore.Mvc;
using Two.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Two.WebApi.Helpers
{
    public class ResponseHelper
    {
        public static IActionResult Execute<T>(BaseResponseModel<T> response)
        {
            if (response is null) return new ObjectResult("Response model is invalid");
            if (response.IsError)
            {
                   if (response.ResponseType == ResponseType.ValidationError) return new ObjectResult(new {message = response.ResponseDescription});
                   if (response.ResponseType == ResponseType.SystemError) return new ObjectResult(new {message = response.ResponseDescription});
            }
            return new OkObjectResult(response.ResponseData);
        }

        public static IActionResult Execute<T>(object res)
        {
            var jsonStr = JsonConvert.SerializeObject(res);
            var response = JsonConvert.DeserializeObject<BaseResponseModel<T>>(jsonStr);


            if (response is null) return new ObjectResult("Response model is invalid");
            if (response.IsError)
            {
                if (response.ResponseType == ResponseType.ValidationError) return new ObjectResult(new { message = response.ResponseDescription });
                if (response.ResponseType == ResponseType.SystemError) return new ObjectResult(new { message = response.ResponseDescription });
            }
            return new OkObjectResult(response.ResponseData);


        }
    }
}
