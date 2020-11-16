using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Models.Events
{
    public class UserCreated
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid Guid { get; set; }
    }
}
