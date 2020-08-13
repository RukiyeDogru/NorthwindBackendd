using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {//8.Aşama burda implementasyon yapıyoruz. Bir ICategoryDala ihtiyacımız var bunuda dependency enjectionla yapıyoruz

        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }
    }
}
//9.aşamaya giderken dependencyresolvesda auofacbusinessmodule gel ve category nesnesini register et
//ettikten sonra Api ye gel controller ekle category adlı.
