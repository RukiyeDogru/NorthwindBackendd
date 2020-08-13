using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{//extensions yazacağımız için static yazıypruz
   public static class ServiceCollectionExtensions
    {
        //ben bunu kullanarak api tarafında bütün merkezi configürasyonları eklcez!
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,ICoreModule [] modules)
        {
            foreach(var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        }

    }
}

