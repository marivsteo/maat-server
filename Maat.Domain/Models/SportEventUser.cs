using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Domain.Models
{
    public class SportEventUser
    {
        public User User {get;set;}

        public int UserId { get; set; }

        public SportEvent SportEvent { get; set; }

        public long SportEventId { get; set; }
    }
}
