using Inventory.Data.Entities;
using Inventory.Models.Events.Users;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IUserMappingService
    {
        User Map(UserCreatedEvent @event);
    }
}