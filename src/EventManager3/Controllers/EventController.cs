using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using EventManager3.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager3.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="artist")]
        public IActionResult Create()
        {
            //ViewBag.EventList = new SelectList(_context.Users, "EventID", "Name");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "artist")]
        public IActionResult Create(Event addnewEvent)
        {
            if (ModelState.IsValid)
            {
                    _context.Event.Add(addnewEvent);
                    _context.SaveChanges();
                return RedirectToAction("Index");

        }
        return View();
    }
}
}
