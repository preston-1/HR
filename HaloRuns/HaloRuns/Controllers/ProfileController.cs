﻿using HaloRuns.ModelBinders;
using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloRuns.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HaloRuns.Controllers
{
	[Route("/customroute/profiles2/{user}")]
	public class ProfileController : BaseController<int>
	{
		//[Route("{userVarParam}/main")]
		//[Route("{" + StringConstants.DefaultModelBindKeyword + "}/main")]

        public ProfileController(HaloRunsDbContext param)
            : base(param)
        {
              
        }
		
		[Route("main")]
		public IActionResult Index(
			//[ModelBinder(typeof(BaseModelBinder<User>))]
			User user
			)
		{
			return View();
		}


		[Route("GamePreferences")]
		public IActionResult GamePreferences(User user)
		{
			// userPref 

			/*
			  var UserRuns = this
                .db
                .Users
                .Include(u => u.Games)
                .Include(u => u.Runs)
                .ThenInclude(r => r.Map)
                .ThenInclude(m => m.Game)
                .Where(u => u.Username == "Steve")
                .First();
			 */

			// [['Steve','halo1'],['Steve','halo2'],['Steve','halo3']]
			var currUser =
					this
					.db
					.Users
					.Include(g => g.Games)
					.Include(u => u.UserGames)
					.Where(u => u.Username == user.Username) //user.Username == 'Steve'
					.First();


			//[game,bool]
			var userGamePreferences = this
					.db
					.Games
					.Select(g => new
					{
						game = g.name,
						isPreferred = currUser.Games.Contains(g),
					})
					.ToList();
				
			return View();
		}

		[Route("GamePreferences/{gamePreference}/disable")]
		public IActionResult DisableGamePreference(User user, game gamePreference, run myRun)
		{
			return Json(0);
		}

        public override JsonResult dataTableParam()
        {
            return Json(0);
        }
	}
}
