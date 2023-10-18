namespace Painty.Test.Database.Entities
{
    public class UserEntity
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserEntity> Friends { get; set; }

        public virtual ICollection<ImageEntity> Images { get; set; }
    }
}
