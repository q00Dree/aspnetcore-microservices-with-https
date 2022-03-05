using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.SecondService.HttpApiConnector;
using System;
using System.Threading.Tasks;

namespace Sample.Gateway.Controllers
{
    [ApiController]
    [Route("api/second-service")]
    public class SecondServiceProxyController : ControllerBase
    {
        private readonly ISecondServiceHttpApiConnector _secondServiceHttpApiConnector;
        private readonly ILogger<SecondServiceProxyController> _logger;

        public SecondServiceProxyController(ISecondServiceHttpApiConnector secondServiceHttpApiConnector,
            ILogger<SecondServiceProxyController> logger)
        {
            _secondServiceHttpApiConnector = secondServiceHttpApiConnector;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SecondServiceHealthCheck()
        {
            try
            {
                var response = await _secondServiceHttpApiConnector.HealthCheckAsync();

                return Ok(response ?? "Not health");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in controller {controllerName} in method {methodName}.",
                     nameof(SecondServiceProxyController), nameof(SecondServiceHealthCheck));

                return StatusCode(500, ex.Message);
            }
        }
    }
}
