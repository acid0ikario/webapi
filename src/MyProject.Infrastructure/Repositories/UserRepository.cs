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
        
        // Implementa otros métodos definidos en IUserRepository según sea necesario
        public async Task<User?> GetUserByUsernameAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>  u.Username == username && u.Password == password);
        }
    }
}
