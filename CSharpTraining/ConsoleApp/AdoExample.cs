using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks.Sources;
using Dapper;

namespace ConsoleApp
{
    using System.Data.SqlClient;
    class AdoExample
    {
        private string conString = "data source=fullstackserver2021.database.windows.net;Initial catalog=sampledb;User Id=fsadmin;Password=test@123";
        private string createQuery = "create table Products(Id int primary key not null Identity(1,1),ProductName NVARCHAR(50) NOT NULL,Price DECIMAL(18,2) NOT NULL,Description NVARCHAR(1000) NOT NULL)";

        SqlConnection con = null;
        public AdoExample()
        {
            con = new SqlConnection(conString);
        }
        public void CreateProductTable()
        {
            try
            {
                SqlCommand command = new SqlCommand(createQuery,con);
                con.Open();
                Console.WriteLine("Connection Established");
                command.ExecuteNonQuery();
                Console.WriteLine("Table Products is created");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }
        }

        public bool InsertProduct(Product p)
        {
            string insertQuery = "insert into Products(ProductName,Price,Description) Values(@ProductName,@Price,@description);";
            try
            {
                SqlCommand command = new SqlCommand(insertQuery, con);
                con.Open();
                Console.WriteLine("Connection Established");
                command.Parameters.AddWithValue("@ProductName", p.ProductName);
                command.Parameters.AddWithValue("@Price", p.Price);
                command.Parameters.AddWithValue("@description", p.Description);
                command.ExecuteNonQuery();
                Console.WriteLine("Product is inserted");
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }

            return false;
        }

        public bool UpdateProduct(Product p)
        {
            string insertQuery = "update Products set Price=@Price where productName = @ProductName;";
            try
            {
                SqlCommand command = new SqlCommand(insertQuery, con);
                con.Open();
                Console.WriteLine("Connection Established");
                command.Parameters.AddWithValue("@ProductName", p.ProductName);
                command.Parameters.AddWithValue("@Price", p.Price);
                Console.WriteLine("Product is updated, number of records updated"+ command.ExecuteNonQuery());
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }

            return false;
        }

        public void getProducts()
        {
            string sqlQuery = "Select * from Products";
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                Console.WriteLine("Connection Established");
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine("Query Executed");
                while (dr.Read())
                {
                    Console.WriteLine(dr["ProductName"] + " | " + dr["price"]);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }
        }


        public void getAllProducts()
        {
            string sqlQuery = "Select * from Products";
            try
            {
                con.Open();
                Console.WriteLine("Connection Established");
                SqlDataAdapter sd = new SqlDataAdapter(sqlQuery, con);
                Console.WriteLine("Query Executed");
                DataSet ds = new DataSet();
                sd.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }
        }


        public void getProductPrice(string item)
        {
            string sqlQuery = String.Format("select TOP 1 Price from Products where ProductName = '{0}'", item);
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                Console.WriteLine("Connection Established");
                string price = command.ExecuteScalar().ToString();
                Console.WriteLine("Price of {0} is {1}", item, price);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }
        }

        public void getAllProductDetails()
        {
            DataTable dt = new DataTable();//
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "|");
                }
                Console.WriteLine();
            }
        }

        public void getAllProductData()
        {
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                //ORM  Product Record => Product Objects
                var products = sqlcon.Query<Product>("Select * from products").ToList();

                foreach (var product in products)
                {
                    Console.WriteLine(product.Id);
                    Console.WriteLine(product.ProductName);
                    Console.WriteLine(product.Price);
                    Console.WriteLine(product.Description);
                    Console.WriteLine("======================================");
                }
            }
        }

        public void getProductsData()
        {
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                //ORM  Product Record => Product Objects
                var result = sqlcon.QueryMultiple("sp_GetProductData", null,null,null,commandType:CommandType.StoredProcedure);

                var catagories = result.Read<Catagory>().ToList();
                var products = result.Read<Product>().ToList();

                var groupls = products.GroupBy(p => p.CatagoryId);

                var filterProducts = products.Where(p => p.Price > 300 && p.Price < 500);

                foreach (var p in filterProducts)
                {
                    Console.WriteLine(p.Price);
                }

                foreach (var grp in groupls)
                {
                    Console.WriteLine(catagories.Where(c=> c.Id == grp.Key).Single().Name);
                    foreach (var product in grp)
                    {
                        Console.Write(product.Id + "|");
                        Console.Write(product.ProductName + "|");
                        Console.Write(product.Price + "|");
                        Console.Write(product.Description);
                        Console.WriteLine();
                    }
                    Console.WriteLine("======================================");
                }

                //foreach (var catagory in catagories)
                //{
                //    Console.WriteLine(catagory.Id);
                //    Console.WriteLine(catagory.Name);
                //    //linq 
                //    foreach (var product in products.Where(p => p.CatagoryId == catagory.Id).OrderByDescending(p=>p.Price).ThenByDescending(p => p.Id).ToList())
                //    {
                //        Console.Write(product.Id + "|");
                //        Console.Write(product.ProductName + "|");
                //        Console.Write(product.Price + "|");
                //        Console.Write(product.Description);
                //        Console.WriteLine("======================================");
                //    }
                //    Console.WriteLine("======================================");
                //}
            }
        }

        public void getProductData(string pName)
        {
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                //ORM  Product Record => Product Objects
                var product = sqlcon.QueryFirstOrDefault<Product>("sp_GetProductDataByName", new
                {
                    productName = pName
                }, null, null, commandType: CommandType.StoredProcedure);

                Console.WriteLine(product.Id);
                Console.WriteLine(product.ProductName);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.Description);
            }
        }

        public void getProductPriceData(string pName)
        {
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                //ORM  Product Record => Product Objects
                var productPrice = sqlcon.QueryFirstOrDefault<float>("sp_GetProductPriceByName", new
                {
                    productName= pName
                }, null, null, commandType: CommandType.StoredProcedure);

                Console.WriteLine(productPrice);
                
            }
        }

        public void getData()
        {
            //Linq C#3.0 => .Net 3.5

            List < IElectronicDevice > ls = new List<IElectronicDevice>();//tv/ac/mobile

            var tvs = ls.OfType<Television>();

            var mobiles = ls.OfType<Mobile>();

            int[] numbers = {34, 20, 18, 38, 43, 92, 61, 27,17};
            string[] names = {"Rrajiv", "Prashanth", "Ganesh", "Vineth"};
                                        
            var data=from num in numbers where num > 30  select num; // Linq query

            var namesData = names.Where(name => name.Contains('a')).OrderBy(name => name).ToList(); // Linq Methods(extension)

            var sum = numbers.OrderBy(num => num).Single();

            Console.WriteLine(sum);

            foreach (var x in data)
            {
                Console.WriteLine(x);
            }

            foreach (var x in namesData)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine(names.Where(name => name.Contains("ra")).FirstOrDefault());
        }


        public int InsertCatagory(string CatagoryName)
        {
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                //ORM  Product Record => Product Objects
                var inserted = sqlcon.Execute("sp_InsertCatagory", new
                {
                    CatagoryName
                }, null, null, commandType: CommandType.StoredProcedure);
                Console.WriteLine($"Insert Catagory: {0}",inserted);
                return inserted;
            }
        }
    }
}
