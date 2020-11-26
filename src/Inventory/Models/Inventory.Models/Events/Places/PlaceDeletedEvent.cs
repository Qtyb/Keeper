using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models.Events.Places
{
    public class PlaceDeletedEvent : IRequest<Unit>
    {
        public Guid Guid { get; set; }
    }
}
