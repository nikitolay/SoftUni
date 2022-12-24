using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace P09.IncreaseAgeStoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //in sql server management studio
            /*CREATE PROC usp_GetOlder(@minionID INT)
AS
BEGIN
	UPDATE Minions
	SET Age += 1
	WHERE Id = @minionID
END

EXEC usp_GetOlder 2

SELECT Name, Age FROM Minions
WHERE Id = @minionID*/
            string connectionString = "Server=localhost;Database=MinionsDB;User ID=sa;Password=PavlovNik4312;TrustServerCertificate=true;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            ExecuteStoredProcedureThatIncrementMinionAge(sqlConnection, minionId);
            PrintMinionNameAndAge(sqlConnection, minionId);
        }

        private static void PrintMinionNameAndAge(SqlConnection sqlConnection, int minionId)
        {
            string getMinionInfoQuery =
            @"SELECT Name, Age FROM Minions
            WHERE Id = @minionID";
            SqlCommand getMinionInfoCmd = new SqlCommand(getMinionInfoQuery, sqlConnection);
            getMinionInfoCmd.Parameters.AddWithValue("@minionID", minionId);
            SqlDataReader reader = getMinionInfoCmd.ExecuteReader();
            reader.Read();
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];

            Console.WriteLine($"{minionName} – {minionAge} years old");
        }

        private static void ExecuteStoredProcedureThatIncrementMinionAge(SqlConnection sqlConnection, int minionId)
        {
            string storedProcName = "usp_GetOlder";

            using SqlCommand increaseAgeStoredProcedureCmd = new SqlCommand(storedProcName, sqlConnection);
            increaseAgeStoredProcedureCmd.CommandType = CommandType.StoredProcedure;
            increaseAgeStoredProcedureCmd.Parameters.AddWithValue("@minionID", minionId);

            increaseAgeStoredProcedureCmd.ExecuteNonQuery();
        }
    }
}
