using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkDemo.Data
{
    //applicationdbcontext --child class Dbcontext-parent class of ef
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
          public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Stud { get; set; }

        public DbSet<Book> Bk { get; set; }

        public DbSet<Product> pdt { get; set; }

    }
}
