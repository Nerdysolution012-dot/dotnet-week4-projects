using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Student_Management_System
{
    internal class Program
    {
        static List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "John Doe",
                Grade = 100,
                EnrollMentStatus = true,
                NumberOfStudents = 30
            },
            new Student()
            {
                Id = 2,
                Name = "Daniel Ipeka",
                Grade = 50,
                EnrollMentStatus = true,
                NumberOfStudents = 130
            },
            new Student()
            {
                Id = 3,
                Name = "Kelvin Night",
                Grade = 60,
                EnrollMentStatus = true,
                NumberOfStudents = 230
            },
            new Student()
            {
                Id = 4,
                Name = "Okocha kanu",
                Grade = 40,
                EnrollMentStatus = true,
                NumberOfStudents = 30
            },
            new Student()
            {
                Id = 5,
                Name = "Ronald Messi",
                Grade = 20,
                EnrollMentStatus = true,
                NumberOfStudents = 40
            },
        };
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine(
         @"=== Student Management System ===
           1. Add New Student
           2. View All Students
           3. Calculate Average Grade
           4. Find Student by ID
           5. Update Student Grade
           6. Delete Student
           7. Display Statistics
           8. Exit");

                Console.WriteLine("*****************************************");
                Console.WriteLine("*****************************************");
                Console.WriteLine("*****************************************");


                Console.Write("Enter your choice: ");
                userInput = Console.ReadLine();
                Console.WriteLine("*****************************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();



                switch (userInput)
                {
                    case "1":
                        AddNewStudent();
                        break;

                    case "2":
                        ViewAllStudents();
                        break;

                    case "3":
                        CalculateAverageGrade();
                        break;

                    case "4":
                        FindStudentByid();
                        break;

                    case "5":
                        UpdateStudentGrade();
                        break;

                    case "6":
                        DeleteStudent();
                        break;
                }

                Console.WriteLine("*****************************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            } while (userInput != "exit");


        }

        static void AddNewStudent()
        {
            try
            {
                Console.WriteLine("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Student Grade: ");
                double grade = double.Parse(Console.ReadLine());

                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Grade must be between 0 and 100.");
                    return;
                }


                students.Add(new Student()
                {
                    Id = id,
                    Name = name,
                    Grade = grade,
                });
                Console.WriteLine("Student added successfully!");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        static void ViewAllStudents()
        {
            Console.WriteLine("=== All Students ===");


            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10}", "ID", "Name", "Grade", "Status");
            Console.WriteLine("-------------------------------------------------------------");

            // Print each student row
            foreach (var student in students)
            {

                string status = (student.Grade >= 60) ? "Pass" : "Fail";

                Console.WriteLine("{0,-5} | {1,-20} | {2,-10:F2} | {3,-10}",

                 student.Id, student.Name, student.Grade, status);
            }
        }

        static void CalculateAverageGrade()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available to calculate average grade.");
                return;
            }
            double totalGrade = 0;
            foreach (var student in students)
            {
                totalGrade += student.Grade;
            }
            double averageGrade = totalGrade / students.Count;
            Console.WriteLine($"Average Grade: {averageGrade:F2}");
        }

        static void FindStudentByid()
        {
            Console.WriteLine("Enter your student id");

            try
            {
                int id = int.Parse(Console.ReadLine());

                foreach (var student in students)
                {
                    if (id==4 &&  student.Id == id )
                    {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10}", "ID", "Name", "Grade", "Status");
                        Console.WriteLine("-------------------------------------------------------------");

                        string status = (student.Grade >= 60) ? "Pass" : "Fail";

                        Console.WriteLine("{0,-5} | {1,-20} | {2,-10:F2} | {3,-10}",

                            student.Id, student.Name, student.Grade, status);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding student: {ex.Message}");
            }

        }

        static void UpdateStudentGrade()
        {
            Console.WriteLine("Enter Student ID to update grade: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    Console.WriteLine("Enter new grade: ");
                    double newGrade = double.Parse(Console.ReadLine());
                    if (newGrade < 0 || newGrade > 100)
                    {
                        Console.WriteLine("Grade must be between 0 and 100.");
                        return;
                    }
                    student.Grade = newGrade;
                    Console.WriteLine("Student grade updated successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student grade: {ex.Message}");
            }
        }

        static void DeleteStudent()
        {
            Console.WriteLine("Enter Student ID to delete: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine("Student deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
            }
        }   
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Grade { get; set; }
            public bool EnrollMentStatus { get; set; }
            public int NumberOfStudents { get; set; }


        };

    }
}