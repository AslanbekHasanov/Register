using LinqToDB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Register.Backend.DataLayer;
using Register.Backend.Model;

namespace Register.Backend.Repository
{
    public class Service : IService
    {
        private readonly RegistrDbContext _registr;

        public Service(RegistrDbContext registr)
        {
            _registr = registr;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {

            var result = await _registr.Users.ToListAsync();
            if (result == null)
            {
                return result;

            }
            return result;
        }

        public async Task<bool> LogIn(string email, string password)
        {
            var res = await _registr.Users.FirstOrDefaultAsync(p => p.EmailAddress == email && p.Password == password);
            if (res == null)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> SignUpAsync(User user)
        {

            if (user != null)
            {
               await _registr.AddAsync(user);
               _registr.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
