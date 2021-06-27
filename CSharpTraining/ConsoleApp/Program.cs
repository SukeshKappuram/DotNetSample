using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleApp
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your name");
            //string username = Console.ReadLine();

            //Console.WriteLine("Enter your rank");
            //int rank = Convert.ToInt32(Console.ReadLine()); //string

            //Console.WriteLine("Enter your Avg.");
            //double battingAvg = Convert.ToDouble(Console.ReadLine());


            //Console.WriteLine("Name : {0}, Avg.:{2}, Rank: {1},", username,rank,battingAvg);

            //int n = 0;
            //do
            //{
            //    Console.WriteLine("Enter A number");
            //    n = Convert.ToInt32(Console.ReadLine());
            //   Sample3 s = new Sample3();
            //    Console.WriteLine(s.IsPrime(n) ? "Prime" : "Not Prime");
            //} while (n != 0);

            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //char c = Console.ReadLine().ToCharArray()[0];

            //Console.WriteLine(s.calculate(a, b, c));
            //s.CreateArray();
            //s.GetStudentMarks();


            //Television tv = new Television(20);

            //SmartTelevision stv = new SmartTelevision(300);

            //Calculator c = new Calculator();
            //Console.WriteLine(c.add());
            //Console.WriteLine(c.add(3));
            //Console.WriteLine(c.add(5, 3));
            //Console.WriteLine(c.add(num2:3, num1:5));// Named
            //Console.WriteLine(c.add(2, 3));
            //Console.WriteLine(c.add(2, 3,5));
            //Console.WriteLine(c.add(2, 3.5f));
            //Console.WriteLine(c.add(2.3f, 5));
            //Console.WriteLine(c.add(6.2f, 3.5f));



            //Console.WriteLine("=======================");

            //IElectronicDevice ed = new Television();

            //ed.turnOn();
            //Console.WriteLine("Ed Type "+ed.GetType());



            //Television tv = (Television)ed;

            //Console.WriteLine(tv);

            //Console.WriteLine(tv.ToString());

            //IElectronicDevice ed2 = tv;

            //Console.WriteLine(tv.Equals(ed)); // value
            //Console.WriteLine(tv == ed);// Memory 

            //tv.turnOn();
            //tv.changeChannel();

            //Console.WriteLine("=======================");
            //ed = new Mobile();
            //Mobile m = (Mobile)ed;


            //Console.WriteLine(tv.Equals(ed));

            //Console.WriteLine(tv);
            //Console.WriteLine(tv.ToString());
            //Console.WriteLine(tv.GetHashCode());
            //Console.WriteLine(m.GetHashCode());


            //Console.WriteLine("=======================");
            //String str1 = new String("Hello");
            //String str2 = new String("Hello");
            //String str3 = str2;

            //Console.WriteLine(str3.Equals(str2));
            //Console.WriteLine(str1 == str3);

            //String s1 = "Hello";
            //String s2 = "Hello";
            //Console.WriteLine(s1.Equals(s2));
            //Console.WriteLine(s1 == s2);

            //Console.WriteLine("=======================");

            //Console.WriteLine(str1.GetHashCode());
            //Console.WriteLine(str2.GetHashCode());

            //Console.WriteLine(str2.GetType());
            //Console.WriteLine(m.GetType());

            //m.turnOn();

            //Console.WriteLine("=======================");

            //SmartTelevision smt = new SmartTelevision();
            //smt.turnOn();
            //smt.changeChannel();
            //smt.BrowseInternet();



            //Television tv1 = new Television();
            //tv1.Equals()


            //StaticExample s1 = new StaticExample();

            //StaticExample s2 = new StaticExample();

            //StaticExample s3 = new StaticExample();


            //s1.display();
            //s2.display();
            //s3.display();

            //StaticExample.x++;
            //s1.y++;
            //s1.display();


            //StaticExample.x++;
            //s2.y++;
            //s2.display();

            //StaticExample.x++;
            //s3.y++;


            //s3.display();

            //FileExample fe = new FileExample();
            //fe.Serialization();

            //fe.Deserialization();
            


            //ThreadStart ts1 = new ThreadStart(ThreadExample.Process1);  // Runnable
            //ThreadStart ts2 = new ThreadStart(ThreadExample.Process2);
            //Thread t1 = new Thread(ts1); //run
            //Thread t2 = new Thread(ts2); //run
            //t1.Priority = ThreadPriority.Lowest;
            //t1.Priority = ThreadPriority.Highest;
            ////t1.Start();
            //t2.Start();

            //for (int i = 0; i < 10; i++)
            //{
            //    //Thread.Sleep(1000);
            //    Console.WriteLine("Main Thread running {0}", i);
            //}

            //Console.WriteLine("Program Completed");
            ////ThreadExample.display();


            //ThreadStart childref = new ThreadStart(ThreadExample.Process3);
            //Console.WriteLine("In Main: Creating the Child thread");

            //Thread childThread = new Thread(childref);
            //childThread.Start();  // 0 1 2 3 

            ////stop the main thread for some time
            //Thread.Sleep(2000);

            ////now abort the child
            //Console.WriteLine("In Main: Aborting the Child thread");

            //childThread.Abort();


            //string str = "Delhi is 400 km away";
            //string pattern = "[kcm][m]";

            //Regex regex = new Regex(pattern);
            //Console.WriteLine(regex.Replace(str,"miles"));


            AdoExample ado = new AdoExample();
            //Product p = new Product()
            //{
            //    ProductName = "Mobile",
            //    ProductPrice = 39999.0,
            //    Description = "Smart Mobile"
            //};
            //ado.UpdateProduct(p);

            ado.getData();


            Console.ReadLine();
        }
    }
}
