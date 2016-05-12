using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public static class ExtenstionMethod
    {
        public static int TotalQuantity(this Production production)
        {
            int totalQuantity = 0;
            foreach (Product newProduct in production.Products)
            {
                totalQuantity += newProduct.Quantity;
            }
            return totalQuantity;
        }

        public static IEnumerable<Product> FilterByName(
this IEnumerable<Product> product, string name)
        {
            foreach (Product newProduct in product)
            {
                if (newProduct.Name == name)
                {
                    yield return newProduct;
                }
            }
        }
        public static IEnumerable<Product> Filter(
        this IEnumerable<Product> product, Func<Product, bool> selector)
        {
            foreach (Product newProduct in product)
            {
                if (selector(newProduct))
                {
                    yield return newProduct;
                }

            }
        }
    }
}
