namespace Arena.StatsWorker;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
    readonly string? _name = null;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var display = _name ?? "Unnamed player";

        if (_name is { Length: > 0 }) 
        {
            logger.LogInformation("Hello {0}", _name);
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
