using Microsoft.EntityFrameworkCore;
using Painty.Test.Database.Context;
using Painty.Test.Database.Entities;
using Painty.Test.Database.Exceptions;

namespace Painty.Test.Database.Repositories
{
    public class BaseRepository
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserEntity> GetUserAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id: {userId} was not found");
            }

            return user;
        }
    }
}
