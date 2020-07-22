using System;

namespace Common.Data.Interfaces
{
    public interface IDateTimeEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}