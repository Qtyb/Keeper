using Common.Data.Interfaces;
using System;

namespace Common.Data.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : IEntity
    {
        public EntityNotFoundException() : base()
        {
        }

        public EntityNotFoundException(string message)
            : base($"{typeof(T).Name} has not found in database. Message = [{message}]")
        {
        }

        public EntityNotFoundException(string message, Exception innerException) 
            : base($"{typeof(T).Name} has not found in database. Message = [{message}]", innerException)
        {
        }
    }
}