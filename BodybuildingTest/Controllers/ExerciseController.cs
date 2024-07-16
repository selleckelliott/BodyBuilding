using BodybuildingTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BodybuildingTest.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository repo;

        public ExerciseController(IExerciseRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var exercises = repo.GetAllExercises();
            return View(exercises);
        }
    }
}
