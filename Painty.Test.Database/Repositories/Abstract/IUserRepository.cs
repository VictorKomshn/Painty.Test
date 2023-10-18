using Painty.Test.Database.Entities;

namespace Painty.Test.Database.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task AddAsync(UserEntity entity);

        public Task AddFriendAsync(Guid userId, Guid friendId);

        public Task<UserEntity> GetByAsync(string username);
    }
}
