using Painty.Test.Database.Entities;

namespace Painty.Test.Core.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public ICollection<UserModel> Friends { get; set; }

        public IReadOnlyCollection<ImageModel> Images { get; set; }
    }
}
