using WindowsServiceAsWorker;
using WindowsServiceAsWorker.Services;

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
    .Build();

await host.RunAsync();
