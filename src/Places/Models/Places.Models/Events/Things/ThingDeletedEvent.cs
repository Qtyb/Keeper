using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Places.Models.Events.Things
{
    public class ThingDeletedEvent : IRequest<Unit>
    {
        public Guid Guid { get; set; }
    }
}
