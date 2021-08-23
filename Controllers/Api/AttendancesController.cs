using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Dtos;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{

    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpPost]
        [Authorize]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();


            if (_unitOfWork.Attendances.GetAttendances(dto.GigId, userId) != null)
            {
                return BadRequest("The attendance already exists.");
            }
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteAttendance(int Id)
        {
            Attendance attendanace = _unitOfWork.Attendances.GetAttendances(Id, User.Identity.GetUserId());

            if (attendanace == null)
                return NotFound();

            _unitOfWork.Attendances.Remove(attendanace);
            _unitOfWork.Complete();
            return Ok(Id);
        }
    }
}
