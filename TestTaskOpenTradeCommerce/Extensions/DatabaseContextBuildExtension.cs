using DatabaseCore.DAL.EntityFramework.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace TestTaskOpenTradeCommerce.Extensions
{
    public static class DatabaseContextBuildExtension
    {
        public static WebApplicationBuilder AddDatabaseContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDatabaseContext>(options
                    => options.UseNpgsql(connectionString));

            return builder;
        }
    }
}