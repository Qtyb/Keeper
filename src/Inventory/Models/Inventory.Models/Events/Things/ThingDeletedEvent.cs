using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models.Events.Things
{
    public class ThingDeletedEvent
    {
        public Guid Guid { get; set; }
    }
}
