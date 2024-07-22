using BodybuildingTest.Models.UserTracking;

namespace BodybuildingTest.Models.Exercise
{
    public class Exercises
    {
        public Exercises()
        {
        }
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; } = null!;
        public string BodySection { get; set; } = null!;

        //Navigation property
        public ICollection<UserTracker> UserTrackers { get; set; } = null!;
    }
}
