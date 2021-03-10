using System.Collections.Generic;

namespace Core.Utilities.Result
{
    public class FailResult<T> : ResultBase<T>
    {
        public FailResult(string message) : base(false, message)
        {

        }

        public FailResult(string message, T data) : base(false, message, data)
        {

        }
    }
}
