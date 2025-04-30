using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace MovieStoreB.DL.Kafka
{
    public static Task ConsumeAsync()
    {
        var consumer = CreateConsumer();
        consumer.Subscribe("my-topic");
        while (true)
        {
            var consumeResult = consumer.Consume();
            Console.WriteLine(DateTime.Now);
        }
    }

    public static IConsumer<string, ChatMessage> CreateConsumer()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "kafka-193981-0.cloudclusters.net:10300",
            SecurityProtocol = SecurityProtocol.SaslSsl,
            SaslMechanism = SaslMechanism.Plain,
            SaslUsername = "admin",
            SaslPassword = "CPxpKSRD",
            EnableSslCertificateVerification = false

        };
        return new ConsumerBuilder<string, ChatMessage>(config)
            .SetValueDeserializer(new MsgPackDeserializer<ChatMessage>())
            .Build();
    }

    internal class KafkaConsumer
    {

    }
}