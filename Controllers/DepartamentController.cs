using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models;
using Newtonsoft.Json;
// using MyApi.Data;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartamentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string query = @"SELECT DepartamentId,DepartamentName FROM bd_test.Departament";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            string jsonResult = string.Empty;

            //  Block of code to try
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    if (table != null && table.Rows.Count > 0)
                    {
                        jsonResult = JsonConvert.SerializeObject(table, Formatting.Indented);
                    }

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(jsonResult);


        }

        //Apuntes
        // for (int i = 0; i < table.Rows.Count; i++)
        // {
        //    Console.WriteLine(table.Rows[i]["DepartamentId"].ToString());
        //     Console.WriteLine(table.Rows[i]["DepartamentName"].ToString());
        // }
    }
}
