using Inventory.Data.Entities;
using Inventory.Models.Events.Users;
using Inventory.Services.Mappings.Interfaces;
using System;

namespace Inventory.Services.Mappings
{
    public class UserMappingService : IUserMappingService
    {
        public User Map(UserCreatedEvent @event)
        {
            return new User
            {
                Guid = Guid.Parse(@event.Id),
                Name = @event.Name,
                Email = @event.Email
            };
        }
    }
}