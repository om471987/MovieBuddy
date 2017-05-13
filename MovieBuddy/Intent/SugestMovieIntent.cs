using MovieBuddy.Helper;
using MovieBuddy.Services;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System.Collections.Generic;

namespace MovieBuddy.Intent
{
    public class SugestMovieIntent : IIntent
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public string SuccessResponse { get; set; }
        public string ReprontResponse { get; set; }
        public string CardTitle { get; set; }
        public string CardContent { get; set; }
        public SugestMovieIntent(SkillRequest skillRequest)
        {
            string previousMovie = null;
            if (skillRequest.Session.Attributes.IsNotNull() && skillRequest.Session.Attributes.ContainsKey("previousMovie"))
            {
                previousMovie = (string)skillRequest.Session.Attributes["previousMovie"];
            }
            SkillRequest = skillRequest;
            var movie = MovieService.Get(null, previousMovie);
            SuccessResponse = "I want to suggest you movie " + movie;
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
