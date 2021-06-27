using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    [Serializable]
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public float Marks { get; set; }

        public Student()
        {

        }

        public Student(int studentId, string studentName, float marks)
        {
            StudentId = studentId;
            StudentName = studentName;
            Marks = marks;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Student Id " + StudentId);
            Console.WriteLine("Student Name " + StudentName);
            Console.WriteLine("Student Marks " + Marks);
        }
    }
}
