
namespace MovieStoreC.BackgroundServices
{
    public class TestHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Host service has started");
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Host service has stoped");

            return Task.CompletedTask;
        }
    }
}
