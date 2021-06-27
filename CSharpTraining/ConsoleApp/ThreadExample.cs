using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    class ThreadExample
    {
        public delegate void display(int i);

        public event display myevent;

        public static void Process1()
        {
            for (int i = 0; i < 20; i++)
            {
                //Thread.Sleep(1000);
                Console.WriteLine("Process 1 running {0}", i);
            }
        }

        public static void Process2()
        {
            for (int i = 0; i < 20; i++)
            {
                //Thread.Sleep(1000);
                Console.WriteLine("Process 2 running {0}", i);
            }
        }

        public static void Process3()
        {
            try
            {
                Console.WriteLine("Child thread starts");

                for (int i = 0; i <= 10; i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(i);
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        public void square(int x)
        {
            Console.WriteLine(x * x);
        }

        public void sum(int x)
        {
            Console.WriteLine(x + x);
        }

        public void start()
        {
            display d1 = new display(square);
            display d2 = new display(sum);

            d1(2);
            d2(2);

            display d;

            d = d1;
            d += d2;

            d(2);

            myevent = new display(square);
        }
    }
}
