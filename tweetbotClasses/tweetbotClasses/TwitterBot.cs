using System.Threading;
using Tweetinvi;

namespace tweetbotClasses
{
    public class TwitterBot
    {
        public TwitterBot(TwitterBotCredentials credentials, TwitterList twitterList, string searchQuery, int maxTweetNumber, int sleepDuration)
        {
            Credentials = credentials;
            TwitterList = twitterList;
            SearchQuery = searchQuery;

            MaxTweetNumber = maxTweetNumber;
            SleepDuration = sleepDuration;
        }

        public TwitterBotCredentials Credentials { get; private set; }
        public TwitterList TwitterList { get; private set; }
        public string SearchQuery { get; private set; }

        public int MaxTweetNumber { get; private set; }
        public int SleepDuration { get; private set; }

        public void Run()
        {
            Credentials.EnsureAuthenticate();

            var finalList = TwitterList.GetList();
            int i = 0;
            foreach (var tweet in Search.SearchTweets(SearchQuery))
            {
                i++;
                new LikeRetweet(tweet.Id);
                if (i == MaxTweetNumber)
                {
                    Thread.Sleep(SleepDuration);
                    Credentials.EnsureAuthenticate();
                }
            }

            i = 0;
            foreach (var tweet in finalList)
            {
                i++;
                new LikeRetweet(tweet.Id);
                if (i == MaxTweetNumber)
                {
                    Thread.Sleep(SleepDuration);
                    Credentials.EnsureAuthenticate();
                }
            }

            //...
        }
    }
}
