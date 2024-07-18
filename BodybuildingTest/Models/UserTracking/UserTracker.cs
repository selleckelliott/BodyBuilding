using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BodybuildingTest.Models.UserTracking
{
    public class UserTracker //Properties corresponding to the exercise table in MySQL
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

    }
}
