using MovieBuddy.Request;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Factories
{
    public static class RequestFactory
    {
        public static IRequestService Get(SkillRequest request)
        {
            switch (request.Request.Type)
            {
                case "LaunchRequest":
                    return new LaunchRequest(request);
                case "IntentRequest":
                    return new IntentRequest(request);
                case "SessionEndedRequest":
                    return new SessionEndedRequest(request);
                default:
                    throw new Exception();
            }
        }
    }
}
