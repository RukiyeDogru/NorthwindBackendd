using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Core.Extensions;




namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {//operasyonları yazarken Businessi kullanıcaz

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            
            _productService = productService;
        }


        [HttpGet(template: "getall")]

        //[Authorize(Roles = "Product.List")]

        public IActionResult GetList()//tümünü listele
        {
            try
            {

            }

            catch(Exception e)

            {
                Console.WriteLine(e);
                throw;
            }
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpGet(template: "getlistbycategory")]

        public IActionResult GetByCategory(int categoryId)//KategariId ye göre listele
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }
        [HttpGet(template: "getbyid")]

        public IActionResult GetById(int productId)//GetById ye göre listele
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpPost(template: "add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [HttpPost(template: "update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }//Bütün operasyonları bu şekilde tamamladık.Test etmemiz lazım ama ufak bi yapılandırmaya ihtiyacımız var.
        //yıjarda Iproduct servisi kullandık.ProductController bunun ne olduğunu bilmiyor.Manager olduğunu bilmiyor.Geri tarafta business katmaınındada
        //ProductManager buda productdalı kullanıyo ama ıproductdal kim dolayısıyla bizim burda dependency enjection configürasyonu yapmamız lazım
        //Autofac kurulumu yapıcaz bundan sonra
        [HttpPost(template: "transaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TransantionalOperation(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}