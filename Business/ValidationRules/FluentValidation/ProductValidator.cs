using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //Kurallar ctor içine yazılır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 2);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            //product name A ile başlıyor mu?
            return arg.StartsWith("A");
        }
    }
}
