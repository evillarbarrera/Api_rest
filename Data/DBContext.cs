using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
{
        public class DBContext : DbContext
        {

           public DBContext(DbContextOptions<DBContext> options): base(options)
            {
            }
            public  DbSet<Persona> Personas { get; set; }

        }

        
}
