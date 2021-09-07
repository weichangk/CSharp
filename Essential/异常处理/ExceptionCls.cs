using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class ExceptionCls
    {
    }

    class MyException : Exception
    {
        public string error;
        private Exception innerException;

        public MyException() { }
        public MyException(string msg) : base(msg)
        {
            this.error = msg;
        }
        public MyException(string msg, Exception innerException) : base(msg, innerException)
        {
            this.innerException = innerException;
            error = msg;
        }
        public string GetError()
        {
            return error;
        }
    }

    // Supporting serialization via an attribute
    [Serializable]
    class DatabaseException : System.ApplicationException
    {
        // ...

        // Used for deserialization of exceptions
        public DatabaseException(SerializationInfo serializationInfo, StreamingContext context)
        {
            //...
        }
    }
}
