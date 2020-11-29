using Places.Data.Entities;
using Places.Models.Events.Users;

namespace Places.Services.Mappings.Interfaces
{
    public interface IUserMappingService
    {
        User Map(UserCreatedEvent @event);
    }
}