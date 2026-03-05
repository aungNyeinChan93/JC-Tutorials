using Login.WebApi.Filters.ActionFilters;
using Login.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Login.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private HashService _hashService;

        public AuthController(HashService hashService)
        {
            _hashService = hashService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {

                var result = Users.users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
                if(result is null)
                {
                    return Unauthorized("user not found!");
                };

                LoginModel loginModel = new LoginModel()
                {
                    SessionExpire = DateTime.Now.AddMinutes(1),
                    SessionId = Guid.NewGuid().ToString(),
                    UserName = result.Name
                };

                var json = JsonConvert.SerializeObject(loginModel);
                var token = _hashService.Encrypt(json);
                return Ok(new LoginResponseModel { AccessToken = token});

            }
            catch (Exception err)
            {
                return Unauthorized(err.Message);
            }
        }


        //[ServiceFilter(typeof(AccessTokenActionFilter))]
        [HttpPost("users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                //HttpContext.Request.Headers.TryGetValue("Authorization", out var accessToken);
                //if(accessToken.Count <= 0)
                //{
                //    return Unauthorized();
                //}

                ////var result = _hashService.Decrypt(loginRequestModel.AccessToken);
                //var result = _hashService.Decrypt(accessToken.ToString());
                //LoginModel? loginModel = JsonConvert.DeserializeObject<LoginModel>(result);

                //if(loginModel!.SessionExpire < DateTime.Now)
                //{
                //    return Unauthorized("seeeion expire");
                //}
                //return Ok($"{loginModel.UserName} is authorize!");
                return Ok();
            }
            catch (Exception err)
            {
                return Unauthorized(err.Message);
            }
        }
    }

   

    public class Users 
    {
        public static List<User> users = new List<User>
            {
                new User {Name = "user",Password = "user"},
                new User {Name ="admin",Password = "admin"}
            };
    }

    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }

    public class LoginModel
    {
        public DateTime SessionExpire {  get; set; }
        public string SessionId { get; set; }
        public string UserName { get; set; }   
    }

    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
    }

    public class LoginRequestModel
    {
        public string AccessToken { get; set; }
    }

}
