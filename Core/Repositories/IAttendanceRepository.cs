using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendances(int Id, string userId);
        List<Attendance> GetFutureAttendances(string userId);

        void Add(Attendance attendance);

        void Remove(Attendance attendance);

    }
}