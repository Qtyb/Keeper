using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models.Events.Places
{
    public class PlaceCreatedEvent : IRequest<Unit>
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public string Name { get; set; }
        public Guid? ParentPlaceGuid { get; set; }
    }
}
