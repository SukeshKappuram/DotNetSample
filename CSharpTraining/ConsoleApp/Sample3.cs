using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    // Program to find if a given number is prime or not
    class Sample3
    {
        public bool IsPrime(int n)//8
        {
            int counter = 0;
            for (int i = 1; i <= n; i++)     //while(i <=n){
            {
                if (n % i == 0)
                {
                    counter += 1; // counter++ // counter + 1

                    if (counter > 2)
                    {
                        break;
                    }
                }
            }

            if (counter == 2)
            {
                return true;
            }

            return false;
        }

        int GetLargest(int num1, int num2, int num3)
        {
            if (num1 > num2 && num1 > num3)
            {
                return num1;
            }
            else if (num2 > num3)
            {
                return num2;
            }
            else
            {
                return num3;
            }
        }

        public int calculate(int num1,int num2, char operatr)
        {
            int result = 0;
            switch (operatr)
            {
                case '+': result = num1 + num2;
                    break;
                case '-': result = num1 - num2;
                    break;
                case '*': result = num1 * num2;
                    break;
                case '/': result = num1 / num2;
                    break;
                case '%': result = num1 % num2;
                    break;
                default: result = 0;
                    break;
            }

            return result;
        }

        //

        public void CreateArray()
        {
            string[] names = {"Laxman","Ravi","Jagdish","Rajesh"};
            int[] numbers = {10, 20, 30, 40};

            int[] primeNumbers = new int[10];

            primeNumbers[0] = 3;

            primeNumbers[5] = 9;

            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}

            //Array.Sort(names);


            //foreach (string i in names)
            //{
            //    Console.WriteLine(i);
            //}

            //int[,] points = new int[5,5];
            //Console.WriteLine("Enter Array elements");

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.WriteLine("Enter element at {0},{1}",i,j);
            //        points[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //Console.WriteLine("foreach");//readable
            //foreach (int i in points)
            //{
            //    Console.WriteLine(i);
            //}
        }

        public void GetStudentMarks()
        {
            string[] names = new string[3];
            string[] subjects = new string[3];
            int[,] marks = new int[3, 3];

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Enter Name for Student {0}", (i+1));
                names[i] = Console.ReadLine();
            }

            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine("Enter Name for Subject {0}", (i+1));
                subjects[i] = Console.ReadLine();
            }

            for (int i = 0; i < names.Length; i++)
            {
                for (int j = 0; j < subjects.Length; j++)
                {
                    Console.WriteLine("Enter the marks of {0} in {1}", names[i],subjects[j]);
                    marks[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            int[,,] n = new int[3,2,5];
        }

    }
}
