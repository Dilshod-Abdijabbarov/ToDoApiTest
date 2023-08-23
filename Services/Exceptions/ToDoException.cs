using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class ToDoException : Exception
    {
        public int Code { get; set; }

        public ToDoException(int Code,string message):base(message)
        {
            this.Code = Code;
        }
    }
}
