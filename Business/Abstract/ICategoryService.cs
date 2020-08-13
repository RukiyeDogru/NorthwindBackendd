using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICategoryService
    {//7.Aşama bu işlemleri yazdık.bunun concreteini yazalım şimdi sonraki aşamada CategoryManager classını oluşturduk

        IDataResult<List<Category>> GetList();//Sadece ürünleri listeleyeceğiz.
    }
}
