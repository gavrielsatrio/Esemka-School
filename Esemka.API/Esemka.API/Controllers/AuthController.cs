using Esemka.API.Controllers;
using Esemka.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esemka.Controllers
{
    [ControllerName("Authentication")]
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public class AuthDTO
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        /// <summary>
        /// Digunakan untuk melakukan autentikasi ke dalam aplikasi.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// {
        ///     "username" : "mahdi",
        ///     "password" : "1234"
        /// }
        /// </remarks>
        /// <response code="200">Berhasil melakukan login dan akan mengembalikan data user</response>
        /// <response code="400">Gagal login karena kombinasi username dan password tidak sesuai</response>
        [HttpPost("Auth")]
        public IActionResult Auth(AuthDTO loginData)
        {
            using (var db = new EsemkaContext())
            {
                var query = db.Users.Where(x => x.Username == loginData.Username && x.Password == loginData.Password).ToList().FirstOrDefault();
                if(query == null)
                {
                    return BadRequest("User not found");
                }

                GlobalData.loggedInUser = query;

                return Ok(query);
            }
        }
    }
}
