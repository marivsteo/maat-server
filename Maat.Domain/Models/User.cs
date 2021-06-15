using Maat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Maat.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderEnum Gender { get; set; }

        public ICollection<SportEvent> SportEvents { get; set; }

        public List<SportEventUser> SportEventUsers { get; set; }

        public List<SportEvent> CreatedSportEvents { get; set; }
    }
}
