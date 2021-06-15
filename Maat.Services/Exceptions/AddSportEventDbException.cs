using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Services.Exceptions
{
    public class AddSportEventDbException : Exception
    {
        public AddSportEventDbException()
        {
        }

        public AddSportEventDbException(string message) : base(message)
        {
        }

        public AddSportEventDbException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
