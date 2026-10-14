namespace Arena.StatsWorker;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
    string? name = null;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var display = name ?? "Unnamed player";

        if (name is { Length > 0 }) 
        {
            logger.LogInformation("Hello {0}", name);
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
