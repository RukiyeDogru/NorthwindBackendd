using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{//1.aşama bu Entitiese Concrete gel category classını ekle.
    //2.aşama DataAccese geç Abstract klasöründe interface class oluşturuyoruz(ICategortDal)
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
