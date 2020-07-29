using System;

namespace Common.Data.Interfaces
{
    public interface IDateTimeEntity : IEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}