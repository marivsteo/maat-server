using Maat.DataAccess;
using Maat.Domain.Models;
using Maat.Services.Abstractions;
using Maat.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Services
{
    public class UserService : IUserService
    {
        public readonly MaatDbContext _dbContext;

        public UserService(MaatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User CreateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new EmailAlreadyExistsException("An user with this email already exists!");
            }
            _dbContext.Users.Add(user);
            user.Id = _dbContext.SaveChanges();

            return user;
        }

        public User AttemptLogin(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new UserNotFoundException("User not found!");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new InvalidCredentialsException("Invalid credentials!");
            }

            return user;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
