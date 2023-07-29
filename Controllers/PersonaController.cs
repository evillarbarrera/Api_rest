using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
// using MyApi.Data;

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

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT Id,Nombre,Apellido,Direccion FROM bd_test.Persona";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using(MySqlConnection mycon=new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                Console.WriteLine("Conectado");
                using(MySqlCommand myCommand=new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    Console.WriteLine(myReader);
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        // [HttpPost]
        // public ActionResult<Persona> AddPersona(Item item)
        // {
        //     _context.Personas.Add(item);
        //     _context.SaveChanges();

        //     return item;       
        // }
    

    }
}
