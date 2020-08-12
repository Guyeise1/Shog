using CoreTweet;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Gosh.Controllers.API
{
    public class TweeterUpdateRetviver : UpdateRetviver
    {

        private readonly string CONSUMER_KEY = "O5wWiJ26Phnh3Srtkesyd18zn";
        private readonly string CONSUMER_SECRET = "Nj53N7zLSXd53vWFjdSuvUcwlUehpmvUjzjdxdC6y0jeCUATgy";


        private readonly string TASTY_SCREEN_NAME = "tasty";

        OAuth2Token tweeterConnection = null;

        private async Task<OAuth2Token> TweeterConnection()
        {
            if (tweeterConnection == null)
            {
                tweeterConnection = await OAuth2.GetTokenAsync(CONSUMER_KEY, CONSUMER_SECRET);
            }

            return tweeterConnection;
        }


        
          

        public async Task<TweeterResponse[]> FetchUpdate(string acount)
        {
            var connection = await TweeterConnection();

            var tasty = await connection.Statuses.UserTimelineAsync(screen_name: TASTY_SCREEN_NAME, count: 5);

            List<TweeterResponse> tweets = new List<TweeterResponse>();
            foreach(var tweet in tasty)
            {
                tweets.Add(new TweeterResponse()
                {
                    Date = tweet.CreatedAt.ToUnixTimeSeconds(),
                    CreatorName = tweet.User.Name,
                    CreatorImageUrl = tweet.User.ProfileImageUrl,
                    Type = tweet.Entities.Media[0].Type,
                    UpdateText = tweet.Text,
                    UpdateUrl = tweet.Entities.Media[0].Url,
                    UpdateImage = tweet.Entities.Media[0].MediaUrl

                }); ;
            }


            return tweets.ToArray();

        }
    }
}