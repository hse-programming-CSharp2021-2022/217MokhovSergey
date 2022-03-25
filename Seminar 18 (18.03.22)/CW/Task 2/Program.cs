using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Task_2
{
    class Program
    {
        private const string ConnectionString = "Data Source=AdventureWorksLT.db";

        static void Main(string[] args)
        {
            var sql1 = "UPDATE Product SET StandardCost = 50 WHERE ProductID = 680";
            ExecuteSQL_DataTable(ConnectionString, sql1);

            var sql2 = "UPDATE Product SET ListPrice = 78 WHERE ProductID = 680";
            ExecuteSQL_DataTable(ConnectionString, sql2);

            var sql3 = "DELETE FROM Product WHERE ProductId = 1";
            ExecuteSQL_DataTable(ConnectionString, sql3);

            var sql4 =
                "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid) " +
                "VALUES (73810, 'NewFuckingProduct1', 'SH-00-013710718', 'Red', 100, 90, '2022-03-21 21:21:21', '5301997')";
            ExecuteSQL_DataTable(ConnectionString, sql4);

            var sql5 = "DELETE FROM Product WHERE ProductId = 706";
            ExecuteSQL_DataTable(ConnectionString, sql5);

            var sql6 = "SELECT * FROM Product WHERE ListPrice < 700 and ListPrice > 560";
            var dataTable6 = ExecuteSQL_DataTable(ConnectionString, sql6);
            Print(dataTable6);

            var sql7 = "SELECT * FROM Product WHERE INSTR(Name, 'Product')";
            var dataTable7 = ExecuteSQL_DataTable(ConnectionString, sql7);
            Print(dataTable7);

            var sql8 = "SELECT * FROM Product WHERE ProductId = 1";
            var dataTable8 = ExecuteSQL_DataTable(ConnectionString, sql8);
            Print(dataTable8);
        }


        private static void Print(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        private static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            var dt = new DataTable();

            using var connection = new SqliteConnection(connectionString);
            using var command = new SqliteCommand(SQL, connection);

            command.CommandType = CommandType.Text;

            foreach (var tuple in parameters)
            {
                command.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));
            }

            connection.Open();
            var reader = command.ExecuteReader();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(reader.GetName(i)));
            }

            var rowIndex = 0;
            while (reader.Read())
            {
                var row = dt.NewRow();
                dt.Rows.Add(row);

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    dt.Rows[rowIndex][i] = (reader.GetValue(i));
                }
                rowIndex++;
            }

            return dt;
        }
    }
}