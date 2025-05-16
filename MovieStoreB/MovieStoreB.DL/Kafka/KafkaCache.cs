using Confluent.Kafka;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovieStoreB.Models.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Confluent.Kafka.ConfigPropertyNames;


namespace MovieStoreB.DL.Kafka
{
    public class KafkaCache<TKey, TValue> : BackgroundService, IKafkaCache<TKey, TValue> 
        where TKey : notnull
        where TValue : class
    {
        private readonly ConsumerConfig _Config;

        public KafkaCache() {
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka-193981-0.cloudclusters.net:10300",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "admin",
                SaslPassword = "CPxpKSRD",
                EnableSslCertificateVerification = false
            };

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var consumer = new ConsumerBuilder<TKey, TValue>(_Config)
                .SetValueDeserializer(new MessagePackDeserializer<TValue>())
                .Build())
           { 
            consumer.Subscribe("test");

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume();

                if (consumeResult != null) {
            }
        }
        return Task.CompletedTask;
    }
}

    }