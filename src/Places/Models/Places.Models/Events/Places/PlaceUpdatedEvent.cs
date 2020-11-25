using System;
using System.Collections.Generic;
using System.Text;

namespace Places.Models.Events.Places
{
    public class PlaceUpdatedEvent
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid? ParentPlaceGuid { get; set; }
    }
}
