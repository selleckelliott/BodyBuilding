using Dapper;
using System.Data;

namespace BodybuildingTest.Models.Exercise
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IDbConnection _conn;
        public ExerciseRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Exercise> GetAllExercises()
        {
            return _conn.Query<Exercise>("SELECT * FROM EXERCISE");
        }
        public Exercise GetExercise(int id)
        {
            return _conn.QuerySingle<Exercise>("SELECT * FROM EXERCISE WHERE EXERCISEID = @id", new { id = id });
        }
        public void UpdateExercise(Exercise exercise)
        {
            _conn.Execute("UPDATE exercise SET ExerciseName = @ExerciseName, BodySection = @BodySection WHERE ExerciseID = @id",
             new { exercisename = exercise.ExerciseName, bodysection = exercise.BodySection, id = exercise.ExerciseID });
        }
    }
}
