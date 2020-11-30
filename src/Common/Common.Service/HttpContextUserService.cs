using Common.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Common.Service
{
    public class HttpContextUserService : IHttpContextUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserGuid()
        {
            var userGuid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!Guid.TryParse(userGuid, out Guid guid))
            {
                throw new Exception($"User Guid: [{userGuid}] from context could not be parsed");
            }

            return guid;
        }
    }
}