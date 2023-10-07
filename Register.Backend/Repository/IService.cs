﻿using Register.Backend.Model;

namespace Register.Backend.Repository
{
    public interface IService
    {
        Task<User> GetByIDAsync(int id);
        Task<bool> SignUpAsync(User user);
        Task<bool> LogIn(string email, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> RemoveUserAsync(int id);
    }
}
