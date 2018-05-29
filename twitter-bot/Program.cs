using System;
using Tweetinvi;
using System.Timers;
using System.Net;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace tweetbot
{
    class Program
    {
        private static string customer_key = "V5qldfwD0grCPXqJtM2PhBuuq";
        private static string customer_key_secret = "541szJxPM0w9ygQgTTJ4txWljikMEsxHySPIsRLazLDLGog08h";
        private static string acess_token = "999413403075661824-Lw0amhqh4UlhkzzaP5yh5ohr0o43zG0";
        private static string acess_token_secret = "wGZL2egymxmAE4xqYCBs7AwfBhG2hNAsK7aCWRQ90Q38f";

        static void Main(string[] args)
        {
            // GUI INIT
            Console.Write(DateTime.Now);
            Console.WriteLine(" bot est lancé");
            
            // AUTH
            Auth.SetUserCredentials(customer_key, customer_key_secret, acess_token, acess_token_secret);


            // GUI query
            Console.WriteLine("enter your search query");
            var query = Console.ReadLine();
            Console.WriteLine("you searched for" + query);

            var tweets = search_rafle(query);

            int i = 1;

            // TODO: optimise
           foreach (var tweet in tweets)
            {
                Console.WriteLine("tweet " + i++ + " envoyé");

                Retweet(tweet.Id);
                Like(tweet.Id);
            }
            Console.Read();
        }
       
        private static IEnumerable<ITweet> search_rafle(string query)
        {
           return Search.SearchTweets(query);
        }

        private static void Retweet(long id)
        {
            Tweet.PublishRetweet(id);
        }

        private static void Like(long id)
        {
            Tweet.FavoriteTweet(id);
        }
        //public static int ToInt32(long value) => Convert.ToInt32(value);
    }
}
