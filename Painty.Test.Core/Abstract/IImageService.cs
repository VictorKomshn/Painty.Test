namespace Painty.Test.Core.Abstract
{
    public interface IImageService
    {
        Task<ICollection<byte[]>> GetAsync(Guid userId);

        Task AddAsync(Guid userId, byte[] image, string fileExtension);

        Task<ICollection<byte[]>> GetFriendsAsync(Guid userId, Guid friendId);
    }
}
