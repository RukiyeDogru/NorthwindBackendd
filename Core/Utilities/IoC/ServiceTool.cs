using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
   public static class ServiceTool
        //servisprovider bizi için merkezi servis yönetimi nesnesi olacak
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create (IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
        //Bu SERVİCETOOL vasıtasıyla .Net Coreun kendi servislerine erişebiliyorum demek

    }
}
