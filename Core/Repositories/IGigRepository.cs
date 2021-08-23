using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGig(int GigId);
        List<Gig> GetGigsUserAttending(string userId);
        Gig GetGigsWithAttendee(int Id);
        List<Gig> GetUpcomingGigsByArtist(string userId);
        void Add(Gig gig);

    }
}