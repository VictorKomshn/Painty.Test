using Painty.Test.Core.Models;
using Painty.Test.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painty.Test.Core.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this UserModel model, ICollection<ImageEntity> images)
        {
            return new UserEntity
            {
                Friends = model.Friends.Select(x=> x.ToEntity()),
                Id = model.Id,
                Images = images,
                Name = model.Name,
                Password = model.Password,
            };
        }
    }
}
