using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData
{
        public class Student
        {
            public string Name { get; set; }
            public string ClassAndSection { get; set; }
        }

        public class Teacher
        {
            public string Name { get; set; }
            public string ClassAndSection { get; set; }
        }

        public class Subject
        {
            public string Name { get; set; }
            public string SubjectCode { get; set; }
            public Teacher Teacher { get; set; }
        }

        public class SchoolSystem
        {
            public List<Student> students = new List<Student>();
            public List<Teacher> teachers = new List<Teacher>();
            public List<Subject> subjects = new List<Subject>();

            public void AddStudent(string name, string classAndSection)
            {
                Student student = new Student
                {
                    Name = name,
                    ClassAndSection = classAndSection
                };
                students.Add(student);
            }

            public void AddTeacher(string name, string classAndSection)
            {
                Teacher teacher = new Teacher
                {
                    Name = name,
                    ClassAndSection = classAndSection
                };
                teachers.Add(teacher);
            }

            public void AddSubject(string name, string subjectCode, Teacher teacher)
            {
                Subject subject = new Subject
                {
                    Name = name,
                    SubjectCode = subjectCode,
                    Teacher = teacher
                };
                subjects.Add(subject);
            }

            public void DisplayStudentsInClass(string classAndSection)
            {
                var studentsInClass = students.Where(student => student.ClassAndSection == classAndSection);
                Console.WriteLine("Students in Class " + classAndSection + ":");
                foreach (var student in studentsInClass)
                {
                    Console.WriteLine(student.Name);
                }
            }

            public void DisplayTeachersWithSubjects()
            {
                Console.WriteLine("Teachers and Subjects Taught:");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine("Teacher: " + teacher.Name);
                    Console.WriteLine("Class and Section: " + teacher.ClassAndSection);
                    Console.WriteLine("Subjects Taught:");
                    var subjectsTaught = subjects.Where(subject => subject.Teacher == teacher);
                    foreach (var subject in subjectsTaught)
                    {
                        Console.WriteLine("- " + subject.Name);
                    }
                }
            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("---------------Rainbow School Data--------------------");
                SchoolSystem school = new SchoolSystem();

                // Adding students
                school.AddStudent("Williams", "Class A");
                school.AddStudent("Henry", "Class A");
                school.AddStudent("Antony", "Class B");
                school.AddStudent("Waston", "Class B");

                // Adding teachers
                school.AddTeacher("Mr. James", "Class A");
                school.AddTeacher("Mrs. Andrew", "Class B");

                // Adding subjects
                Teacher teacher1 = school.teachers.Find(teacher => teacher.Name == "Mr. James");
                Teacher teacher2 = school.teachers.Find(teacher => teacher.Name == "Mrs. Andrew");

                school.AddSubject("Math", "MATH101", teacher1);
                school.AddSubject("History", "HIST101", teacher2);
                school.AddSubject("Science", "SCI101", teacher1);

                // Display students in a class
                school.DisplayStudentsInClass("Class A");
                school.DisplayStudentsInClass("Class B");

                // Display teachers with subjects
                school.DisplayTeachersWithSubjects();
            }
        }
    }


