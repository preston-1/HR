﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HaloRuns.Models;
using Microsoft.EntityFrameworkCore;
using HaloRuns.Models.ViewModels;

namespace HaloRuns.Controllers
{
    public class HomeController : BaseController<int>
    {

        //private readonly ILogger<HomeController> _logger;

        public HomeController(HaloRunsDbContext param)
            : base(param)
        {
              
        }

        public IActionResult Index()
        {
            /*
             *  return
                this
                .timeOffDb
                .Requests
                .Include(r => r.Employee)
                .ThenInclude(e => e.Manager)
                .Where(r=> ids.Contains(r.Id));
             */
            //query for username and store all runs in a var
            //where usernam = 'steve'
            var UserRuns = this
                .db
                .Users
                .Include(u => u.Games)
                .Include(u => u.Runs)
                .ThenInclude(r => r.Map)
                .ThenInclude(m => m.Game)
                .Where(u => u.Username == "Steve")
                .First();
            //.First()
            //var UserRuns
            //.Runs;

            //store the game of a run in a variable 
            //

            var Game = this
                .db
                .Games
                .Where(g => g.id == 3)
                .First();

            UserRuns.Games.Add(Game);
            //UserRuns.Games.Remove(Game); //cannot pass a where clause or a lambda as a paramater. Have to pass object of the ICollection type which
                                         // in this case is of type Game
            db.SaveChanges();
            return View(this.user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DropdownTest()
		{
            var x = this
                .db
                .Maps
                .ToList();

            return View(new DropdownTestViewModel { maps = x});
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ViewResult Table() 
        {

            return View();
        }

        public override JsonResult dataTableParam()
        {
            return Json(0);
        }

    }
}
