using System.Net;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UserProvider
{
    public class GetUsers(ILoggerFactory loggerFactory, DataContexts context)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<GetUsers>();
        private readonly DataContexts _context = context;

        [Function("GetUsers")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] Microsoft.AspNetCore.Http.HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var users = await _context.Users.ToListAsync();

            return new OkObjectResult(users);
        }
}
}
