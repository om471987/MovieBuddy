using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Intent
{
    public class CancelIntent: IIntent
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public string SuccessResponse { get; set; }
        public string ReprontResponse { get; set; }
        public string CardTitle { get; set; }
        public string CardContent { get; set; }
        public CancelIntent(SkillRequest skillRequest)
        {
            SkillRequest = skillRequest;
        }
        public bool ParseAndValidate()
        {
            SuccessResponse = "Alright";
            CardTitle = "StopVideo";
            CardContent = "StopVideo";
            return true;
        }
        public SkillResponse Execute()
        {
            return new SkillResponse
            {
                Response = new Response
                {
                    ShouldEndSession = true,
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = SuccessResponse
                    },
                    Card = new SimpleCard
                    {
                        Title = CardTitle,
                        Content = CardContent
                    }
                },
                SessionAttributes = SkillRequest.Session.Attributes
            };
        }
    }
}
