using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>
    {
        //FluentValidationu bir constructor vasıtasıyla devreye sokuyoruz

        public ProductValidator()
        { 
            //BURDA YAPTIĞIMIZ ŞEYLER 
            // RuleFor(expression: p => p.ProductName).NotEmpty().Length(2, 30);//ProductName boş olamaz min 2 karakter max 30 karakter olmalıdır
            //biz bunu ayrı ayrı yazacağız
            RuleFor(expression: p => p.ProductName).NotEmpty();
            RuleFor(expression: p => p.ProductName).Length(2, 30);
            RuleFor(expression: p => p.UnitPrice).NotEmpty();
            RuleFor(expression: p => p.UnitPrice).GreaterThanOrEqualTo(1);//ürünlerin uniypricesi 1 ve 1 den büyük olmalı
            RuleFor(expression: p => p.UnitPrice).GreaterThanOrEqualTo(10).When(predicate: p => p.CategoryID == 1);//When burda şart durumu.Örn içecek kategori 1se içecek kategorisinde bir ürünün min fiyatı10dur 
            RuleFor(expression: p => p.ProductName).Must(StartWithWithA);


        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }//VALİDATİONI ÇAĞIRACAĞIZ PRODUCT MANAGERDAN
}
