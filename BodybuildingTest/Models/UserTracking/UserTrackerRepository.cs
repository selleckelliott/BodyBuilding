using BodybuildingTest.Models.Exercise;
using BodybuildingTest.Models.UserInformation;
using Dapper;
using System.Data;

namespace BodybuildingTest.Models.UserTracking
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
            return _conn.QuerySingle<UserTracker>("SELECT * FROM USERTRACKER WHERE TRACKERID = @id", new { id });
        }
        public void UpdateUserTracker(UserTracker userTracker)
        {
            _conn.Execute("UPDATE userTracker SET userID = @userID, exerciseID = @exerciseID," +
                "ExerciseName = @ExerciseName, Set1Reps = @Set1Reps, Set2Reps = @Set2Reps," +
                "Set3Reps = @Set3Reps, Set4Reps = @Set4Reps, Set5Reps = @Set5Reps, WeightLifted = @WeightLifted," +
                "Date = @Date, Notes = @Notes WHERE TrackerID = @id",
             new
             {
                 userID = userTracker.UserID,
                 exerciseID = userTracker.ExerciseID,
                 id = userTracker.TrackerID,
                 exerciseName = userTracker.ExerciseName,
                 set1Reps = userTracker.Set1Reps,
                 set2Reps = userTracker.Set2Reps,
                 set3Reps = userTracker.Set3Reps,
                 set4Reps = userTracker.Set4Reps,
                 set5Reps = userTracker.Set5Reps,
                 weightLifted = userTracker.WeightLifted,
                 date = userTracker.Date,
                 notes = userTracker.Notes
             });
        }
        public void InsertUserTracker(UserTracker userTracker)
        {
            _conn.Execute("INSERT INTO usertracker (UserID, ExerciseName, Set1Reps, Set2Reps, Set3Reps, Set4Reps" +
                "Set5Reps, WeightLifted, Date, Notes) VALUES (@UserID, @ExerciseName, @Set1Reps, @Set2Reps," +
                "@Set3Reps, @Set4Reps, @Set5Reps, @WeightLifted, @Date, @Notes);",
                new
                {
                    userID = userTracker.UserID,
                    exerciseName = userTracker.ExerciseName,
                    set1Reps = userTracker.Set1Reps,
                    set2Reps = userTracker.Set2Reps,
                    set3Reps = userTracker.Set3Reps,
                    set4Reps = userTracker.Set4Reps,
                    set5Reps = userTracker.Set5Reps,
                    weightLifted = userTracker.WeightLifted,
                    date = userTracker.Date,
                    notes = userTracker.Notes
                });
        }
        public IEnumerable<UserInfo> GetCurrentUsers()
        {
            return _conn.Query<UserInfo>("SELECT * FROM userinfo;");
        }
        public IEnumerable<Exercises> GetExercises()
        {
            return _conn.Query<Exercises>("SELECT * FROM exercise;");
        }
        public UserTracker AssignNewUserTracker()
        {
            var exerciseList = GetExercises();
            var userList = GetCurrentUsers();
            var userTracker = new UserTracker();
            userTracker.Exercises = exerciseList;
            userTracker.AllUserInfo = userList;
            return userTracker;
        }
    }
}
