using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{ //3.Aşama IEntityRepositoryi miras aldırdık.
    //4.aşamada Northwind contexte Categoryi dbsetledik.yazdık yani
    //5.aşama DataAccess EntityFramework e gel classs ekle EfCAtegoryDal diye
   public interface ICategoryDal:IEntityRepository<Category>

    {
    }
}
