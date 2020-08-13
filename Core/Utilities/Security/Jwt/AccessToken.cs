using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{ //Erişim Tokenı.AccessToken bizim için bir nesne olacak bunun içinde çeşitli bilgiler tutacağız 
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set;}//Tokenın ne zamana kadar geçerli olduğu bilgisi

    }
}//Şimdi bizim için token üretimi gerçekleştircek bir helper oluşturacağız. bunun için bir interface class yazıyoruz Itokenhelper diye
