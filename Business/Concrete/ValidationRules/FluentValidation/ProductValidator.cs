using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete.ValidationRules.FluentValidation
{
  public  class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("isim boş olamaz");
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);
            RuleFor(p => p.UnitsInStock).GreaterThan((short)0);
            RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("ürün a ile başlamalı");


        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
