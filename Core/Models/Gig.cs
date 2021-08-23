using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GigHub.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }
        public ApplicationUser Artist { get; set; }
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(this);
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }


        public void Modify(DateTime dateTime, string venue, byte genere)
        {
            // create a new notification for the gig and notify each attendee
            // if the gig is updated
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            // set the venue, date and genre for the notification

            Venue = venue;
            GenreId = genere;
            DateTime = dateTime;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);

        }
    }
}
