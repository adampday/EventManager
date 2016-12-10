using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager3.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationUser _context;

        public AlbumsController(ApplicationUser context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.EventList = new SelectList(_context.AspNetUsers, "EventID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event event, String addnewEvent)
            {
            if (ModelState.IsValid)
            {
                if (addNewEvent != null)
                {
                    foreach (var ev in _context.AspNetUsers.ToList())
                    {
                        String name = ev.Name;
                        if (name == addnewEvent)
                        {
                            addnewEvent = "";
                        }
                    }
                    if (addNewEvent != "")
                    {
                        Event ev = new Event();
                    }
                }
                if (addNewEvent != "")
                {
                    Event ev = new Event();
                    Event.Name = addNewEvent;
                    _context.Event.Add(event);
                    _context.SaveChanges();

        }
    }
}
     