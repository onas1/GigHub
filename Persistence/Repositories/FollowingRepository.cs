using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public Following GetFollowing(string userId, string ArtistId)
        {
            return _context.Followings.SingleOrDefault(x => x.FollowerId == userId && x.FolloweeId == ArtistId);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}
