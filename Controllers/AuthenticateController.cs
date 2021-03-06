using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.Repositories;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return Unauthorized(new { message = "User or password invalid" });

            var token = TokenService.CreateToken(user);
            user.Password = "";
            return Ok(new
            {
                user = user,
                token = token
            });
        }
    }
}
