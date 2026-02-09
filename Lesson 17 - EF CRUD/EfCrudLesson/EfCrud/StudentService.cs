using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCrud
{
    
    internal class StudentService
    {
        
        public void CreateExample(SchoolContext db)
        {
            if (!db.Courses.Any() && !db.Students.Any())
            {
                var course = new Course { Code = "SDEV2301", Name = "Enterprise App Dev", Credits = 3 };
                db.Courses.Add(course);

                db.Students.AddRange(
                    new Student { Name = "Alice", Age = 20, Course = course },
                    new Student { Name = "Bob", Age = 22, Course = course },
                    new Student { Name = "Cara", Age = 19, Course = course }
                );

                // Make sure to call SaveChanges() so that our database updates.
                db.SaveChanges();
            }
        }
        public void ReadExample(SchoolContext db)
        {
            // Use Include() to make sure all of the child records are included in the results.
            var loadedCourse = db.Courses
                                 .Include(c => c.Students)
                                 .Single(c => c.Code == "SDEV2301");

            Console.WriteLine($"\nREAD: {loadedCourse.Code} - {loadedCourse.Name} ({loadedCourse.Credits} credits)");
            foreach (var s in loadedCourse.Students)
                Console.WriteLine($" - Student #{s.Id}: {s.Name} (Age {s.Age})");
        }
        public void UpdateExample(SchoolContext db)
        {
            var loadedCourse = db.Courses
                                 .Include(c => c.Students)
                                 .Single(c => c.Code == "SDEV2301");

            loadedCourse.Credits = 4; // update parent
            var bob = loadedCourse.Students.Single(s => s.Name == "Bob");
            bob.Age = 23;             // update child
            db.SaveChanges();

            var check = db.Courses.Include(c => c.Students).Single(c => c.Id == loadedCourse.Id);
            Console.WriteLine($"Confirm: {check.Code} now {check.Credits} credits;");

            var student = db.Students.Single(s => s.Name == "Bob");
            Console.WriteLine($"Confirm: {student.Name} is {student.Age} years old;");
        }
        public void DeleteExample(SchoolContext db)
        {
            var loadedCourse = db.Courses
                                 .Include(c => c.Students)
                                 .Single(c => c.Code == "SDEV2301");
            var cara = loadedCourse.Students.Single(s => s.Name == "Cara");
            db.Students.Remove(cara);
            db.SaveChanges();

            foreach (var s in db.Students)
                Console.WriteLine($" - Student #{s.Id}: {s.Name} (Age {s.Age})");

            db.Courses.Remove(loadedCourse);
            db.SaveChanges();
            Console.WriteLine("DELETE: Removed course (cascade deleted remaining students).");
        }
    }
}
