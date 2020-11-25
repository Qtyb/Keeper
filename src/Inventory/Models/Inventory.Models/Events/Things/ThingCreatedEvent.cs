using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models.Events.Things
{
    public class ThingCreatedEvent
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
    }
}
