using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace tweetbotClasses
{
    public class TwitterList
    {
        private TwitterList()
        {
            List = Tweetinvi.TwitterList.CreateList("rafle", PrivacyMode.Public, "tester");
        }

        private ITwitterList List { get; set; }

        public void AddMember(string value)
        {
            List.AddMember(value);
        }

        public IEnumerable<ITweet> GetList()
        {
            return List.GetTweets();
        }

        public static TwitterList Create(IConfiguration configuration)
        {
            TwitterList item = new TwitterList();
            foreach (var member in configuration.GetSection("members").AsEnumerable())
            {
                if (string.IsNullOrEmpty(member.Value))
                {
                    continue;
                }

                item.AddMember(member.Value);
            }

            return item;
        }
    }
}
