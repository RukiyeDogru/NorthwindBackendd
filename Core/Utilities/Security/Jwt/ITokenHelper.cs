using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper //bunu interface yazıyoruz 
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); //ben bi user göndereceğim oda ona göre token üretecek.
        //kullanıcı bilgisi(user) ve rolünü(operationClaim) vermiş oluyorum. 
    }
}
//bir sonraki aşamaya geçicez bizim amacımız token(tokenhelperile) üretmek.(Jwt ile yapacağız biz bunu)
//jwtnin çeşitli standartları var.bunları bizim veriyor olmamız lazım bilgileri yani.
//audin securitykey vs  bu noktads bu bilgileri nesne vasıtasıyla gerçekleştiricez.TokenOptions diyeceğiz