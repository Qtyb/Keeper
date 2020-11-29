using Common.Repository.Interfaces;
using Inventory.Models.Events.Users;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.WebApi.Handlers.Users
{
    public class UserCreatedEventHandler : IRequestHandler<UserCreatedEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMappingService _userMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserCreatedEventHandler> _logger;

        public UserCreatedEventHandler(
            IUserRepository placeRepository,
            IUserMappingService placeMappingService,
            IUnitOfWork unitOfWork,
            ILogger<UserCreatedEventHandler> logger)
        {
            _userRepository = placeRepository;
            _userMappingService = placeMappingService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UserCreatedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(UserCreatedEvent)} message: User.Id = [{@event.Id}] ----");

            if (!Guid.TryParse(@event.Id, out Guid userGuid))
            {
                throw new ArgumentException($"---- User.Id = [{@event.Id}] could not be parsed to GUID ----");
            }

            var user = await _userRepository.GetByGuid(userGuid);
            if (user != null)
            {
                _logger.LogInformation($"---- User with Guid = [{@event.Id}] already exists. Skipping event ----");
                return await Task.FromResult(Unit.Value);
            }

            user = _userMappingService.Map(@event);
            _userRepository.Add(user);

            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Saved {nameof(UserCreatedEvent)} message: User.Guid = [{user.Guid}] User.Id = [{user.Id}]----");

            return await Task.FromResult(Unit.Value);
        }
    }
}