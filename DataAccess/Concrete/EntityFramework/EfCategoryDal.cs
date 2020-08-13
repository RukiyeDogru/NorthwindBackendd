using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{ //6.aşamada yine mirasları implemente ettik.Bu aşamadan sonra DataAccess katmanının işi bitmiş oldu.Gidiyoruz Businessa orda Abstract klasörünün altında ICategoryService sınıfı oluşturduk.

   public class EfCategoryDal:EfEntityRepositoryBase<Category, NorthwindContext> , ICategoryDal

    {

    }
}
