using Painty.Test.Database.Entities;

namespace Painty.Test.Database.Repositories.Abstract
{
    public interface IImageRepository
    {
        Task<ICollection<ImageEntity>> GetAsync(Guid userId);

        Task<ICollection<ImageEntity>?> GetFriendsAsync(Guid userId, Guid friendId);

        public Task AddAsync(Guid userId, ImageEntity image);

    }
}
