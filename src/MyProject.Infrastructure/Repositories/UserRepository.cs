using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Domain.Repositories;
using MyProject.Infrastructure.Persistence;

namespace MyProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<User?> GetUserByUsernameAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>  u.Username == username && u.Password == password);
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
