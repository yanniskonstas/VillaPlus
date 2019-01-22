using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataAccess;
using Domain;
using static System.Console;

namespace VillaPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new TestProductRepository();
            // Create the product service using the repository
            var productService = new ProductService(productRepository);
            //Create the Basket using the appropriate product service
            var myBusket = new Basket(productService);
            //Put some dummy products in the Basket
            myBusket.Products = productService.GetProducts();   
            WriteLine($"Discounted amount: {myBusket.DiscountAmount()}");
        }
    }
}
