using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class ExceptionHandling
    {
        private int ProductId;
        private string ProductName;
        private float price;

        public void Input()
        {
            string inp = "";
            try
            {
                Console.WriteLine("Enter a Product Id");
                ProductId = Convert.ToInt32(Console.ReadLine()); //0
                if (ProductId == 0)
                {
                    throw new FormatException();
                }

                Console.WriteLine("Enter a Product Name");
                ProductName = Console.ReadLine();
                if (ProductName.Contains("@"))
                {
                    throw new System.Exception("Invalid product name");
                }

                Console.WriteLine("Enter a Price");
                price = (float) Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException e)
            {
                if (ProductId == 0)
                {
                    Console.WriteLine("Enter valid product Id");
                }
                else
                {
                    Console.WriteLine("Enter valid product price");
                }

                Console.WriteLine(e.Message);
                Input();
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e.Message);
                Input();
            }
            finally
            {
                Console.WriteLine("Program Completed");
            }
        }
    }

    class ValidationException : System.Exception
    {
        public ValidationException(string message):base(message)
        {
            
        }
    }
}
