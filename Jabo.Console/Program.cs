using System;
using StackExchange.Redis;

namespace Jabo.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.43.121:6379");

            IDatabase db = redis.GetDatabase(0);

            db.StringSet("name", "jabo123",TimeSpan.FromDays(1));

            System.Console.WriteLine(redis.GetDatabase(0).StringGet("name"));

        }
    }
}
