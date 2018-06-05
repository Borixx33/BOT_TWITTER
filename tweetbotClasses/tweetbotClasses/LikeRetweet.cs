using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace tweetbotClasses
{
    class LikeRetweet
    {
        public LikeRetweet(long id)
        {
            Tweet.FavoriteTweet(id);
            Tweet.PublishRetweet(id);
        }
    }
}
