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
            return base.StopAsync(cancellationToken);
        }
    }
}