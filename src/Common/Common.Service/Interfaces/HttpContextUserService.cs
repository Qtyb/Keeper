using System;

namespace Common.Service.Interfaces
{
    public interface IHttpContextUserService
    {
        Guid GetUserGuid();
    }
}