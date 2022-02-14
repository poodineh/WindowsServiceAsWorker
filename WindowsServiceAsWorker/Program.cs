using WindowsServiceAsWorker;
using WindowsServiceAsWorker.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET 6 One Service";
    })

    .ConfigureServices(services =>
    {
        services.AddHostedService<WindowsBackgroundService>();
        services.AddHttpClient<OneService>();
    })

    .ConfigureWebHostDefaults(webHost =>
    {
        webHost.ConfigureKestrel((context, options) =>
        {
            options.ListenLocalhost(9999, options =>
            {
                options.Protocols = HttpProtocols.Http1AndHttp2;
                options.UseHttps();
            });
        });
        webHost.UseStartup<Startup>();
    })

    .Build();

await host.RunAsync();
