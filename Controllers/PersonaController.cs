using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Data;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly DBContext _context;

        public PersonaController(DBContext context)
        {
            Console.WriteLine(context);
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> GetPersona()
        {
                return _context.Personas;
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
