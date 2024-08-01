using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Body_Building.Exercises
{
    public interface IExercises 
    {
        //Interface to provide structure to each exercise
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        public void Instructions();

        public void CommonMistakes();
    }
}
