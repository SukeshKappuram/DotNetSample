using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    interface IElectronicDevice
    {
        void turnOn();

        void turnOff();
    }

    interface IDevice: IElectronicDevice
    {
        
    }

    class Television: IElectronicDevice //includes all public function of ED (base class)
    {
        public Television()
        {
            
            Console.WriteLine("Television Default Constructor");
        }

        public Television(int x)
        {
            Console.WriteLine("Television Default Constructor");
        }

        public String ToString()
        {
            return "This is a object";
        }


        public String GetHashCode()
        {
            return "This is a object";
        }


        public void turnOn()
        {
            Console.WriteLine("Television is turned On");
        }

        public void turnOff()
        {
            Console.WriteLine("Television is turned Off");
        }

        public virtual void changeChannel()
        {
        }
        
    }

    class Mobile : IDevice
    {
        public Mobile()
        {
            
        }

        public void turnOff()
        {
            Console.WriteLine("Mobile is turned Off");
        }

        public void turnOn()
        {
            Console.WriteLine("Mobile is turned On {0}");
        }

        public void BrowseInternet(int i)
        {

        }
    }

    class SmartTelevision : Television, IInternet
    {
        public SmartTelevision(){}
        public SmartTelevision(int y) : base(y)
        {
            Console.WriteLine("Smart Television Constructor, Value {0}", y);
        }

        

        public override void changeChannel()
        {
            Console.WriteLine("Smart Television Channel Changed");
        }

        public void BrowseInternet()
        {
            Console.WriteLine("Open www.google.com");
        }

        public void BrowseInternet(int i)
        {
            
        }
    }

    interface IInternet
    {
        void BrowseInternet(int i);
    }
}
