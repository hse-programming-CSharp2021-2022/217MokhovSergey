using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace home_work.Controllers
{
    [ApiController]
    [Route("adventure-works-info")]
    public class AdventureWorksController : ControllerBase
    {
        private const string ConnectionString = "Data Source=AdventureWorksLT.db";

        [HttpGet("get-all-products-info")]
        public IActionResult GetAllProductsInfo()
        {
            var SQL = "SELECT * FROM Product";
            var dataTable = ExecuteSQL_DataTable(ConnectionString, SQL);

            var jsonResult = JsonConvert.SerializeObject(dataTable);
            return jsonResult.Length <= 0 ? BadRequest("No products!") : Ok(jsonResult);
        }

        [HttpGet("get-product-info-by-id-{productId:int}")]
        public IActionResult GetProductInfoById(int productId)
        {
            var SQL = $"SELECT * FROM Product WHERE ProductId = {productId}";
            var dataTable = ExecuteSQL_DataTable(ConnectionString, SQL);

            var jsonResult = JsonConvert.SerializeObject(dataTable);
            return jsonResult.Length <= 0 ? BadRequest("No such product!") : Ok(jsonResult);
        }

        [HttpPut("update-product-info")]
        public IActionResult UpdateProductInfo(
            [Required] int id, [Required] string name, [Required] string number,
            [Required] string color, [Required] int cost, [Required] int price
            )
        {
            var SQL = $"UPDATE Product SET Name = '{name}', ProductNumber = '{number}', Color = '{color}', " +
                            $"StandardCost = {cost}, ListPrice = {price} WHERE ProductID = {id}";
            ExecuteSQL_DataTable(ConnectionString, SQL);

            return Ok("Product successfully updated!");
        }

        [HttpPost("add-product-info")]
        public IActionResult InsertProductInfo(
            [Required] string name, [Required] string number, [Required] string color,
            [Required] int cost, [Required] int price
            )
        {
            var newProductId = GenerateProductId();
            var newGuid = GenerateGuidNumber();

            var insertionIsSuccessful = true;
            try
            {
                var SQL =
                    "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid) " +
                    $"VALUES ({newProductId}, '{name}', '{number}', '{color}', {cost}, {price}, '2022-03-21 21:21:21', '{newGuid}')";
                ExecuteSQL_DataTable(ConnectionString, SQL);
            }
            catch (Exception)
            {
                insertionIsSuccessful = false;
            }

            return insertionIsSuccessful
                ? Ok($"Product with product id: {newProductId} and guid: {newGuid} was inserted successfully!")
                : BadRequest($"Product with product id: {newProductId} and guid: {newGuid} cannot be inserted!");
        }

        [HttpDelete("delete-product-info-by-id-{productId:int}")]
        public IActionResult DeleteProductInfo(int productId)
        {
            var SQL = $"DELETE FROM Product WHERE ProductID = {productId}";

            var deleteIsSuccessful = true;
            try
            {
                ExecuteSQL_DataTable(ConnectionString, SQL);
            }
            catch (Exception)
            {
                deleteIsSuccessful = false;
            }

            return deleteIsSuccessful
                ? Ok("Product was successfully deleted!")
                : BadRequest($"Product with id {productId} was not found!");
        }

        private static int GenerateProductId()
        {
            var productIdString = new StringBuilder();
            for (var i = 0; i < 5; i++)
            {
                productIdString.Append((char)new Random().Next(48, 58));
            }

            int.TryParse(productIdString.ToString(), out var resultProductId);
            return resultProductId;
        }

        private static string GenerateGuidNumber()
        {
            var guid = new StringBuilder();
            for (var i = 0; i < 5; i++)
            {
                guid.Append((char)new Random().Next(97, 123));
            }

            return guid.ToString();
        }

        private static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            var dt = new DataTable();
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand(SQL, con);
            cmd.CommandType = CommandType.Text;

            foreach (var tuple in parameters)
                cmd.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));

            con.Open();
            var reader = cmd.ExecuteReader();
            for (var i = 0; i < reader.FieldCount; i++)
                dt.Columns.Add(new DataColumn(reader.GetName(i)));

            var rowIndex = 0;
            while (reader.Read())
            {
                var row = dt.NewRow();
                dt.Rows.Add(row);
                for (var i = 0; i < reader.FieldCount; i++)
                    dt.Rows[rowIndex][i] = (reader.GetValue(i));
                rowIndex++;
            }

            return dt;
        }
    }
}