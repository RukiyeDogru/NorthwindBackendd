using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class UserForRegisterDto :IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

//Şimdi bir kullanıcı sisteme login olduğu zaman biz login olan kullanıcının login olma bilgilerini kontrol ediyor olacağız.Hemen akabinde
//eğer kullanıcının login olmak istediği bilgiler geçerli ise bu kullanıcıya bi token veriyor olacağız.Bu token JWT denilen bir formata sahip.
//Şifreli Bir metindir.Kullanıcıya bunu verdiğimiz zaman kullanıcı bunu hiçbi şekilde değiştiremez.Yani kendisi gidip bi token oluştursa onu bile koysa bu algoritmaya göre değiştirilmemsinin  bir önemi olmuyo
//Token işlemleri evrensel işlemler Core katmanında yazacağız.Utilities klasöründe Security klasörü açıyoruz ve gerekli araçları oraya yazacağız

    }
}
