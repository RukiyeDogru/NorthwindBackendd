using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contants
{
   public static class Messages
    {
      public static string ProductAdded = "Ürün Başarıyla eklendi";
      public static string ProductDeleted = "Ürün Başarıyla silindi";
      public static string ProductUpdated = "Ürün Başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Sisteme giriş başarılı";
        public static string UserAlreadyExists ="Bu kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated="AccessToken Başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string ProductNameAlreadyExist ="Ürün İsmi Zaten Mevcut";
    }
}
