using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer
{
    public class CompanyMangementDbcontext : DbContext
    {

        public CompanyMangementDbcontext(DbContextOptions<CompanyMangementDbcontext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet <Employee> Employees { get; set; }
    
    
    
    }
}
