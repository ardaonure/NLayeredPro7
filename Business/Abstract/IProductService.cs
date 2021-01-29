using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        List<Product> GetProductsByCategoryId(int categoryId);
        List<Product> GetProductsByProductName(string key);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
