using System;
using System.Collections.Generic;
using System.Text;

namespace Places.Models.Events.Places
{
    public class PlaceCreatedEvent
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public string Name { get; set; }
        public Guid? ParentPlaceGuid { get; set; }
    }
}
