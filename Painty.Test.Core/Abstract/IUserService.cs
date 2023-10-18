namespace Painty.Test.Core.Abstract
{
    public interface IUserService
    {
        Task<bool> CheckCredentialsAsync(string username, string password);

        Task<Guid> AddAsync(string username, string password);

        public Task AddFriendAsync(Guid userId, Guid friendId);

    }
}
