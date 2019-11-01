using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace pppppppp
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("D:/Uni/BSE-5/VP/Assignments/Students.txt", String.Empty);
            Student obj = new Student();
            char exitChoice;
            String searchId;
            String delId;
            String searchName;
            int choice;
            do
            {
                Console.Clear();
                String name, semester, cgpa, department, university, id;
                Console.WriteLine("Press 1 to add student.");
                Console.WriteLine("Press 2 to search for student. ");
                Console.WriteLine("Press 3 to delete a record of a student. ");
                Console.WriteLine("Press 4 to check top 3 students.");
                Console.WriteLine("Press 5 to mark attendence.");
                Console.WriteLine("Press 6 to view attendence");
                Console.WriteLine("\t\t\t Enter your choice  ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1) //add Student
                {
                    Console.Clear();
                    Console.Write("Enter the Name Of Student:      ");
                    name = Convert.ToString(Console.ReadLine());
                    Console.Write("Enter the semester of student:  ");
                    semester = Convert.ToString(Console.ReadLine());
                    Console.Write("Enter the cgpa of student:      ");
                    cgpa = Convert.ToString(Console.ReadLine());
                    Console.Write("Enter the department of student: ");
                    department = Convert.ToString(Console.ReadLine());
                    Console.Write("Enter the university of student: ");
                    university = Convert.ToString(Console.ReadLine());
                    id = obj.setId();
                    obj.addStudent(name, semester, cgpa, department, university, id);

                }
                else if (choice == 2)  // search Student
                {
                    Console.Clear();
                    int searchChoice;
                    Console.Write("press 1 for search by id.\n");
                    Console.Write("press 2 for search by name.\n");
                    Console.Write("enter choice\n");
                    searchChoice = Convert.ToInt32(Console.ReadLine());
                    if (searchChoice == 1)  // search by id
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Id of Student.");
                        searchId = Convert.ToString(Console.ReadLine());
                        obj.searchById(searchId);
                    }
                    else if (searchChoice == 2)  // search by name
                    {
                        Console.Clear();
                        Console.WriteLine("Enter The Name Of Student");
                        searchName = Convert.ToString(Console.ReadLine());
                        obj.searchByName(searchName);
                    }
                    else   //wrong input
                    {
                        Console.WriteLine("Wrong Input");
                        break;
                    }
                }
                else if (choice == 3) //delete
                {
                    Console.Clear();
                    Console.WriteLine("Enter id of Student.");
                    delId = Convert.ToString(Console.ReadLine());
                    obj.deleteStudent(delId);

                }
                else if (choice == 4)  // top 3
                {
                    Console.Clear();
                    obj.displayTopThree();
                }
                else if (choice == 5) //mark attendence
                {
                    Console.Clear();
                    Console.WriteLine("Write P for present and A for Absent");
                    obj.markAttendence();
                }
                else if (choice == 6)  // view attendence;
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tList of Students");
                    obj.viewAttendence();
                }
                else
                {
                    break;
                }
                Console.WriteLine("Want to do again: y/n");
                exitChoice = Convert.ToChar(Console.ReadLine());
            }
            while (exitChoice == 'y' || exitChoice == 'Y');
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }
    }
}
