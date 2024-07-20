using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models.Exercise
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllExercises();
        Exercise GetExercise(int id);
        void UpdateExercise(Exercise exercise);
    }
}
