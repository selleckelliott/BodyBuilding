using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Body_Building.Exercises
{
    public class LegSwing : IExercises
    {
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public LegSwing(int sets, int reps) //Sets/Reps to be called in to each day's routine
        {
            ExerciseName = "Leg Swing";
            Sets = sets;
            Reps = reps;
        }
        public void Instructions()
        {
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Stand with your feet shoulder-width apart and extend your arms against a wall or a sturdy" +
                "object. Leave enough room to swing your legs in front of you.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2. With your arms extended, stand on your left leg. " +
                "Extend your right leg to the side so that it is just off the ground.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3. Begin by swinging the right leg to the outside as far as you can and then swinging it back toward your body, " +
                "crossing the left leg, as far as you can. This completes one rep. Finish the set " +
                "(the number of reps depends on where you are in the 12-week program), and then repeat on the other side.");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void CommonMistakes()
        {
            Console.WriteLine("COMMON MISTAKES AND HOW TO AVOID THEM");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Mistake:\n" +
                "Opening up your hips Avoid opening up your hips when swinging your leg out to the side. " +
                "Keep your core tight and hips square throughout the entire exercise.\n" +
                "\n" +
                "General Tip:\n" +
                "Keep your legs loose. Shake out any tension below your hips.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
