using Microsoft.Data.SqlClient;
using System;

namespace P03.MinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string connectionString = "Server=localhost;Database=MinionsDB;User ID=sa;Password=PavlovNik4312;TrustServerCertificate=true;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string villainName = GetVillainNameById(n, sqlConnection);

            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {n} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {villainName}");
                GetVillainMinionsOrderedByName(n, sqlConnection);
            }



        }
        private static void GetVillainMinionsOrderedByName(int id, SqlConnection sqlConnection)
        {
            string minionsRankingQuery =
                        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNumber,
            m.Name, m.Age FROM Villains v
            JOIN MinionsVillains mv ON mv.VillainId = v.Id
            JOIN Minions m ON mv.MinionId = m.Id
            WHERE v.Id = @Id
            ORDER BY m.Name";

            SqlCommand minionsRankingCommand = new SqlCommand(minionsRankingQuery, sqlConnection);
            minionsRankingCommand.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = minionsRankingCommand.ExecuteReader();
            if (reader.HasRows)
            {
                using (reader)
                {
                    while (reader.Read())
                    {
                        long row = (long)reader["RowNumber"];
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];
                        Console.WriteLine($"{row}. {name} {age}");
                    }
                }
            }
            else
            {
                Console.WriteLine("(no minions)");
            }
        }

        private static string GetVillainNameById(int id, SqlConnection sqlConnection)
        {
            string villainQuery =
            @"SELECT Name FROM Villains
            WHERE Id = @Id";

            SqlCommand villainSqlCommand = new SqlCommand(villainQuery, sqlConnection);
            villainSqlCommand.Parameters.AddWithValue("@Id", id);
            string villainName = villainSqlCommand.ExecuteScalar()?.ToString();
            return villainName;
        }
    }
}
