using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllExercises();
    }
}
