using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            message = message;
        }
        public Result(bool isSuccess)
        {
            isSuccess = isSuccess;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
