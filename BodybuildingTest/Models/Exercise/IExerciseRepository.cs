using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models.Exercise
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercises> GetAllExercises();
        Exercises GetExercise(int id);
        void UpdateExercise(Exercises exercise);
    }
}
