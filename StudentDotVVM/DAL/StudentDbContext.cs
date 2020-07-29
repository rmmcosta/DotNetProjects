using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentDotVVM.DAL.Entities;
namespace StudentDotVVM.DAL
{
    public class StudentDbContext : IdentityDbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
    }
}
