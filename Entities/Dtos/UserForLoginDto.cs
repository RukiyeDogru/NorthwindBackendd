using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    //NİÇİN DTO KULLANIYORUZ.mesela password diye bi alan yok veritabanında ama bana lazım yada tablonun joinine ihtiyacımız var ama daha önce kullandık onu 
    public class UserForLoginDto:IDto
    { 
        public string Email { get; set; }

        public string Password { get; set; }


    }
}
