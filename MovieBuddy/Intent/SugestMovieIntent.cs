using MovieBuddy.Services;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

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
            SkillRequest = skillRequest;
            SuccessResponse = "I want to suggest you movie " + MovieService.Get();
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
