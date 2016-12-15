using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventManager3.Data;
using EventManager3.Models;
using Microsoft.AspNetCore.Identity;

namespace EventManager3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // NEW CHANGE
        // new change
        //[Authorize(Roles="ARTIST")]
        public IActionResult Index(String searchString, String sort)
        {
            if (searchString != null)
            {
                var events = from m in _context.Events
                             select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    events = events.Where(s => s.Name.Contains(searchString) || s.Location.Contains(searchString) || s.Genre.Contains(searchString) || s.ArtistName.Contains(searchString)); //return event

                }
                return View(events);
            }
            if (sort != null)
            {
                string artistName = "";
                string currentUserName = _userManager.GetUserName(User);
                foreach (ApplicationUser user in _userManager.Users)
                {
                    if (user.UserName == currentUserName)
                    {
                        artistName = user.Name;
                        var events = from m in _context.Events
                                     select m;
                        events = events.Where(s => s.ArtistName.Contains(artistName));
                        return View(events);
                    }
                }
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                var events = from m in _context.Events
                             select m;
                return View(events);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
