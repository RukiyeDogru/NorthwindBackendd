using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{ // //İş tarafında yazacağımız oparasyonlarını yazacağımız yer
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryID);
        IResult Add(Product product);
        IResult Delete(Product product); //void di sildim ıresult yazdım
        IResult Update(Product product);
        //sonra bunun somutunu yazmamız gerekiyor
        IResult TransantionalOperation(Product product);
    }
}
