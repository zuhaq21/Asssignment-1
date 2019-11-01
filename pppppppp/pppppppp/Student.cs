using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pppppppp
{
    class Student
    {
        public void addStudent(String name, String semester, String cgpa, String department, String university, String id)
        {
            using (StreamWriter writetext = File.AppendText("D:/Uni/BSE-5/VP/Assignments/Students.txt"))
            {
                String attendence = "A";
                writetext.WriteLine(id);
                writetext.WriteLine(name);
                writetext.WriteLine(semester);
                writetext.WriteLine(cgpa);
                writetext.WriteLine(department);
                writetext.WriteLine(university);
                writetext.WriteLine(attendence);
            }
        }

        public string setId()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            var FormNumber = BitConverter.ToUInt32(buffer, 0) ^ BitConverter.ToUInt32(buffer, 4) ^ BitConverter.ToUInt32(buffer, 8) ^ BitConverter.ToUInt32(buffer, 12);
            return FormNumber.ToString("X");
        }

        public void deleteStudent(String id)
        {
            String[] arrText;
            List<String> newText = new List<String>();
            int found = 0;
            arrText = File.ReadAllLines("D:/Uni/BSE-5/VP/Assignments/Students.txt");
            for (int i = 0; i < arrText.Length; i = i + 7)
            {
                if (arrText[i] == id)
                {
                    found++;
                    continue;
                }
                else
                {
                    newText.Add(arrText[i]);
                    newText.Add(arrText[i + 1]);
                    newText.Add(arrText[i + 2]);
                    newText.Add(arrText[i + 3]);
                    newText.Add(arrText[i + 4]);
                    newText.Add(arrText[i + 5]);
                    newText.Add(arrText[i + 6]);
                }
            }
            if (found > 0)
            {
                Console.WriteLine("Record Deleted");
            }
            else
            {
                Console.WriteLine("Record not Found");
            }
            using (StreamWriter writetext = new StreamWriter("D:/Uni/BSE-5/VP/Assignments/Students.txt"))
            {
                for (int i = 0; i < arrText.Length - 7; i++)
                {
                    writetext.WriteLine(newText[i]);
                }
            }
        }
        public void searchById(String id)
        {
            string[] arrText;
            int found = 0;
            string[] studentData = new string[6];
            arrText = File.ReadAllLines("D:/Uni/BSE-5/VP/Assignments/Students.txt");
            for (int i = 0; i < arrText.Length; i = i + 7)
            {
                if (arrText[i] == id)
                {
                    Console.Clear();
                    Console.WriteLine("Id of Student is:          " + arrText[i]);
                    Console.WriteLine("Name of Student is:        " + arrText[i + 1]);
                    Console.WriteLine("Semester of Student is:    " + arrText[i + 2]);
                    Console.WriteLine("CGPA of Student is:        " + arrText[i + 3]);
                    Console.WriteLine("Department of Student is:  " + arrText[i + 4]);
                    Console.WriteLine("University of Student is:  " + arrText[i + 5]);
                    found++;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Student Not found by this Id.");
            }
        }
        public void searchByName(String Name)
        {
            string[] arrText;
            int found = 0;
            arrText = File.ReadAllLines("D:/Uni/BSE-5/VP/Assignments/Students.txt");
            Console.Clear();
            for (int i = 1; i < arrText.Length; i = i + 7)
            {
                if (arrText[i] == Name)
                {
                    Console.WriteLine("Id of Student is:          " + arrText[i - 1]);
                    Console.WriteLine("Name of Student is:        " + arrText[i]);
                    Console.WriteLine("Semester of Student is:    " + arrText[i + 1]);
                    Console.WriteLine("CGPA of Student is:        " + arrText[i + 2]);
                    Console.WriteLine("Department of Student is:  " + arrText[i + 3]);
                    Console.WriteLine("University of Student is:  " + arrText[i + 4]);
                    found++;
                }
                else
                {
                    continue;
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Student not founnd by This Name");
            }
        }
        public void displayTopThree()
        {
            String name1="";
            String id1="";
            String Cgpa1="";
            String name2="";
            String id2="";
            String Cgpa2="";
            String name3="";
            String id3="";
            String Cgpa3="";
            double max = 0;
            double max1 = 0;
            double max2 = 0;
            double max3 = 0;
            int lengthOfArray = 0;
            string[] arrText;
            arrText = File.ReadAllLines("D:/Uni/BSE-5/VP/Assignments/Students.txt");
  
            for (int i = 3; i < arrText.Length; i = i + 7)
            {
                max = Convert.ToDouble(arrText[i]);
                if (max > max1)
                {
                    max2 = max1;
                    name2 = name1;
                    id2 = id1;
                    max3 = max2;
                    name3 = name2;
                    id3 = id2;
                    max1 = max;
                    id1 = arrText[i - 3];
                    name1 = arrText[i - 2];
                }
                else if(max > max2)
                {
                    max3 = max2;
                    name3 = name2;
                    id3 = id2;
                    max2 = max;
                    id2 = arrText[i - 3];
                    name2 = arrText[i - 2];
                }
                else if (max > max3)
                {
                    max3 = max;
                    id3 = arrText[i - 3];
                    name3 = arrText[i - 2];
                }
            }
            Console.WriteLine("\t\t\t\t First Position");
            Console.WriteLine("Name of Sudent is :       " + name1);
            Console.WriteLine("Id of Sudent is :         " + id1);
            Console.WriteLine("CGPA of Sudent            " + max1);

            Console.WriteLine("\n\t\t\t\t Second Position");
            Console.WriteLine("Name of Sudent is :       " + name2);
            Console.WriteLine("Id of Sudent is :         " + id2);
            Console.WriteLine("CGPA of Sudent is :       " + max2);

            Console.WriteLine("\n\t\t\t\tThird Position");
            Console.WriteLine("Name of Sudent is :       " + name3);
            Console.WriteLine("Id of Sudent is :         " + id3);
            Console.WriteLine("CGPA of Sudent is :       " + max3);
        }
        public void markAttendence()
        {
            String[] arrText;
            String attendence;
            arrText = File.ReadAllLines("D:/Uni/BSE-5/VP/Assignments/Students.txt");
            for (int i = 0; i < arrText.Length; i = i + 7)
            {
                Console.WriteLine(arrText[i] + "\n" + arrText[i + 1]);
                attendence = Convert.ToString(Console.ReadLine());
                arrText[i + 6] = attendence;
            }
            using (StreamWriter writetext = new StreamWriter("D:/Uni/BSE-5/VP/Assignments/Students.txt"))
            {
                for (int i = 0; i < arrText.Length; i++)
                {
                    writetext.WriteLine(arrText[i]);
                }
            }
        }
        public void viewAttendence()
        {
            string[] arrText;
            arrText = File.ReadAllLines("D:/Uni/BSE-5/VP/Assignments/Students.txt");
            Console.WriteLine("array Length: " + arrText.Length);
            for (int i = 0; i < arrText.Length; i = i + 7)
            {
                Console.WriteLine("Id of Student is:          " + arrText[i]);
                Console.WriteLine("Name of Student is:        " + arrText[i + 1]);
                Console.WriteLine("Attendence:                " + arrText[i + 6]);
            }
        }
    }
}
