using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            //-------

            var departmentRepo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a new Department name");

            var newDepartment = Console.ReadLine();

            departmentRepo.InsertDepartment(newDepartment);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }

            //-------


            var productRepo = new DapperProductRepository(conn);

            Console.WriteLine("Type a new Product name");

            var newProduct = Console.ReadLine();

            Console.WriteLine("Type the Price");

            var newPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Type the Category ID");

            var newCategoryId = int.Parse(Console.ReadLine());

            productRepo.InsertProduct(newProduct, newPrice, newCategoryId);

            var products = productRepo.GetAllProducts();

            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductID} {item.Name}");
            }

        }
    }
}
