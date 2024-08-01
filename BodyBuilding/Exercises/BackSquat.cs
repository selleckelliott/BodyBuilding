using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Body_Building.Exercises
{//
    public class BackSquat
    {
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public BackSquat(int sets, int reps) //Sets/Reps to be called in to each day's routine
        {
            ExerciseName = "Back Squat";
            Sets = sets;
            Reps = reps;
        }
        public void Instructions() //This is a complex exercise that can easily result in injury if done incorrectly. The instructions, therefore, are more detailed.
        {
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Phase 1: The Setup");
            Console.WriteLine();
            Console.WriteLine("1. Start with the barbell resting in a stand at about chest level.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2. Grab the bar with a tight grip that’s slightly wider than shoulder width.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3. Step under the bar and position your feet parallel to each other.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("4. Squeeze your shoulder blades together to create a “shelf” for the bar to rest on. Place the bar in a balanced position across your upper back and shoulders.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("5. Once the bar is set, take a deep breath, brace your core, and extend your hips and knees to lift the bar out of the rack.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("6. After you remove the barbell from the stand, take two short and deliberate steps straight back. Your feet should end up slightly wider than shoulder-width apart. Most people benefit from pointing their toes slightly out. This is the starting position for each rep.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Phase 2: The Squat");
            Console.WriteLine();
            Console.WriteLine("1. Once you are in the starting position, take a deep breath, brace your core, and begin the descent.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2. Bend at the knees while dropping your hips back until the tops of your thighs are parallel to the ground.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3. The moment they are parallel, stand back up to the starting position.");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void CommonMistakes()
        {
            Console.WriteLine("COMMON MISTAKES AND HOW TO AVOID THEM");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Mistake: Knees caving in\n" +
                "Knee cave while squatting is a common mistake. If your knees move toward each other as you stand up from the squat, it can potentially lead to knee pain or injury over time. There are two things you can do to avoid this problem:\n" +
                "Move your feet closer together. If the starting foot position is too wide, the body will compensate by moving the knees toward each other. Try tightening your stance closer to shoulder-width position. Drive your knees out. A common coaching cue to help improve knee tracking is simply to focus on driving the knees out during the lift. Sometimes just being mindful of knee position helps take care of the problem.");
            Console.WriteLine();
            Console.WriteLine("General Tip:\n" +
                "Unlike most lifting exercises, the type of shoes you wear when squatting is important. Ideally, you want something with a hard, flat surface. Converse Chuck Taylors or most Vans shoes fit the bill. Another option is to use an Olympic weightlifting shoe, which is specifically designed for squatting. This shoe has an elevated heel that can help you maintain an upright posture while squatting at or below parallel. Most important, you want to avoid squatting in running shoes. The soft soles in most running shoes will make you feel as if you are trying to squat on a pillow. Running shoes are great for running but not for squatting.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
