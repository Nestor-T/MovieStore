
namespace MovieStoreC.BackgroundServices
{
	public class TestBgService : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{ 
			Console.WriteLine($"Job executed:{DateTime.Now}");
			
			await Task.Delay(1000, stoppingToken);
			}

		}
	}
}
