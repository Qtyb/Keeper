using Places.Data.Entities;
using Places.Models.Events.Users;
using Places.Services.Mappings.Interfaces;
using System;

namespace Places.Services.Mappings
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