using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);

        }

        public List<Product> GetProductsByProductName(string key)
        {
            return _productDal.GetAll(p => p.ProductName.Contains(key));
        }

        public void Add(Product product)
        {
            ProductValidator productValidator=new ProductValidator();
            var result = productValidator.Validate(product);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
             _productDal.Add(product);

        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}
