using Esemka.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Esemka.API.Controllers
{
    [ControllerName("Extracurricular")]
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class ExtracurricularController : ControllerBase
    {
        /// <summary>
        /// Digunakan untuk mendapatkan data ekstrakurikuler yang ada di EsemkaSchool
        /// </summary>
        /// <response code="200">Berhasil mendapatkan data ekstrakurikuler</response>
        /// <response code="401">User harus login terlebih dahulu</response>
        [HttpGet("Extracurriculars")]
        public IActionResult GetAllExtracurricular()
        {
            //if(GlobalData.loggedInUser == null)
            //{
            //    return Unauthorized("You must login first");
            //}

            using (var db = new EsemkaContext())
            {
                return Ok(db.Ekskuls.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                    x.Day,
                    StartTime = x.StartTime.ToString(@"hh\:mm"),
                    EndTime = x.EndTime.ToString(@"hh\:mm"),
                    x.IconName
                }).ToList());
            }
        }

        /// <summary>
        /// Digunakan untuk mendapatkan data detail ekstrakurikuler yang ada di EsemkaSchool
        /// </summary>
        /// <response code="200">Berhasil mendapatkan data detail ekstrakurikuler</response>
        /// <response code="400">Data ekstrakurikuler tidak ditemukan</response>
        /// <response code="401">User harus login terlebih dahulu</response>
        [HttpGet("Extracurricular/{id}")]
        public IActionResult GetExtracurricularDetail(int id)
        {
            //if(GlobalData.loggedInUser == null)
            //{
            //    return Unauthorized("You must login first");
            //}

            using (var db = new EsemkaContext())
            {
                var checkExtracurricular = db.Ekskuls.Where(x => x.Id == id).Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                    x.Day,
                    StartTime = x.StartTime.ToString(@"hh\:mm"),
                    EndTime = x.EndTime.ToString(@"hh\:mm"),
                    x.IconName,
                    Leader = x.EkskulMembers.Where(y => y.Position == "Leader")!.Select(y => new
                    {
                        y.Id,
                        y.User.Fullname,
                        JoinDate = y.JoinDate.ToString("dd MMMM yyyy"),
                        y.Position
                    }).FirstOrDefault(),
                    Members = x.EkskulMembers.Where(y => y.Position != "Leader").Select(y => new
                    {
                        y.Id,
                        y.User.Fullname,
                        JoinDate = y.JoinDate.ToString("dd MMMM yyyy"),
                        y.Position
                    }).ToList()
                }).FirstOrDefault();

                if(checkExtracurricular == null)
                {
                    return NotFound("Extracurricular not found");
                }

                return Ok(checkExtracurricular);
            }
        }

        /// <summary>
        /// Digunakan untuk bergabung ke dalam suatu ekstrakurikuler
        /// </summary>
        /// <response code="200">Berhasil bergabung ke dalam ekstrakurikuler yang dipilih</response>
        /// <response code="400">Data ekstrakurikuler tidak ditemukan</response>
        /// <response code="401">User harus login terlebih dahulu</response>
        [HttpPost("Extracurricular/Join/{extracurricularID}")]
        public IActionResult JoinExtracurricular(int extracurricularID)
        {
            if(GlobalData.loggedInUser == null)
            {
                return Unauthorized("You must login first");
            }

            using (var db = new EsemkaContext())
            {
                var checkExtracurricular = db.Ekskuls.FirstOrDefault(x => x.Id == extracurricularID);
                if(checkExtracurricular == null)
                {
                    return BadRequest("Extracurricular not found");
                }

                db.EkskulMembers.Add(new EkskulMember
                {
                    UserId = GlobalData.loggedInUser.Id,
                    EkskulId = extracurricularID,
                    JoinDate = DateTime.Now.Date,
                    Position = "Member"
                });
                db.SaveChanges();

                return Ok("Success joined");
            }
        }

        /// <summary>
        /// Digunakan untuk mendapatkan daftar ekstrakurikuler yang telah didaftar oleh user
        /// </summary>
        /// <response code="200">Berhasil bergabung ke dalam ekstrakurikuler yang dipilih</response>
        /// <response code="400">Data ekstrakurikuler tidak ditemukan</response>
        /// <response code="401">User harus login terlebih dahulu</response>
        [HttpGet("Extracurriculars/Me")]
        public IActionResult GetMyExtracurriculars()
        {
            if(GlobalData.loggedInUser == null)
            {
                return Unauthorized("You must login first");
            }

            using (var db = new EsemkaContext())
            {
                var checkUser = db.Users.FirstOrDefault(x => x.Id == GlobalData.loggedInUser.Id);
                if (checkUser == null)
                {
                    return BadRequest("User not found");
                }

                return Ok(db.EkskulMembers.Where(x => x.UserId == GlobalData.loggedInUser.Id).Select(x => new
                {
                    x.Ekskul.Id,
                    x.Ekskul.Name,
                    x.Ekskul.IconName,
                    JoinDate = x.JoinDate.ToString("dd MMMM yyyy"),
                    x.Position
                }).ToList());
            }
        }
    }
}
