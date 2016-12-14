using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using EventManager3.Data;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager3.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
       [Authorize(Roles = "ARTIST")]
        public IActionResult Create()
        {
            //ViewBag.EventList = new SelectList(_context.Users, "EventID", "Name");
            return View();
        }
        // new change

        [HttpPost]
       [Authorize(Roles = "ARTIST")]
        public IActionResult Create(Events addnewEvent)
        {
            string artistName = "";
            string currentUserName = _userManager.GetUserName(User);
            foreach (ApplicationUser user in _userManager.Users)
            {
                if (user.UserName == currentUserName)
                {
                    artistName = user.Name;
                }
            }
            if (ModelState.IsValid)
            {
                addnewEvent.ArtistName = artistName;
                _context.Events.Add(addnewEvent);
                _context.SaveChanges();
                return RedirectToAction(nameof(HomeController.Index),"Home");

            }
            return View();
        }

        [Authorize]
        public IActionResult ReadEvents(int? id)
        {

            Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);
            return View(e);
        }

    //[Authorize(Roles = "ARTIST")]
    public IActionResult Update(int? id)
    {

        Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);

            if (_userManager.GetUserName(User) == e.ArtistName)
            { 
                return View(e);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

   [HttpPost]
   [Authorize(Roles = "ARTIST")] 
    public IActionResult Update(Events e)
    {
            string artistName = "";
            string currentUserName = _userManager.GetUserName(User);
            foreach (ApplicationUser user in _userManager.Users)
            {
                if (user.UserName == currentUserName)
                {
                    artistName = user.Name;
                }
            }
            if (ModelState.IsValid)
            {
                e.ArtistName = artistName;
                _context.Events.Update(e);
                _context.SaveChanges();
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
            return View();
        }

  [Authorize(Roles = "ARTIST")]
    public IActionResult Delete(int? id)
    {
        Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);

            if (_userManager.GetUserName(User) == e.ArtistName)
            {
                return View(e);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    

    [HttpPost]
   [Authorize(Roles = "ARTIST")]
    public IActionResult Delete(Events e)
    {
        _context.Events.Remove(e);
        _context.SaveChanges();
        return RedirectToAction(nameof(HomeController.Index), "Home");
        }
}
}



   
