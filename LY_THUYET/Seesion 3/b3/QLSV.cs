using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class Student
    {
        string name;
        string id;
        double score;

        public void Input()
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("Enter ID: ");
            id = Console.ReadLine();

            Console.Write("Enter score: ");
            score = double.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Score: " + score);
        }

        public double GetScore()
        {
            return score;
        }
    }
    class StudentList
    {
        List<Student> students;

        public StudentList()
        {
            students = new List<Student>();
        }

        public void AddStudent()
        {
            Student student = new Student();
            student.Input();
            students.Add(student);
        }

        public void OutputStudents()
        {
            foreach (Student student in students)
            {
                student.Output();
            }
        }

        public void GetAverageScore()
        {
            double totalScore = 0;
            foreach (Student student in students)
            {
                totalScore += student.GetScore();
            }

            double averageScore = totalScore / students.Count;
            Console.WriteLine("Average score: " + averageScore);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();

            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter information for student " + (i + 1));
                studentList.AddStudent();
            }

            Console.WriteLine("List of students:");
            studentList.OutputStudents();

            studentList.GetAverageScore();

            Console.ReadLine();
        }
    }


}