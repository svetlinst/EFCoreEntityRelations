using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext:DbContext
    {

        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigStudentModel(modelBuilder);
            ConfingCourseModel(modelBuilder);
            ConfigResourceModel(modelBuilder);
            ConfigHomeworkModel(modelBuilder);
            ConfigStudentCourseModel(modelBuilder);

            SeedCourses(modelBuilder);

            SeedStudents(modelBuilder); 
        }

        private void SeedCourses(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>(entity => 
                {
                    entity.HasData(new Course()
                    {
                        CourseId = 1,
                        Name = "C++",
                        Description = "Microsoft",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(30),
                        Price = 100m
                    });
                });
        }

        private void SeedStudents(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>(entity => 
                {
                    entity.HasData(
                        new Student() {
                            StudentId = 1,
                            Name = "Pesho",
                            PhoneNumber = "0123456789",
                            RegisteredOn = DateTime.Now
                        },
                        new Student()
                        {
                            StudentId = 2,
                            Name = "Gosho",
                            PhoneNumber = "0123456789",
                            RegisteredOn = DateTime.Now.AddDays(1)
                        }
                        );
                });
        }

        private void ConfigStudentCourseModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(x => new
                {
                    x.StudentId,
                    x.CourseId
                });

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(x=>x.StudentId);

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(x => x.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(x=>x.CourseId);
        }

        private void ConfigHomeworkModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homework>()
                .HasKey(x => x.HomeworkId);

            modelBuilder
                .Entity<Homework>()
                .Property(x => x.Content)
                .IsUnicode(false);
            modelBuilder
                .Entity<Homework>();
                //.ToTable("HomeworkSubmissions");
        }

        private void ConfigResourceModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>()
                .HasKey(x => x.ResourceId);

            modelBuilder
                .Entity<Resource>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
                .Entity<Resource>()
                .Property(x => x.Url)
                .IsUnicode(false);

            modelBuilder
                .Entity<Resource>()
                .HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(x => x.CourseId);

        }

        private void ConfingCourseModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .HasKey(x => x.CourseId);

            modelBuilder
                .Entity<Course>()
                .Property(x => x.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

            modelBuilder
                .Entity<Course>()
                .Property(x => x.Description)
                .IsUnicode(true)
                .IsRequired(false);

            modelBuilder
                .Entity<Course>()
                .HasMany(h => h.HomeworkSubmissions)
                .WithOne(c => c.Course)
                .HasForeignKey(x => x.CourseId);
        }

        private void ConfigStudentModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasKey(x => x.StudentId);

            modelBuilder
                .Entity<Student>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder
                .Entity<Student>()
                .Property(x => x.PhoneNumber)
                .IsUnicode(false)
                .IsRequired(false)
                .HasMaxLength(10)
                .IsFixedLength();

            modelBuilder
                .Entity<Student>()
                .Property(x => x.Birthday)
                .IsRequired(false);

            modelBuilder
                .Entity<Student>()
                .HasMany(h => h.HomeworkSubmissions)
                .WithOne(s => s.Student);
        }


    }
}
