using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp
{
    class ShoppingCart
    {
        private List<Seller> sellers = new List<Seller>();
        private List<Product> products = new List<Product>();
        private List<ProductDetails> productdetails = new List<ProductDetails>();
        private List<CartItem> cart = new List<CartItem>();

        void start()
        {
            Console.WriteLine("Welcome to EKart");
            int ch = 0;
            do
            {
                Console.WriteLine(" Please select your choice");
                Console.WriteLine(" 1. Add Seller");
                Console.WriteLine(" 2. Add Product");
                Console.WriteLine(" 3. Login as Customer");
                Console.WriteLine(" 0. Exit");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddSeller();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        ViewShop();
                        break;
                }
            } while (ch != 0);
            Console.WriteLine("EKart Logged out");
        }

        void AddSeller()
        {
            Console.WriteLine("Seller Details");
            Seller s = new Seller();
            Console.WriteLine("Enter Seller Id");
            s.SellerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Seller Name");
            s.SellerName = Console.ReadLine();
            Console.WriteLine("Enter Seller Address");
            s.SellerAddress = Console.ReadLine();
            sellers.Add(s);
            Console.WriteLine("Seller Added!!");
        }

        void AddProduct()
        {
            Console.WriteLine("Product Details");
            Product p = new Product();
            Console.WriteLine("Enter Product Id");
            p.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Name");
            p.ProductName = Console.ReadLine();
            Console.WriteLine("Enter Product Price");
            p.Price = Convert.ToDouble(Console.ReadLine());
            products.Add(p);

            Console.WriteLine("Select Sellers");
            foreach (var s in sellers)
            {
                Console.WriteLine("{0}. {1}", s.SellerId, s.SellerName);
            }
            //1 2 3
            string[] tokens = Console.ReadLine().Split(" ");

            foreach(var t in tokens)
            {
                ProductDetails pd = new ProductDetails();
                pd.product = p;
                pd.seller = getSeller(Convert.ToInt32(t));
                Console.WriteLine("Enter quantity for Seller {0}", pd.seller.SellerName);
                pd.quantity = Convert.ToInt32(Console.ReadLine());
                productdetails.Add(pd);
            }
            Console.WriteLine("Product Added!!");
        }

        void ViewShop()
        {
            Console.WriteLine("Products Details");
            CartItem cartItem = new CartItem();
            Console.WriteLine("Product Id | Product Name | Price | Quantity Available");
            foreach (var p in products)
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", p.Id, p.ProductName, p.Price, getQuantityAvailable(p.Id));
            }
            Console.WriteLine("Enter # to go back to main menu or 0 to Continue");
            if (Console.ReadLine() == "#")
            {
                listOptions();
            }
            Console.WriteLine("Select Products");
            string[] productIds = Console.ReadLine().Split(" ");
            foreach (var i in productIds)
            {
                cartItem.product = getProduct(Convert.ToInt32(i));
                Console.WriteLine("Select Seller for {0}", cartItem.product);
                foreach (var s in sellers)
                {
                    Console.WriteLine("{0}. {1}", s.SellerId, s.SellerName);
                }
                cartItem.seller = getSeller(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Enter Quantity for {0}", cartItem.product);
                cartItem.quantity = Convert.ToInt32(Console.ReadLine());
                cart.Add(cartItem);
                /*
                 *
                 * Decrement Product Quantity
                 *
                 */
            }
            Console.WriteLine("Products Added to cart");
            

        }

        void listOptions()
        {
            Console.WriteLine("1.View Cart");
            Console.WriteLine("2.Continue Shopping");
            Console.WriteLine("3.Save Cart for Later");
            Console.WriteLine("4.Checkout Cart");

            /*
             *
             * Complete this Method
             *
             */
        }

        void viewCart()
        {
            /*
             *
             * Complete this Method
             *
             */
        }

        bool DeleteItem()
        {
            /*
             *
             *Complete this Method
             *
             * Increment Quantity of the product
             */
            return false;
        }

        void saveCart()
        {
            /*
             *
             * Complete this Method
             *
             */
        }

        void retriveCart()
        {
            /*
             *
             * Complete this Method
             *
             */
        }

        void Checkout()
        {
            /*
             *
             * Complete this Method
             *
             */
        }

        Product getProduct(int id)
        {
            foreach (var p in products)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;
        }

        Seller getSeller(int id)
        {
            foreach (var s in sellers)
            {
                if (s.SellerId == id)
                {
                    return s;
                }
            }

            return null;
        }

        int getQuantityAvailable(int pid)
        {
            /*
             *
             * Complete this Method
             *
             */
            return 0;
        }
    }

    class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerAddress { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CatagoryId { get; set; }
    }

    class ProductDetails
    {
        public Product product { get; set; }
        public Seller seller { get; set; }
        public int quantity { get; set; }
    }

    class CartItem
    {
        public Product product { get; set; }
        public Seller seller { get; set; }
        public int quantity { get; set; }
    }

    class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
