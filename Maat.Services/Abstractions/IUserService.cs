using Maat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Services.Abstractions
{
    public interface IUserService
    {
        User CreateUser(User user);

        User AttemptLogin(string email, string password);

        User GetUserById(int id);
    }
}
