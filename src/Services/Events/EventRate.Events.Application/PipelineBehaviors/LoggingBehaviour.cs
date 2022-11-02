using EventRate.Core.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace EventRate.Events.Application.PipelineBehaviors
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;
            var requestGuid = Guid.NewGuid().ToString();

            var requestNameWithGuid = $"{requestName} [{requestGuid}]";

            _logger.LogInformation($"[START] {requestNameWithGuid}");
            TResponse response;

            var stopwatch = Stopwatch.StartNew();
            try
            {
                try
                {
                    _logger.LogInformation($"[PROPS] {requestNameWithGuid} {request.ToJson()}");
                }
                catch (NotSupportedException)
                {
                    _logger.LogInformation($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
                }

                response = await next();

                _logger.LogInformation($"[RESPONSE] {requestNameWithGuid} {response.ToJson()}");

            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation($"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
            }

            return response;
        }
    }
}