using Painty.Test.Core.Abstract;
using Painty.Test.Database.Entities;
using Painty.Test.Database.Repositories.Abstract;

namespace Painty.Test.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> AddAsync(string username, string password)
        {
            var newUserId = Guid.NewGuid();
            var newUser = new UserEntity
            {
                Id = newUserId,
                Name = username,
                Password = password
            };

            try
            {
                await _repository.AddAsync(newUser);
                return newUserId;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddFriendAsync(Guid userId, Guid friendId)
        {
            try
            {
                await _repository.AddFriendAsync(userId, friendId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckCredentialsAsync(string username, string password)
        {
            try
            {
                var user = await _repository.GetByAsync(username);
                if (user != null)
                {
                    return user.Password == password;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
