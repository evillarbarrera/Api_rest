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

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PersonaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetPersona")]
        public string Get()
        {
            string query = @"SELECT Id,Nombre,Apellido,Direccion FROM Persona";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            string jsonResult = "";

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

            return jsonResult;

        }

        [HttpPost("InsertarPersona")]
        public string Post()
        {
            string query = @"insert into Persona (Nombre,Apellido,Direccion) values
                                                    (@Nombre,@Apellido,@Direccion);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Nombre", "Prueba2");
                    myCommand.Parameters.AddWithValue("@Apellido", "Prueba2");
                    myCommand.Parameters.AddWithValue("@Direccion", "Prueba2");

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return "Logrado";
        }


        [HttpPut("ActualizarPersona")]
        public string Put()
        {
            string query = @"
                        update Persona set 
                        Direccion =@Direccion
                        where Id=@Id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Direccion", "Prueba Direccion");
                    myCommand.Parameters.AddWithValue("@Id", "5");

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return "Logrado";
        }

        [HttpDelete("EliminarPersona")]
        public string Delete()
        {
            string query = @"
                        delete from Persona 
                        where Id=@Id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", "3");

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return "Deleted Successfully";
        }




    }
}
