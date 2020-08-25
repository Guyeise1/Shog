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

        private static readonly string CONSUMER_KEY = "O5wWiJ26Phnh3Srtkesyd18zn";
        private static readonly string CONSUMER_SECRET = "Nj53N7zLSXd53vWFjdSuvUcwlUehpmvUjzjdxdC6y0jeCUATgy";

        private static readonly string TASTY_SCREEN_NAME = "tasty";
        private static readonly string FOOD_DOT_COM_SCREEEN_NAME = "fooddotcom";
        private static readonly string GORDON_REMSY_SCREEN_NAME = "GordonRamsay";
        private static readonly string WALLA_FOOD_SCREEN_NAME = "WallaFood";

        public static readonly string[] SUPPRTED_TWEETER_PAGES =
        {
            TASTY_SCREEN_NAME,
            FOOD_DOT_COM_SCREEEN_NAME,
            WALLA_FOOD_SCREEN_NAME,
            GORDON_REMSY_SCREEN_NAME


        };


        OAuth2Token tweeterConnection = null;

        private async Task<OAuth2Token> TweeterConnection()
        {
            if (tweeterConnection == null)
            {
                tweeterConnection = await OAuth2.GetTokenAsync(CONSUMER_KEY, CONSUMER_SECRET);
            }

            return tweeterConnection;
        }


        public async Task<TweeterResponse[]> FetchUpdate(string account)
        {
            if (string.IsNullOrWhiteSpace(account) || 
                !SUPPRTED_TWEETER_PAGES.Contains(account, StringComparer.OrdinalIgnoreCase))
            {
                throw new ApplicationException("No support for account " + account);
            }

            account = account.ToLower();

            var connection = await TweeterConnection();

            var request = await connection.Statuses.UserTimelineAsync(screen_name: account, count: 6);

            List<TweeterResponse> tweets = new List<TweeterResponse>();
            foreach(var tweet in request)
            {
                TweeterResponse response = new TweeterResponse()
                {
                    Date = tweet.CreatedAt.ToUnixTimeSeconds(),
                    CreatorName = tweet.User.Name,
                    CreatorImageUrl = tweet.User.ProfileImageUrl,
                    UpdateText = tweet.Text,
                    UpdateUrl = $"https://twitter.com/{account}/status/{tweet.Id}/",
                };
                if (tweet.Entities.Media == null)
                {
                    // Tweet has only text, no images no videos
                    response.Type = "Text";
                    response.VideoUrl = "";
                    response.UpdateImage = "";
                } else if (tweet.ExtendedEntities.Media[0].VideoInfo == null)
                    // Tweet only has images, no text
                {
                    response.Type = "Photo";
                    response.VideoUrl = "";
                    response.UpdateImage = tweet.ExtendedEntities.Media[0].MediaUrl;
                } else
                // Tweet has video in addition to image
                {
                    response.Type = "Video";
                    response.VideoUrl = (from videoOption in tweet.ExtendedEntities.Media[0].VideoInfo.Variants
                                         where videoOption.ContentType.StartsWith("video")
                                         orderby videoOption.Bitrate descending
                                         select videoOption.Url).FirstOrDefault();
                    response.UpdateImage = tweet.ExtendedEntities.Media[0].MediaUrl;
                }

                tweets.Add(response);
                
               
            }


            return tweets.ToArray();

        }
    }
}