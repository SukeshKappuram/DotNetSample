using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    //Over Loading
    class Calculator
    {
        public int num1 { get; set; }
        public int num2 { get; set; }

        public int add()
        {
            return num1 + num2;
        }

        public int add(int num1)
        {
            Console.WriteLine("Add(1) => Num1 ={0} , Num2 = {1}", num1, num2);
            return num1;
        }

        public int add(int num1, int num2 = 5)// Optional
        {
            Console.WriteLine("Add(1,o) =>  Num1 ={0} , Num2 = {1}", num1,num2);
            return num1 + num2;
        }

        public int add(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        public float add(float num1, float num2)
        {
            return (num1 + num2);
        }

        public float add(float num1, int num2)
        {
            return (num1 + num2);
        }

        public float add(int num1, float num2)
        {
            return (num1 + num2);
        }
    }
}
