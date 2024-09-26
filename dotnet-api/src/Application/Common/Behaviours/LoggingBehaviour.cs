using Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;    

    /// <summary>
    /// DEVELOPER NOTES:
    /// We do not use Identity Service since we not implement it from the get go
    /// so we modified this code from clean architecture and just get user id
    /// from jwt. But you can add Identity Service if you implement it
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="currentUserService"></param>
    /// <param name="identityService"></param>
    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.Username ?? string.Empty;
        

        _logger.LogInformation("Cerxos Web API Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);
    }
}
