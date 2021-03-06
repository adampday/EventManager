﻿using System;
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
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
            return View();
        }

        [Authorize]
        public IActionResult ReadEvents(int? id)
        {

            Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);
            return View(e);
        }

        [Authorize(Roles = "ARTIST")]
        public IActionResult Update(int? id)
        {

            Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);
            return View(e);

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

            e.ArtistName = artistName;
            _context.Events.Update(e);
            _context.SaveChanges();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize(Roles = "ARTIST")]
        public IActionResult Delete(int? id)
        {
            Events e = _context.Events.SingleOrDefault(a => a.EventsID == id);


            return View(e);

        }


        [HttpPost]
        [Authorize(Roles = "ARTIST")]
        public IActionResult Delete(Events e)
        {
            _context.Events.Remove(e);
            _context.SaveChanges();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        //[Authorize]
        //public IActionResult Follow()
        //{
        //    string userID = _userManager.GetUserId(User);
        //    foreach (var follow in _context.Follows)
        //    {
        //        if (follow.UserID == userID)
        //        {
        //            if (follow.Follow == null)
        //            {
        //                follow.Follows = new List<ApplicationUser>();
        //            }
        //            return View(follow);
        //        }
        //    }
        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult Follow(int? id)
        //{
        //    ApplicationUser artist = new ApplicationUser();
        //    Events events = _context.Events.SingleOrDefault(a => a.EventsID == id);
        //    String artist_name = events.ArtistName;
        //    foreach (var find_artist in _context.Users)
        //    {
        //        if (find_artist.UserName == artist_name)
        //        {
        //            artist = find_artist;
        //        }
        //    }
        //    string userID = _userManager.GetUserId(User);
        //    foreach (var follow in _context.Follows)
        //    {
        //        if (follow.UserID == userID)
        //        {
        //            if (follow == null)
        //            {
        //                follow.Follow = new List<ApplicationUser>();
        //            }
        //            return View(follow);
        //        }
        //    }
        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }




   
