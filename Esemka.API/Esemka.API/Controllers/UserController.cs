using Esemka.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esemka.API.Controllers
{
    [ControllerName("User")]
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class RegisterDTO
        {
            public string Username { get; set; }

            public string Password { get; set; }

            public string Fullname { get; set; }

            public string PhoneNumber { get; set; }
        }

        /// <summary>
        /// Digunakan untuk registrasi akun ke dalam aplikasi
        /// </summary>
        /// <response code="200">Berhasil registrasi akun</response>
        /// <response code="400">Username telah dipakai</response>
        [HttpPost("Register")]
        public IActionResult RegisterUser(RegisterDTO data)
        {
            using (var db = new EsemkaContext())
            {
                var checkUsername = db.Users.FirstOrDefault(x => x.Username == data.Username);
                if(checkUsername != null)
                {
                    BadRequest("Username already exists");
                }

                db.Users.Add(new Models.User
                {
                    Username = data.Username,
                    Fullname = data.Fullname,
                    Password = data.Password,
                    PhoneNumber = data.PhoneNumber
                });
                db.SaveChanges();

                var insertedUser = db.Users.FirstOrDefault(x => x.Username == data.Username);

                GlobalData.loggedInUser = insertedUser;

                return Ok(insertedUser);
            }
        }

        /// <summary>
        /// Digunakan untuk mendapatkan data akun
        /// </summary>
        /// <response code="200">Berhasil mendapatkan data akun</response>
        /// <response code="401">User harus login terlebih dahulu</response>
        [HttpGet("Me")]
        public IActionResult GetMyInformation()
        {
            if(GlobalData.loggedInUser == null)
            {
                return Unauthorized("You must login first");
            }

            return Ok(GlobalData.loggedInUser);
        }
    }
}
