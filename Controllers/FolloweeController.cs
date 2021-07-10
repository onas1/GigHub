using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FolloweeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Followee
        [Authorize]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var artists = _context.Followings
                .Where(x => x.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
            return View(artists);
        }
    }
}