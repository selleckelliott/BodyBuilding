using BodyBuilding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Body_Building.Exercises
{
    public class AirSquat : IExercises
    {
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public AirSquat(int sets, int reps) //Sets/Reps to be called in to each day's routine
        {
            ExerciseName = "Air Squat";
            Sets = sets;
            Reps = reps;
        }
        public void Instructions()
        {
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Start in a standing position with your feet roughly shoulder-width apart.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2. Drop your hips back like you are sitting in a chair while simultaneously bending your knees.\n" +
                "Continue moving down until your hips are below the tops of your knees.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3. Once you reach your lowest point, stand up. To help with balance, extend your arms directly in front of you as you move.");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void CommonMistakes()
        {
            Console.WriteLine("COMMON MISTAKES AND HOW TO AVOID THEM");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Mistake: Leaning too far forward\n" +
                "Try to keep your torso as vertical as possible. Avoid bending forward at the waist during the exercise.");
            Console.WriteLine();
            Console.WriteLine("General Tip:\n" +
                "Start each day with 5 to 10 air squats in the morning. It’s not only a great warm-up for a lower body workout; it’s also a great warm-up for the day.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
