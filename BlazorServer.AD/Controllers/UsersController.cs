using System;
using System.Threading.Tasks;
using BlazorMsIdentity.Shared.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace BlazorServer.AD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public UsersController(ILogger<UsersController> logger, GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }

        [Authorize(Policy = CustomPolicies.AccountantPolicy)]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var user = await _graphServiceClient.Me.Request().GetAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not fetch records", ex);
                return UnprocessableEntity("Could not fetch records");
            }
        }
        
        [HttpGet("photo")]
        public async Task<IActionResult> GetUserPhoto()
        {
            try
            {
                var user = await _graphServiceClient.Me.Photo.Request().GetAsync();
                return Ok(user);
            }
            catch (ServiceException ex)
            {
                _logger.LogError("You dont have access to this resource", ex);
                return UnprocessableEntity("You dont have access to this resource");
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not fetch records", ex);
                return UnprocessableEntity("Could not fetch records");
            }
        }
    }
}