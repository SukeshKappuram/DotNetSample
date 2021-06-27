using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Sample2
    {
        int num1, num2 = 2;


        int Add()
        {
            return num1 + num2;
        }

        void Create()
        {
            Student s1 = new Student(201,"Ravi",78.3f);
            s1.DisplayDetails();

            Student s2 = new Student(301,"Raju",83.5f);
            s2.DisplayDetails();

            Student s3 = new Student();
            s3.DisplayDetails();

            //Sample2 s,s1,s2;
            //s = new Sample2();  // reference Type

            //s1 = new Sample2();  // reference Type

            //s2 = s1;


            //Console.WriteLine(s);
            //Console.WriteLine(s.num1);
            //Console.WriteLine(s.num2);
            //s.num2 = 4;
            //Console.WriteLine(s.num1);
            //Console.WriteLine(s.num2);

            //Console.WriteLine(s1);
            //Console.WriteLine(s1.num1);
            //Console.WriteLine(s1.num2);
            //s1.num1 = 8;
            //s1.num2 = 6;
            //Console.WriteLine(s1.num1);
            //Console.WriteLine(s1.num2);


            //Console.WriteLine(s2.num1);
            //Console.WriteLine(s2.num2);
            //s2.num2 = 360;

            //Console.WriteLine(s1.num2);
            //Console.WriteLine(s2.num2);
            Console.ReadLine();

        }
    }
}
