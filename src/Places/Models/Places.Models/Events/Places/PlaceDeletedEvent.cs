using System;
using System.Collections.Generic;
using System.Text;

namespace Places.Models.Events.Places
{
    public class PlaceDeletedEvent
    {
        public Guid Guid { get; set; }
    }
}
