using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models.Events.Users
{
    public class UserCreatedEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }
}
