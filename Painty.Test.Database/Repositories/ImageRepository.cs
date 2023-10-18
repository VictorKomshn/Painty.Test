using Painty.Test.Database.Context;
using Painty.Test.Database.Entities;
using Painty.Test.Database.Repositories.Abstract;

namespace Painty.Test.Database.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        private readonly DataContext _context;

        public ImageRepository(DataContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Guid userId, ImageEntity image)
        {
            var user = await GetUserAsync(userId);

            user.Images.Add(image);

            _context.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ImageEntity>> GetAsync(Guid userId)
        {
            var user = await GetUserAsync(userId);

            return user.Images;
        }

        public async Task<ICollection<ImageEntity>?> GetFriendsAsync(Guid userId, Guid friendId)
        {
            var user = await GetUserAsync(userId);

            var friend = await GetUserAsync(friendId);

            if (friend.Friends.Contains(user))
            {
                return friend.Images;
            }
            else
            {
                return null;
            }
        }
    }
}
