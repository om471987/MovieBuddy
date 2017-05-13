using MovieBuddy.Helper;
using MovieBuddy.Services;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Intent
{
    public class GenreIntent : IIntent
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public string SuccessResponse { get; set; }
        public string ReprontResponse { get; set; }
        public string CardTitle { get; set; }
        public string CardContent { get; set; }
        public GenreIntent(SkillRequest skillRequest)
        {
            string previousMovie = null;
            if (skillRequest.Session.Attributes.IsNotNull() && skillRequest.Session.Attributes.ContainsKey("previousMovie"))
            {
                previousMovie = (string)skillRequest.Session.Attributes["previousMovie"];
            }
            SkillRequest = skillRequest;
            var genre = skillRequest.Request.Intent.Slots["Genre"].Value;
            var movie = MovieService.Get(genre, previousMovie);
            if (movie.IsNull())
            {
                SuccessResponse = "No movie to recomment for genre " + genre;
            }
            else
            {
                SuccessResponse = "Famous movie in genre " + genre + " is " + movie;
            }
            if (skillRequest.Session.Attributes.IsNull())
            {
                var dictionary = new Dictionary<string, object>();
                dictionary["previousMovie"] = movie;
                skillRequest.Session.Attributes = dictionary;
            }
            else
            {
                skillRequest.Session.Attributes["previousMovie"] = movie;
            }
        }
        public bool ParseAndValidate()
        {
            var reponse = true;
            return reponse;
        }
        public SkillResponse Execute()
        {
            return new SkillResponse
            {
                Response = new Response
                {
                    ShouldEndSession = false,
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = SuccessResponse
                    }
                },
                SessionAttributes = SkillRequest.Session.Attributes
            };
        }
    }
}
