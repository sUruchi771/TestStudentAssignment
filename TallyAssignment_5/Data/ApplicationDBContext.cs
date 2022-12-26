using Microsoft.EntityFrameworkCore;
using TallyAssignment_5.Models;


namespace TallyAssignment5.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
