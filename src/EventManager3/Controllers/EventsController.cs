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
        [Authorize(Roles = "artist")]
        public IActionResult Create()
        {
            //ViewBag.EventList = new SelectList(_context.Users, "EventID", "Name");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "artist")]
        public IActionResult Create(Events addnewEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addnewEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    
    [Authorize(Roles = "artist")]
    public IActionResult Update(int? id)
    {

        Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [Authorize(Roles = "artist")] 
    public IActionResult Update(Events e)
    {
        _context.Update(e);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "artist")]
    public IActionResult Delete(int? id)
    {
        Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);
        return RedirectToAction("Index");
    }
    [HttpPost]
    [Authorize(Roles = "artist")]
    public IActionResult Delete(Events e)
    {
        _context.Remove(e);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
}



   
