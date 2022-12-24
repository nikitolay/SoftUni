using Microsoft.Data.SqlClient;
using System;

namespace P02.VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=MinionsDB;User ID=sa;Password=PavlovNik4312;TrustServerCertificate=true;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query = @"SELECT v.Name,COUNT(m.Id) AS Count
                          FROM Villains v 
                          JOIN MinionsVillains mv ON mv.VillainId=v.Id
                          JOIN Minions m ON mv.MinionId=m.Id
                          GROUP BY v.Name
                          HAVING COUNT(m.Id) > 3
                          ORDER BY COUNT(m.ID) DESC";

            SqlCommand sqlCommand=new SqlCommand(query,sqlConnection);
           using SqlDataReader reader=sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["Count"];
                Console.WriteLine($"{villainName} - {minionsCount}");
            }
        }
    }
}
