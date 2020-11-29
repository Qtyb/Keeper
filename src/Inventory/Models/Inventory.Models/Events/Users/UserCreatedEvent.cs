using MediatR;

namespace Inventory.Models.Events.Users
{
    public class UserCreatedEvent : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }
}