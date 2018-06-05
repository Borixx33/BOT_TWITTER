using Microsoft.Extensions.Configuration;
using System;
using Tweetinvi;
using Tweetinvi.Exceptions;

namespace tweetbotClasses
{
    public class TwitterBotCredentials
    {
        private TwitterBotCredentials()
        {
        }

        public string ConsumerKey { get; private set; }
        public string ConsumerKeySecret { get; private set; }
        public string AccessToken { get; private set; }
        public string AccessTokenSecret { get; private set; }

        public static TwitterBotCredentials Create(IConfiguration configuration)
        {
            TwitterBotCredentials item = new TwitterBotCredentials();
            item.ConsumerKey = configuration["credentials:consumerKey"];
            item.ConsumerKeySecret = configuration["credentials:consumerKeySecret"];
            item.AccessToken = configuration["credentials:accessToken"];
            item.AccessTokenSecret = configuration["credentials:accessTokenSecret"];
            return item;
        }

        public void Authenticate()
        {
            Auth.SetUserCredentials(ConsumerKey, ConsumerKeySecret, AccessToken, AccessTokenSecret);
        }

        public void EnsureAuthenticate()
        {
            try
            {
                if (User.GetAuthenticatedUser() != null)
                {
                    return;
                }

                Authenticate();
            }
            catch(TwitterNullCredentialsException)
            {
                Authenticate();
            }
        }
    }
}
