using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Microsoft.Extensions.Logging;

namespace Valuator
{
    public class Storage : IStorage
    {
        private readonly ILogger<Storage> _logger;
        private readonly IConnectionMultiplexer _connection;
        private readonly string host = "localhost";
        private readonly int port = 6379;
        public Storage(ILogger<Storage> Logger)
        {
            _logger = Logger;
            _connection = ConnectionMultiplexer.Connect("localhost");
        }

        public List<string> GetKeys()
        {
            List<string> data = new List<string>();

            var keys = _connection.GetServer(host, port).Keys();

            foreach(var item in keys)
            {
                data.Add(item.ToString());
                Console.WriteLine(item.ToString());
            }
            return data;
        }

        public string Load(string key)
        {
            IDatabase db = _connection.GetDatabase();
            if(db.KeyExists(key))
            {
                return db.StringGet(key);
            }
            _logger.LogWarning("Key ", key, "doesnt exist");
            return string.Empty;
        }

        public void Store(string key, string value)
        {
            IDatabase db = _connection.GetDatabase();
            if(!db.StringSet(key, value))
            {
                _logger.LogWarning("Failed to save", key, ": ", value);
            }
        }


    }
}
