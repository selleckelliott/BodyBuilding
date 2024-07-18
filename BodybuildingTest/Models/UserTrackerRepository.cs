using Dapper;
using System.Data;

namespace BodybuildingTest.Models
{
    public class UserTrackerRepository : IUserTrackerRepository
    {
        private readonly IDbConnection _conn;
        public UserTrackerRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<UserTracker> GetAllTrackers()
        {
            return _conn.Query<UserTracker>("Select * From USERTRACKER;");
        }
        public UserTracker GetTrackers(int id)
        {
            return _conn.QuerySingle<UserTracker>("SELECT * FROM USERTRACKER WHERE TRACKERID = @id", new { id = id });
        }
    }
}
