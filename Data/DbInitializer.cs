
using Microsoft.EntityFrameworkCore;
using lab1.models;

namespace lab1.data;

public class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
        {
            context.Database.EnsureCreated();

            // Check majors 
            if (!context.Majors.Any())
            {
                var majors = new Major[]
                {
                new Major { MajorName = "IT" },
                new Major { MajorName = "Economics" },
                new Major { MajorName = "Mathematics" }
                };

                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();
            }

            // Check learners
            if (!context.Learners.Any())
            {
                var learners = new Learner[]
                                {
                new Learner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                new Learner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                                };

                foreach (Learner l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();
            }

            // Check courses
            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();
            }

            // Check enrollments
            if (!context.Enrollments.Any())
            {
                var enrollments = new Enrollment[]
                {
                    new Enrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new Enrollment { LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                    new Enrollment { LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                    new Enrollment { LearnerID = 2, CourseID = 4041, Grade = 7f }
                };

                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }

            // Check students
            if (!context.Students.Any())
            {
                var students = new Student[] {
                    new Student() {
                        Id = 1,
                        Name = "Ly Tran Vinh",
                        Branch = Branch.IT,
                        Gender = Gender.Male,
                        IsRegular = true,
                        Address = "Ha Noi",
                        Email = "lytranvinh.work@gmail.com",
                        Point = 9.8,
                        DateOfBirth = new DateTime(2004, 9, 25)
                    },
                    new Student() {
                        Id = 101,
                        Name = "Hai Nam",
                        Branch = Branch.IT,
                        Gender = Gender.Male,
                        IsRegular = true,
                        Address = "A1-2018",
                        Email = "nam@gmail.com",
                        Point = 5.5
                    },
                    new Student() {
                        Id = 102,
                        Name = "Minh Tu",
                        Branch = Branch.BE,
                        Gender = Gender.Female,
                        IsRegular = true,
                        Address = "A1-2019",
                        Email = "tu@gmail.com",
                        Point = 7.5
                    },
                    new Student() {
                        Id = 103,
                        Name = "Hoang Phong",
                        Branch = Branch.CE,
                        Gender = Gender.Male,
                        IsRegular = false,
                        Address = "A1-2020",
                        Email = "phong@gmail.com",
                        Point = 4
                    },
                    new Student() {
                        Id = 104,
                        Name = "Xuan Mai",
                        Branch = Branch.EE,
                        Gender = Gender.Female,
                        IsRegular = false,
                        Address = "A1-2021",
                        Email = "mai@gmail.com",
                        Point = 8.5
                    },
                    new Student() {
                        Id = 105,
                        Name = "Hai Yen",
                        Branch = Branch.IT,
                        Gender = Gender.Female,
                        IsRegular = true,
                        Address = "A1-2022",
                        Email = "yenh@gmail.com",
                        Point = 6.5
                    }
                };

                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();
            }
            
        }
    }
}