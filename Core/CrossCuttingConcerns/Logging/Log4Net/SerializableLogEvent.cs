
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{//SerializableLogEvent loglayacağımız datanın kendisini anlatıyor bu sınıfınn serializable olması gerekiyor
    [Serializable]
    //Serileştirilmiş olmalı
   public class SerializableLogEvent //loglayacağımız datanın ta kendisii
    {
        private LoggingEvent _loggingEvent;//loglanacak data (logevent)

        public SerializableLogEvent(LoggingEvent loggingEvent)

        {
            _loggingEvent = loggingEvent;
     
        }

        public object Message => _loggingEvent.MessageObject;
    }
}
