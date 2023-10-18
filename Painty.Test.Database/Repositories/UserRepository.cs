using Microsoft.EntityFrameworkCore;
using Painty.Test.Database.Context;
using Painty.Test.Database.Entities;
using Painty.Test.Database.Exceptions;
using Painty.Test.Database.Repositories.Abstract;

namespace Painty.Test.Database.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(UserEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddFriendAsync(Guid userId, Guid friendId)
        {
            var user = await GetUserAsync(userId);
            var friend = await GetUserAsync(friendId);

            user.Friends.Add(friend);
            _context.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> GetByAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == username);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id: {username} was not found");
            }

            return user;
        }
    }
}
