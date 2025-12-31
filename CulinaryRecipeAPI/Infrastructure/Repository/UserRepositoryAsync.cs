using CulinaryRecipeAPI.Database;
using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Repository;
using Microsoft.EntityFrameworkCore;

namespace CulinaryRecipeAPI.Infrastructure.Repository
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly ApplicationContext _context;
        public UserRepositoryAsync(ApplicationContext context) 
        { 
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Recipes).ToListAsync();
        }
        public async Task<User?> GetUserById(int userId)
        {
            return await _context.Users.Include(u => u.Recipes).FirstOrDefaultAsync(u => u.Id == userId);
        }  
        public async Task<User?> GetUserByLogin(String login)
        {
            return await _context.Users.Include(u => u.Recipes).FirstOrDefaultAsync(u => u.Email == login || u.Name == login);
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.Include(u => u.Recipes).FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        } 
        public async Task RemoveUser(User user)
        { 
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(); 
        }
        public async Task<User> UpdateUser(User user, User newUser)
        {
            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.UserRole = newUser.UserRole;
            user.HashedPassword = newUser.HashedPassword;
            await _context.SaveChangesAsync();
            return user;
        } 
    }
}
