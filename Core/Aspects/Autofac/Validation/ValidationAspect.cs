
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{ 
    //invocation metot demek
   public class ValidationAspect:MethodInterception

    {
        private Type _validatorType;
        
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen validatortype bir IValidator türünde değilse 
            {
                throw new System.Exception(AspectMessages.WrongValidationType); ;
            }
            _validatorType = validatorType;//hata yoksa validatortypem eşittir
        }

        protected override void OnBefore(IInvocation invocation)//OnBeforu doldurduk
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Producta ulaşmak
            var entities = invocation.Arguments.Where(t=>t.GetType()==entityType);//git metodun argümanlarına bak

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

    }
}
