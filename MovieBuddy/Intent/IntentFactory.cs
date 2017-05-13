using MovieBuddy.Helper;
using Slight.Alexa.Framework.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Intent
{
    public static class IntentFactory
    {
        public static IIntent Get(SkillRequest skillRequest)
        {
            var currentIntent = skillRequest.Request.Intent.Name;
            switch (currentIntent)
            {
                case "GenreIntent":
                    return new GenreIntent(skillRequest);
                case "SugestMovieIntent":
                    return new SugestMovieIntent(skillRequest);
                case "AlreadtSeenIntent":
                    return new AlreadtSeenIntent(skillRequest);
                case "AMAZON.StopIntent":
                    return new StopIntent(skillRequest);
                case "AMAZON.CancelIntent":
                    return new CancelIntent(skillRequest);
                default:
                    return new UnhandledIntent(skillRequest);
            }
        }
    }
}
