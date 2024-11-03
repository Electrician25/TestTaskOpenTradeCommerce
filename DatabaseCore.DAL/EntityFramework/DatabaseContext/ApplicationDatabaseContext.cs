using DatabaseCore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCore.DAL.EntityFramework.DatabaseContext
{
    public class ApplicationDatabaseContext : DbContext
    {
        public required DbSet<Translation> Translations { get; set; }

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}