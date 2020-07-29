using System;

namespace Common.Data.Interfaces
{
    public interface IGuidEntity : IEntity
    {
        Guid Guid { get; set; }
    }
}