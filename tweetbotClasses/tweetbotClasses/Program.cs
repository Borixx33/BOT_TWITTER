using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Timers;
using Tweetinvi;
using Tweetinvi.Models;

namespace tweetbotClasses
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");

            Configuration = builder.Build();

            TwitterBotCredentials credentials = TwitterBotCredentials.Create(Configuration);
            credentials.Authenticate();

            var liste = TwitterList.Create(Configuration);
            Console.WriteLine("Nouveau membre ?");
            string member = Console.ReadLine();
            if (!string.IsNullOrEmpty(member))
            {
                liste.AddMember(member);
            }

            

            Console.WriteLine("Mots clés ?");
            string searchQuery = Console.ReadLine();

            TwitterBot bot = new TwitterBot(credentials, liste, searchQuery,150, 9000);
            bot.Run();

        }
    }
}