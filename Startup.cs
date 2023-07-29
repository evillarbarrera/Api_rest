using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MyApi.Data;


namespace MyApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 33)), // Ajusta la versión según tu servidor MySQL
                    mySqlOptions =>
                    {
                        // Opcional: Puedes configurar otras opciones de MySQL aquí si es necesario
                    }));
                
            // Otros servicios que puedas necesitar
            // Ejemplo: services.AddScoped<IItemRepository, ItemRepository>();

            services.AddControllers();
        }

    }

   

}
