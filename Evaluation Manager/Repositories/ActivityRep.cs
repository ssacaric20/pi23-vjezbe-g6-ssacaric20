using DBLayer;
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.Repositories
{
    internal class ActivityRep
    {
        public static Activity GetActivity(int id)
        {
            Activity aktivnost = null;

            string sql = $"SELECT * FROM Activities WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                aktivnost = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return aktivnost;
        }

        public static List<Activity> GetActivity()
        {
            List<Activity> aktivnosti = new List<Activity>();

            string sql = "SELECT * FROM Activities";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Activity aktivnost = CreateObject(reader);
                aktivnosti.Add(aktivnost);
            }

            reader.Close();
            DB.CloseConnection();

            return aktivnosti;
        }

        private static Activity CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            string description = reader["Description"].ToString();
            int maxPoints = int.Parse(reader["MaxPoints"].ToString());
            int minPointsForGrade = int.Parse(reader["MinPointsForGrade"].ToString());
            int minPointsForSignature = int.Parse(reader["MinPointsForSignature"].ToString());

            var aktivnost = new Activity
            {
                Id = id,
                Name = name,
                Description = description,
                MaxPoints = maxPoints,
                MinPointsForGrade = minPointsForGrade,
                MinPointsForSignature = minPointsForSignature
            };

            return aktivnost;
        }
}
