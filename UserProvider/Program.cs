using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()

    .ConfigureServices(services =>
    {
        services.AddDbContext<DataContexts>(x=>x.UseSqlServer(Environment.GetEnvironmentVariable("USER_IDENTITY_DATABASE")));
        
          
    })
    .Build();

host.Run();
