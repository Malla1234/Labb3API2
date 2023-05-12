using Labb3API2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3API2.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
        
        public DbSet<Interest> interests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        
            
        
    }
}
