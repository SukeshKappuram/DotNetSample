using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class StaticExample
    {
        public static int x;
        public int y;

        public void display()
        {
            Console.WriteLine("X value is {0}, Y value is {1}",StaticExample.x,y);
        }

        static void Details()
        {
            Console.WriteLine(StaticExample.x);
        }
    }
}
