using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using BodybuildingTest.Models.Exercise;
using BodybuildingTest.Models.UserInformation;

namespace BodybuildingTest.Models.UserTracking
{
    public class UserTracker //Properties corresponding to the UserTracker table in MySQL
    {
        public UserTracker()
        {
        }

        public int TrackerID { get; set; }
        public int UserID { get; set; }
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public int Set1Reps { get; set; }
        public int Set2Reps { get; set; }
        public int Set3Reps { get; set; }
        public int Set4Reps { get; set; }
        public int Set5Reps { get; set; }
        public float WeightLifted { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        //Navigation property
        public Exercises exercise { get; set; }

        //This will allow UpdateUserTracker.cshtml to update the usertracker table and
        //pull the ExerciseNames from the exercise table as they would be the only options to choose from
        public IEnumerable<Exercises> Exercises { get; set; }

        public IEnumerable<UserInfo> AllUserInfo { get; set; }
    }
}
