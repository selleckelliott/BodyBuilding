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
        public IEnumerable<Exercises> GetAllExercises()
        {
            return _conn.Query<Exercises>("SELECT * FROM EXERCISE");
        }
        public Exercises GetExercise(int id)
        {
            return _conn.QuerySingle<Exercises>("SELECT * FROM EXERCISE WHERE EXERCISEID = @id", new { id = id });
        }
        public void UpdateExercise(Exercises exercise)
        {
            _conn.Execute("UPDATE exercise SET ExerciseName = @ExerciseName, BodySection = @BodySection WHERE ExerciseID = @id",
             new { exercisename = exercise.ExerciseName, bodysection = exercise.BodySection, id = exercise.ExerciseID });
        }
    }
}
