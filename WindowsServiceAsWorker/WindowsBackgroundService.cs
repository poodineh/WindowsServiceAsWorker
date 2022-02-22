using System.Threading;
using WindowsServiceAsWorker.Services;

namespace WindowsServiceAsWorker
{
    public sealed class WindowsBackgroundService : BackgroundService
    {
        private readonly OneService _oneService;
        private readonly ILogger<WindowsBackgroundService> _logger;

        public WindowsBackgroundService(
            OneService jokeService,
            ILogger<WindowsBackgroundService> logger) =>
            (_oneService, _logger) = (jokeService, logger);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await StartAsync(stoppingToken);
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string joke = await _oneService.GetJokeAsync();
                _logger.LogWarning(joke);

                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Closing some tasks and memories before terminating the windows service...");
            Thread.Sleep(5000);
            _logger.LogWarning("Tasks are closed now. I am going to terminate the windows service...");

            return base.StopAsync(cancellationToken);
        }
    }
}