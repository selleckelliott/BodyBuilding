using BodybuildingTest.Models.UserInformation;
using BodybuildingTest.Models.UserTracking;
using BodybuildingTest.Models.Exercise;
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
        private readonly IExerciseRepository _exercisRepo;

        public UserTrackerController(IUserTrackerRepository repo, IExerciseRepository exercisRepo)
        {
            this.repo = repo;
            _exercisRepo = exercisRepo;
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
        public IActionResult UpdateUserTracker(int id)
        {
            UserTracker userTracker = repo.GetTrackers(id);
            if (userTracker == null)
            {
                return View("UserTrackingNotFound");
            }
            //Allows access to ExerciseName in exercise database
            var exercises = _exercisRepo.GetAllExercises();
            //var viewModel = new ExerciseAndUserTracker
            //{
                //UserTracker = userTracker,
                //Exercises = exercises
            //};
            return View(userTracker);
        }
        public IActionResult UpdateUserTrackerToDatabase(UserTracker userTracker)
        {
            repo.UpdateUserTracker(userTracker);

            return RedirectToAction("ViewUserTracker", new { id = userTracker.UserID });
        }
        public IActionResult NewUserTracker(UserTracker userTracker)
        {
            try
            {
                repo.InsertUserTracker(userTracker);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult InsertUserTracker()
        {
            var userTracker = repo.AssignNewUserTracker();
            return View(userTracker);
        }
    }
}
