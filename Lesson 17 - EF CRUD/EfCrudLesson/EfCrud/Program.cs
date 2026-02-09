using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EfCrud
{
    public class Course
    {
        public int Id { get; set; }                
        public string Code { get; set; } = "";      
        public string Name { get; set; } = "";     
        public int Credits { get; set; } = 3;

        // Navigation: one-to-many
        public List<Student> Students { get; set; } = new();
    }

    public class Student
    {
        public int Id { get; set; }                
        public string Name { get; set; } = "";
        public int Age { get; set; }

        // FK + Navigation back to Course
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "app.db");
            dbPath = Path.GetFullPath(dbPath);

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(b =>
            {
                b.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(b =>
            {
                b.Property(c => c.Code).IsRequired().HasMaxLength(20);
                b.Property(c => c.Name).IsRequired().HasMaxLength(100);
                b.HasMany(c => c.Students)
                 .WithOne(s => s.Course!)
                 .HasForeignKey(s => s.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using var db = new SchoolContext();
            // Add the Database.Migrate() call to migrate any changes made to our models.
            db.Database.Migrate();

            // Service class to handle database operations.
            StudentService service = new StudentService();

            // CREATE
            service.CreateExample(db);

            // READ
            service.ReadExample(db);

            // UPDATE
            service.UpdateExample(db);

            // DELETE
            service.DeleteExample(db);
        }

        
    }
}
