﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Extensions
{
   public static class ExceptionMiddleWareExtensions
    {
        public static void ConfigureCustomExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

    }
}
