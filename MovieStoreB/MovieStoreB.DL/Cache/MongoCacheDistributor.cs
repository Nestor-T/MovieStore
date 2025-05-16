using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovieStoreB.DL.Kafka;
using MovieStoreB.Models.DTO;

namespace MovieStoreB.DL.Cache
{
    public class MongoCachePopulator<TData, TDataRepository, TConfigurationType, TKey> : BackgroundService 
        where TDataRepository : ICacheRepository<TData>
        where TData : ICacheItem<TKey>
        where TConfigurationType : CacheConfiguration
    {
        private readonly ICacheRepository<TData> _cacheRepository;
        private readonly IOptionsMonitor<TConfigurationType> _configuration;
        private readonly IKafkaProducer<TData> _kafkaProducer;
        public MongoCachePopulator(ICacheRepository<TData> cacheRepository, IOptionsMonitor<TConfigurationType> configuration)
        {
            _cacheRepository = cacheRepository;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var lastExecuted = DateTime.UtcNow;

            var result = await _cacheRepository.FullLoad();

            if (result != null)
            {
                await _kafkaProducer.ProduceAll(result);
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(_configuration.CurrentValue.RefreshInterval), stoppingToken);

                var updatedData = await _cacheRepository.DifLoad(lastExecuted);

                if (updatedData == null || !updatedData.Any())
                {
                    continue;
                }

                await _kafkaProducer.ProduceAll(updatedData);

                var lastUpdated = updatedData.Last()?.DateInserted;

                lastExecuted = lastUpdated ?? DateTime.UtcNow;

            }
        }
    }
}
