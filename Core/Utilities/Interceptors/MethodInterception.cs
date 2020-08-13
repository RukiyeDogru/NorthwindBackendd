
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors

{//invacation: çalıştırılmaya çalışan operasyon demektir
    public abstract class MethodInterception:MethodInterceptionBaseAttribute //bir metodu nasıl yorumlayacağımız bir yer olacak
    {
        //metot çalışmadan sen çalış demek
        protected virtual void OnBefore(IInvocation invocation)
        {

        }
        //metot çalıştıktan sonra sen çalış 
        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        //metot hata verdiğinde sen çalış
        protected virtual void OnException(IInvocation invocation, System.Exception e) 
        {

        }
        //metot başarılıysa sen çalış
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();

            }
            catch(Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if(isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }//burda bir methodun nasıl ele alınacağını yazmış olduk.MethodInterceptor alt yapısı hazır
    }//bundansonra validationaspecti yazıcaz. Core katmanında git klasör oluştur aspects
}
