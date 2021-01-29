using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibernate
{
   public class NhProductDal
    {
        public List<Product> GetAll()
        {
            List<Product> products=new List<Product>{new Product
            {
                CategoryId = 1,
                ProductId = 1,
                ProductName = "keke",
                QuantityPerUnit = "one loaf of bread in a pack",
                UnitsInStock = 2,
                UnitPrice = 1
            }};
           
            return products;

        }
    }
}
