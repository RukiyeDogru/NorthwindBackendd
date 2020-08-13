using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string messega):base(data, success:true, messega)
        {

        }

        public SuccessDataResult(T data):base(data,success:true)
        {

        }
        public SuccessDataResult(string message):base(default,success:true, message)
        {

        }

        public SuccessDataResult():base(default, success:true)
        {

        }

    }
}
