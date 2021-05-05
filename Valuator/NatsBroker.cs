﻿using System.Text;
using Library;

namespace Valuator
{
    public class NatsBroker : IMessageBroker
    {
        public void Publish(string key, string value)
        {
            using var connection = NatsFactory.GetNatsConnection();
            connection.Publish(key, Encoding.UTF8.GetBytes(value));
        }
    }
}