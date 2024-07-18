using BodybuildingTest.Models.Exercise;
using Microsoft.AspNetCore.Mvc;

namespace BodybuildingTest.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository repo;
        public ExerciseController(IExerciseRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var exercise = repo.GetAllExercises();
            return View(exercise);
        }
    }
}
