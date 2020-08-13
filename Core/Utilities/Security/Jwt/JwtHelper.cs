using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        //burda configürasyon dosyasını okuyacağız
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenoptions;//token bilgilerini burdan okuyoruz
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenoptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
           
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //token oluştururken çeşitli bilgiler lazım.bunlardan biri securitykey.Algoritmayı kullanarak token oluşturucaz şifreli.tokenı oluştururken encript ederken bir anahtara ihtiyacımız var onu kullanıyor olacağız
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenoptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenoptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwt = CreateJwtSecurityToken(_tokenoptions, user, signingCredentials, operationClaims);
            var jwtsecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtsecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {

            var jwt = new JwtSecurityToken
                ( 
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials

                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{ user.FirstName} { user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
//JWthelperimiz var. biz bunu tamamlayalım login ve register işlemlerimiz var. bu noktada  businessa gelip bir servis yazacağız.IAuthServis isimli bir servis yazacağız.Bu servis vasitasıyla sisteme login veya register olacağız 
//yani ya sisteme giriş yapıyor yada sisteme kayıt oluyor olacağız.login olmak demek veritabanında kullanıcının varlığının kontrol edilmesi demek . register olması durumunda bir result veriyorduk. Şimdi git IAuthServise