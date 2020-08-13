using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService //bikaç operasyon yazalım bunlardan biri kullanıcıların getirilmesi olacak.
    //Yani sahip olduğu yetkilerin getirilmesi olacak
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);//kullanıcı eklemek istiyorum mesela
        User GetByMail(string email);//bir kullanıcıyı maili vasitasıyla bulmak istiyorum.
        //bundan sonra Concrete git class oluştur managerını yaz bu kodun yani
    }
}
