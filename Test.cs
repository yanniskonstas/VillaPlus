using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataAccess;
using Domain;

namespace VillaPlus
{
   static class Tests
   {
        [Test]
        public static void TestAllProducts(){
            //Create the product repository to use
            var productRepository = new TestProductRepository();
            // Create the product service using the repository
            var productService = new ProductService(productRepository);
            //Create the Basket using the appropriate product service
            var myBusket = new Basket(productService);
            //Add all dummy products in the Basket
            myBusket.Products = productService.GetProducts();
            Assert.AreEqual(myBusket.TotalAmount(), 30);
            Assert.AreEqual(myBusket.DiscountAmount(), 5);
            Assert.AreEqual(myBusket.FinalAmount(), 25);
        }

        [Test]
        public static void TestProducts2(){
            //Create the product repository to use
            var productRepository = new TestProductRepository();
            // Create the product service using the repository
            var productService = new ProductService(productRepository);
            //Create the Basket using the appropriate product service
            var myBusket = new Basket(productService);
            //Add one more with id 3 in the Basket
            var testProducts = productService.GetProducts();
            myBusket.Products = new List<IProduct> {
                testProducts.First(p => p.Id == 1),
                testProducts.First(p => p.Id == 2),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
            };
            Assert.AreEqual(myBusket.FinalAmount(), 25);
        }

        [Test]
        public static void TestProducts3(){
            //Create the product repository to use
            var productRepository = new TestProductRepository();
            // Create the product service using the repository
            var productService = new ProductService(productRepository);
            //Create the Basket using the appropriate product service
            var myBusket = new Basket(productService);
            //Add some dummy products in the Basket
            var testProducts = productService.GetProducts();
            myBusket.Products = new List<IProduct> {
                testProducts.First(p => p.Id == 2),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
            };
            Assert.AreEqual(myBusket.FinalAmount(), 50);
        }

        [Test]
        public static void TestProducts4(){
            //Create the product repository to use
            var productRepository = new TestProductRepository();
            // Create the product service using the repository
            var productService = new ProductService(productRepository);
            //Create the Basket using the appropriate product service
            var myBusket = new Basket(productService);
            //Add some dummy products in the Basket
            var testProducts = productService.GetProducts();
            myBusket.Products = new List<IProduct> {
                testProducts.First(p => p.Id == 1),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
                testProducts.First(p => p.Id == 3),
            };
            Assert.AreEqual(myBusket.FinalAmount(), 50);
        }
    }
}
