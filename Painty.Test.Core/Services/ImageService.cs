using Microsoft.Extensions.Options;
using Painty.Test.Core.Abstract;
using Painty.Test.Core.Options;
using Painty.Test.Database.Entities;
using Painty.Test.Database.Repositories.Abstract;

namespace Painty.Test.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;

        private readonly string imagesStoragePath;

        public ImageService(IImageRepository repository, IOptions<ImagesOptions> options)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            imagesStoragePath = options.Value.StoragePath ?? string.Empty;
        }

        public async Task AddAsync(Guid userId, byte[] image, string fileExtension)
        {

            var imageId = Guid.NewGuid();

            var entity = new ImageEntity
            {
                Id = imageId,
                FileName = imageId.ToString() + fileExtension
            };

            var imagePath = imagesStoragePath + "/" + imageId + fileExtension;

            await File.WriteAllBytesAsync(imagePath, image);

            try
            {
                await _repository.AddAsync(userId, entity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<byte[]>> GetAsync(Guid userId)
        {
            try
            {
                var imageEntities = await _repository.GetAsync(userId);


                var imageFileNames = imageEntities.Select(x => x.FileName);
                var images = await GetImagesBytesAsync(imageFileNames);

                return images;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<byte[]>> GetFriendsAsync(Guid userId, Guid friendId)
        {
            try
            {
                var friendsImages = await _repository.GetFriendsAsync(userId, friendId);
                List<byte[]> images = new List<byte[]>();
                if (friendsImages != null)
                {
                    var imageFileNames = friendsImages.Select(x => x.FileName);
                    images = await GetImagesBytesAsync(imageFileNames);
                }

                return images;
            }
            catch
            {
                throw;
            }
        }

        private async Task<List<byte[]>> GetImagesBytesAsync(IEnumerable<string> fileNames)
        {
            List<byte[]> images = new List<byte[]>();
            foreach (var fileName in fileNames)
            {
                var imageStored = await File.ReadAllBytesAsync(imagesStoragePath + "/" + fileName);
                if (imageStored != null)
                {
                    images.Add(imageStored);
                }
            }

            return images;
        }
    }
}
