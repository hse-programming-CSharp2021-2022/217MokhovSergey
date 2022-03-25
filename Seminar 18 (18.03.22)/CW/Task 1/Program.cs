using System;
using Microsoft.Data.Sqlite;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=MyDB6.db";
            SqliteConnection con = new SqliteConnection(connectionString);
            con.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = con;
            command.CommandText = "CREATE TABLE Users2(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, name TEXT NOT NULL)";
            command.ExecuteNonQuery();



            command.CommandText = "INSERT INTO Users2(name) VALUES ('Tom')";
            command.ExecuteNonQuery();



            command.CommandText = "INSERT INTO Users2 (name) VALUES ('Bob')";
            command.ExecuteNonQuery();



            command.CommandText = "INSERT INTO Users2 (name) VALUES ('Alice')";
            command.ExecuteNonQuery();



            command.CommandText = "UPDATE Users2 SET name='BobUpdated' WHERE name='Bob'";
            command.ExecuteNonQuery();



            command.CommandText = "DELETE FROM Users2 WHERE name='Tom'";
            command.ExecuteNonQuery();



            command.CommandText = "SELECT * FROM Users2";
            SqliteDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1));
            }
        }
    }
}