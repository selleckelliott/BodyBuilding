using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models.Exercise
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllExercises();
    }
}
