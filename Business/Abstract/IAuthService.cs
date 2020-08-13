using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{ //bu servis sayesinde login veya register olucaz
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);


        IResult UserExists(string email);//kullanıcı var mı diye varsa böyle kullanıcı zaten kayıtlı diye
        IDataResult<AccessToken> CreateAccessToken(User user);//Token üretmek istiyorum 
    }
}
