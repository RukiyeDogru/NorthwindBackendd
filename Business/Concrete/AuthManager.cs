using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Result;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService//implemente ediyoruz jwt kodlarını yazarak
    {
        private IUserService _userService;//kullanıcıyı kontrol etmemiz lazım veritabanında var mı bunu i kontrol etmemiz lazım
        private ITokenHelper _tokenHelper;//kullanıcı login olunca token vermemiz lazım buda tokenhelperle olacak
        public AuthManager (IUserService userService , ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;

        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken=_tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            //kontrol edicek kullanıcı
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if(userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
               Email=  userForRegisterDto.Email,
               FirstName=userForRegisterDto.FirstName,
               LastName=userForRegisterDto.LastName,
               PasswordHash=passwordHash,
               PasswordSalt=passwordSalt,
               Status=true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if(_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
