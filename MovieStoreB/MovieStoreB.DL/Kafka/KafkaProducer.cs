using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.DL.Kafka
{
    public static IProducer<string, TData> CreateProducer()
    {
        var config = new ProducerConfig()
        {
            BootstrapServers = "kafka-193981-0.cloudclusters.net:10300",
            SecurityProtocol = SecurityProtocol.SaslSsl,
            SaslMechanism = SaslMechanism.Plain,
            SaslUsername = "admin",
            SaslPassword = "CPxpKSRD",
            EnableSslCertificateVerification = false
        };

        return new ProducerBuilder<string, ChatMessage>(config)
            .SetValueSerializer(new MsgPackSerializer<ChatMessage>())
            .Build();
    }
    internal class KafkaProducer
    {

    }
}
