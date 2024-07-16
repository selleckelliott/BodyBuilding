using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BodybuildingTest.Models
{
    public class Exercise //Properties corresponding to the exercise table in MySQL
    {
        public Exercise()
        {
        }

        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public string BodySection { get; set; }
        public int Set1Reps { get; set; }
        public int Set2Reps { get; set; }
        public int Set3Reps { get; set; }
        public int Set4Reps { get; set; }
        public int Set5Reps { get; set; }
        public float WeightLifted { get; set; }
        public DateTime Date {  get; set; }
        public string Notes { get; set; }

    }
}
