﻿
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]

    public abstract class MethodInterceptionBaseAttribute:Attribute, IInterceptor
    {
     
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)//kodun değiştirilmesini istediğimiz zaman virtual yazdık
        {
          
        }
    }
}
