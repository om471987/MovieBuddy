//using System;
//using Newtonsoft.Json;
//using Amazon.Lambda.Core;
//using MovieBuddy.Models;
//using MovieBuddy.Services;
//using VenueLambda.Models;
//using Slight.Alexa.Framework.Models.Requests;
//using Slight.Alexa.Framework.Models.Responses;
//using System.Collections.Generic;
//using Slight.Alexa.Framework.Models.Requests.RequestTypes;
//using System.Linq;
//using System.Reflection;
//using MovieBuddy.Helper;

//// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

//namespace MovieBuddy
//{
//    public class Function
//    {
//        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();

//        public SkillResponse FunctionHandler(SkillRequest skillRequest, ILambdaContext context)
//        {
//            var requestService = RequestFactory.Get(input);
//            if (skillRequest.Request.Intent.IsNull() || skillRequest.Request.Intent.Name != "GetTitleIntent")
//            {
//                return BuildSkillResponse("", "Hey Q what is your title?", "what is your title?", null, false);
//            }
//            else
//            {
//                var titleSlot = skillRequest.Request.Intent.Slots["Title"];
//                _titleList.ForEach(t => t.Replace(":", " ").Replace("-", " "));
//                var titleName = _titleList.SingleOrDefault(t => string.Equals(t, titleSlot.Value, StringComparison.OrdinalIgnoreCase));
//                if (titleName == null)
//                {
//                    if(titleSlot.Value != null)
//                    {
//                        return BuildSkillResponse(skillRequest.Request.Intent.Name, "You selected " + titleSlot.Value, "Hey Q what is you title?", skillRequest.Session.Attributes, false);
//                    }
//                    return BuildSkillResponse("", "Hey Q what is your title?", "what is your title?", null, false);
//                }
//                return BuildSkillResponse(skillRequest.Request.Intent.Name, titleName + " was found", "Hey Q what is you title?", skillRequest.Session.Attributes, false);
//            }
//        }
//    }
//}