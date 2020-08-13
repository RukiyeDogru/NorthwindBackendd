using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{//Temel veriye erişim operayonları Select update  vs.
 //Bu işlemleri bütün nesneler için yapacağımızdan Generic Repository Patterni kullanacağız.
    //Core git orda yaz bu kodu DataAccess klasörü oluştur çünkü o katmana hizmet edecek
    public interface IProductDal:IEntityRepository<Product>
    {

    }
}
