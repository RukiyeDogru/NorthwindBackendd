using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService

    {
        IUserDal _userDal;//dependency enjecsionla inişılayz edilmesi gerek
        public UserManager (IUserDal userDal)
           {   
            _userDal = userDal;
         
        
            }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)//maile göre kullanıcı döndürme
        {
            return _userDal.Get(filter: u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }//bundan sonra json ve token işlemleri yapacağız ayrıca bu işlemden sonra api kısmını kodlayacağız.
}//Autanticasyon ile ilgili işlemleri yapacağız.neler vardır bu işlemde kullanıcının bir işleme login olması sonra ona token vermek JWT(Json Web Token) tarafına doğru ilerliyoruz.
//Login olması durumunda bi kulanıcıdan email ve şifre isteyeceğiz kayıt olması durumunda diğer bilgileri isteyeceğiz. örneğin login olunca password isteyeceğiz ama bizi
//veritabanımızda password diye bi alan yok bu tip complex yapılar için hemde kendi işimizi görücek nesneler üretmek için dtolardan yararlanıcaz (DTO(Data Transformation Object))
