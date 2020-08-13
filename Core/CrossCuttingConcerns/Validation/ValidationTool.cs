using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
   public static class ValidationTool//validationu merkezileştirdiğimiz kısım olacak.Gittik productmanagerdan yazdığın validationı buraya yazıyoruz.
    {
        public static void Validate(IValidator validator , object entity)
        {
      
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
                //bunu merkezi bir noktaya çekeceğiz.Core tarafına gideceğiz
            }
        }
    }//Validatorlar dtolara da uygulanır.
}
