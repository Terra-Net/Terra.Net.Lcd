using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{
    public class CallResult<T>
    {
        public CallResult(T result, CallError? error = null)
        {
            Result = result;
            Error = error;
        }
        public readonly CallError? Error;
        public bool IsSuccess => Error != null;
        public readonly T Result;
        public static implicit operator bool(CallResult<T> callResult)=>callResult.IsSuccess;
    }
}
