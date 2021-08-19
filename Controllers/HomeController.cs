using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Index(string query = null)
        {
            var upcomingGigs = await _context.Gigs
                .Include(x => x.Artist)
                .Include(x => x.Genre)
                .Where(x => x.DateTime > DateTime.Now && !x.IsCanceled)
                .ToListAsync();

            if (!string.IsNullOrEmpty(query))
            {
                upcomingGigs = upcomingGigs.Where(x =>
                x.Artist.Name.Contains(query) ||
                x.Genre.Name.Contains(query) ||
                x.Venue.Contains(query)).ToList();

            }
            var userId = User.Identity.GetUserId();
            var attendances = _context.Attendances.Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList().ToLookup(a => a.GigId);


            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances



            };
            return View("Gigs", viewModel);


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}