using CrudNET8MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNET8MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Add your models here to create tables in the database
        public DbSet<People> People { get; set; }

    }
}
