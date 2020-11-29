using Places.Data.Entities;
using Places.Models.Events.Users;
using System;

namespace Places.Services.Mappings
{
    public class UserMappingService
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