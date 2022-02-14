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
            while (!stoppingToken.IsCancellationRequested)
            {
                string joke = await _oneService.GetJokeAsync();
                _logger.LogWarning(joke);

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}