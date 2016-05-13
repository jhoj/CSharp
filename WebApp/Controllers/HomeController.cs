using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["aNumber"] = 10;

            return View();
        }

        public ViewResult Property()
        {
            Product myProduct = new Product();
            myProduct.Name = "Jakup";

            ViewData["Name"] = String.Format("Product name: {0}", myProduct.Name);
            return View();
        }

        public ViewResult ExtensionMethod()
        {
            TestProduction test = new TestProduction { Products = new List<Product>
         {
             new Product { Name = "Product 1", Number = 1, Quantity = 100 },
             new Product { Name = "Product 2", Number = 2, Quantity = 13 },
             new Product { Name = "Product 3", Number = 3, Quantity = 1223 },
             new Product { Name = "Product 4", Number = 4, Quantity = 432 }
         } };

            // get the total value of the products in the cart
            decimal productionQuantity = test.TotalQuantity();
            ViewData["ExtensionMethod"] = String.Format("Total production quantity: {0:c}", productionQuantity);
            return View();
        }

        public ViewResult FilterByName()
        {
            TestProduction test = new TestProduction
            {
              Products = new List<Product>
             {
              new Product { Name = "TestProduct", Number = 1, Quantity = 100 },
              new Product { Name = "TestProduct", Number = 2, Quantity = 13 },
              new Product { Name = "Product 3", Number = 3, Quantity = 1223 },
              new Product { Name = "Product 4", Number = 4, Quantity = 432 }
             }
           };
            decimal totalQuantity = 0;
            foreach (Product product in test.Products.FilterByName("TestProduct"))
            {
                totalQuantity += product.Quantity;
            }

            ViewData["FilterByName"] = String.Format("Total Quantity: {0}", totalQuantity);
            return View();
        }

        public ViewResult Filter()
        {
            TestProduction test = new TestProduction
            {
                Products = new List<Product>
             {
              new Product { Name = "TestProduct", Number = 1, Quantity = 100 },
              new Product { Name = "TestProduct", Number = 2, Quantity = 13 },
              new Product { Name = "Product", Number = 3, Quantity = 1223 },
              new Product { Name = "Product", Number = 4, Quantity = 432 }
             }
            };

            /*
             * The longer way is to do this
             * 
             * Func<Product, bool> filter = delegate(Product product) {
             * return product.Name == "Product";
             * };
             * */

            //shorter way
            Func<Product, bool> delegateLambda = product => product.Name == "Product";

            decimal totalQuantity = 0;
            foreach (Product product in test.Products.Filter(delegateLambda))
            {
                totalQuantity += product.Quantity;
            }

            ViewData["Filter"] = String.Format("Quantity: {0}", totalQuantity);
            return View();
        }
    }
}
