using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
   public class LogDetail //Bu LogDetail nesnesi hem normal çalışan metotlar için hem de normal olmayan metotlar için kullanılıyor
    {
        //Loga ait detay bilgisini tutacak
        public string MethodName { get; set; }//loga konu olan metodun ismi
        public List<LogParameter> LogParameters { get; set; }//bu metodun birden fazla parametresi olabilir

      
    }
}
