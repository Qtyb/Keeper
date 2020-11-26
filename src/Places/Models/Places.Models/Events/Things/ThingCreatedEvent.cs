using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Places.Models.Events.Things
{
    public class ThingCreatedEvent : IRequest<Unit>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
    }
}
