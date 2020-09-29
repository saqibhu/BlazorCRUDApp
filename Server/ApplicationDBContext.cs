using Microsoft.EntityFrameworkCore;
using BlazerCRUDApp.Shared.Models;

namespace BlazorCRUDApp.Server {
    public class ApplicationDBContext : DbContext {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }
    }
}