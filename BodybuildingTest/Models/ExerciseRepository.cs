using Dapper;
using System.Data;

namespace BodybuildingTest.Models
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
            return _conn.Query<Exercise>("Select * From Exercise;");
        }
    }
}
