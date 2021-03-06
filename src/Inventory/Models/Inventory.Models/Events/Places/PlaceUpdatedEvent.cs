﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models.Events.Places
{
    public class PlaceUpdatedEvent : IRequest<Unit>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid? ParentPlaceGuid { get; set; }
    }
}
