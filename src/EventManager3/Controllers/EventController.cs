using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager3.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationUser _context;

        public EventController(ApplicationUser context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            //ViewBag.EventList = new SelectList(_context.Users, "EventID", "Name");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "artist")]
        public IActionResult Create(Event ev, String addnewEvent)
        {
            if (ModelState.IsValid)
            {
                if (addnewEvent != null)
                {
                    foreach (var eve in _context.Users.ToList())
                    {
                        String name = eve.Name;
                        if (name == addnewEvent)
                        {
                            addnewEvent = "";
                        }
                    }
                    if (addnewEvent != "")
                    {
                        Event even = new Event();
                    }
                }
                if (addnewEvent != "")
                {
                    Event ev = new Event();
                    Event.Name = addnewEvent;
                    _context.Event.Add(event);
        _context.SaveChanges();

        }
    }
}
}
