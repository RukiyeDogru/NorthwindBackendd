using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{//merkezileştiriyoruz modulu

    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
        //implemente edicez
    }
}
