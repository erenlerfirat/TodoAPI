using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,bool success , string message) : base(success , message , data)
        {

        }
        public ErrorDataResult(T data, bool success) : base(success , data)
        {

        }
        public ErrorDataResult(string message) : base(false , message , default)
        {

        }
        public ErrorDataResult() : base (false , default)
        {

        }
    }
}
