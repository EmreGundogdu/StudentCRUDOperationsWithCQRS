using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(){Age =21, Name ="Emre",Id=1,Surname="Gündoğdu"},
                new Student(){Age =18, Name ="Mert",Id=2,Surname="Akar"}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
