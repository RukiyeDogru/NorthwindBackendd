using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
   public class TokenOptions
    {
        public string Audience { get; set; }//tokenımızın kullanıcı kitlesi
        public string Issuer { get; set; }//imzalayan
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}//tokenoptionsları apinin içinde setting de tutucaz. Ama biz bunu nesne üzerinde map edip o nesne üzeürnden kullancağız
//oraya gelmeden önce jwthelperını yazacağız. Jwt klasörünün üzerinde 