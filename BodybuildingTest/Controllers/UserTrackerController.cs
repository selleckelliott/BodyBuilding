using BodybuildingTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BodybuildingTest.Controllers
{
    public class UserTrackerController : Controller
    {
        private readonly IUserTrackerRepository repo;

        public UserTrackerController(IUserTrackerRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var userTracker = repo.GetAllTrackers();
            return View(userTracker);
        }
        public IActionResult ViewUserTracker(int id)
        {
            var userTracker  = repo.GetTrackers(id);
            return View(userTracker);
        }
    }
}
