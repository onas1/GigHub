using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }


        public Gig GetGigsWithAttendee(int Id)
        {
            return _context.Gigs
                 .Include(g => g.Attendances
                 .Select(a => a.Attendee))
                 .SingleOrDefault(g => g.Id == Id);
        }

        public List<Gig> GetUpcomingGigsByArtist(string userId)
        {
            return _context.Gigs
                 .Where(g =>
                 g.ArtistId == userId &&
                 g.DateTime > DateTime.Now &&
                 g.IsCanceled == false)
                 .Include(g => g.Genre)
                 .ToList();
        }

        public Gig GetGig(int GigId)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == GigId);
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}
