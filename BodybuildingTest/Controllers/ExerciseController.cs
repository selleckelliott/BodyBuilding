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
        public IActionResult ViewExercise(int id)
        {
            var exercise = repo.GetExercise(id);
            return View(exercise);
        }
        public IActionResult UpdateExercise(int id)
        {
            Exercise exercise = repo.GetExercise(id);
            if (exercise == null)
            {
                return View("ExerciseNotFound");
            }
            return View(exercise);
        }
        //This method can update the exercise name and they body section
        public IActionResult UpdateExerciseToDatabase(Exercise exercise)
        {
            repo.UpdateExercise(exercise);

            return RedirectToAction("ViewExercise", new { id = exercise.ExerciseID });
        }
    }
}
