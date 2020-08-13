using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        private static string message;

        public ErrorResult(string message) : base(success: false, message)
        {

        }
        public ErrorResult() : base(success: false)
        {

        }
    }
}
