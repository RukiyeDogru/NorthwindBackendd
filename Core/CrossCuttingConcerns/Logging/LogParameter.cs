using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{//loglanacak operasyondaki parametredeki bilgileri

   public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }//örneğin productname i 1
        public string Type { get; set; }
    }
}
