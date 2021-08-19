using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;


namespace GigHub.Controllers.Api
{

    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        [Authorize]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances
                .Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists.");
            }
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteAttendance(int Id)
        {
            var userId = User.Identity.GetUserId();
            var attendanace = _context.Attendances.SingleOrDefault(a => a.GigId == Id && a.AttendeeId == userId);

            if (attendanace == null)
                return NotFound();

            var result = _context.Attendances.Remove(attendanace);
            _context.SaveChanges();
            return Ok(Id);
        }
    }
}
