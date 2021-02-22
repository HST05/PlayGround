using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Utilities.Result
{
    public class SuccessResult<T>:ResultBase<T>
    {
        public SuccessResult(T data, string message):base(true, message, data)
        {
            
        }
    }
}
