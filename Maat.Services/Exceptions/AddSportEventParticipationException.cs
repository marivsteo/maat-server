using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Services.Exceptions
{
    public class AddSportEventParticipationException : Exception
    {
        public AddSportEventParticipationException()
        {
        }

        public AddSportEventParticipationException(string message) : base(message)
        {
        }

        public AddSportEventParticipationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
