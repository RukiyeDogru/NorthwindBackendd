using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performans;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{//İş katmanını kullanmamız için DataAccese ihtiyacımız var
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;//bu field
        private ICategoryService _categoryService;//Eğer başka bir servisi kullanmamız gerekirse servisi çağırmamız gerekiyor

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Cross Cutting Concerns e başlıyoruz
        //uygulamayı dikine kesen ilgi alanları
        //Cross Cutting Concernse örnek:Validation, Cache, Loglama, Performsnce, Auth,Transaction
        //AOP-Aspect Oriented Programming:cross cutting 

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]//Aspect yazımına başalanacak Autofac kullanılacak bunun için
        [CacheRemoveAspect(pattern: "IProductService.Get")]
        
        public IResult Add(Product product)
        {
            // ValidationTool.Validate(new ProductValidator(), product); Bundanda kurtulacağız yukardaki Aspecti yazarak
            //Business kodları örneğin eklenen ürünün tekrar eklenmemesigibi
            //(Bu aşağıda yazmış olduğum bir iş kuralı )
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),CheckIFCategoryIsEnabled());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.Get(filter: p => p.ProductName == productName) != null)
              {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIFCategoryIsEnabled()
        {
            var result = _categoryService.GetList();
            if(result.Data.Count<10)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }

            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        { //Şimdi buralar hep EntityFramewore bağlı biz yarın farklı bi teknolojiye geçmek isteyebiliriz
          //sistem burda bağlı zaten bir yerde bir nesneyi newliyorsak orası ora tamamen bağlı
          // EfProductDal productDal = new EfProductDal();//bağımlılığın gevşek bsğımılığa çeviricez field tanımlayacağız
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductID == productId));
        }

        [PerformanceAspect(interval: 5)]

        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(millisecondsTimeout: 5000);

            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        // [SecuredOperation("Product.List, Admin")]
        [LogAspect(loggerService: typeof(DatabaseLogger))]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Product>> GetListByCategory(int categoryID)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryID == categoryID).ToList());
        }

        [TransactionScopeAspect]
        public IResult TransantionalOperation(Product product)
        {
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}//Dependecy Enjection alt yapısına geçtik burda

//Şimdi iş katmanını biraz Refactoring işlemine tabi tutalım Yani şu yazılan koları düzenleme
//Burdan somra Core gittik Utilities klasörü oluşturduk.
//Şu mesajlar biraz tehlikeli yani ürünler başarıyla eklendi vs mesajları, bunlara magic string deniyor bizim bunlardan kurtulmaz 