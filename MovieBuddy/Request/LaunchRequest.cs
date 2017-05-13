using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Request
{
    public class LaunchRequest : IRequestService
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public LaunchRequest(SkillRequest skillRequest)
        {
            SkillRequest = skillRequest;
        }
        public SkillResponse Execute()
        {
            var skillResponse = new SkillResponse
            {
                Response = new Response
                {
                    ShouldEndSession = false,
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = "Hello Welcome to Movie Buddy"
                    }
                }
            };
            return skillResponse;
        }
    }
}