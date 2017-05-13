using MovieBuddy.Helper;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Request
{
    public class SessionEndedRequest : IRequestService
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public SessionEndedRequest(SkillRequest skillRequest)
        {
            SkillRequest = skillRequest;
        }
        public SkillResponse Execute()
        {
            var repront = SkillRequest.Session.Attributes.IsNotNull() && SkillRequest.Session.Attributes.ContainsKey("repront") ? (string)SkillRequest.Session.Attributes["repront"] : "<speak>Sorry I did not understand. Please create order or check status</speak>";

            var skillResponse = new SkillResponse
            {
                Response = new Response
                {
                    ShouldEndSession = false,
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = repront
                    }
                }
            };
            return skillResponse;
        }
    }
}
