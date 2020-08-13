using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
   public interface IResult
    {
       // burda yapılan işlem başarılı mı bunu görücez
       bool Success { get; }//işlem başarılı mı
       string Message { get; }//mesaj
    }
}//hemen akabinde bu interfacei implemente edicek class oluşturucaz.oda genel Result sınıfı olucak.
