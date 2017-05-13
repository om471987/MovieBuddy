using System;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System.Collections.Generic;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;
using System.Linq;
using System.Reflection;
using MovieBuddy.Helper;
using MovieBuddy.Factories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace MovieBuddy
{
    public class Function
    {
        public SkillResponse FunctionHandler(SkillRequest skillRequest, ILambdaContext context)
        {
            try
            {
                var requestService = RequestFactory.Get(skillRequest);
                var output = requestService.Execute();
                var card = output.Response?.Card == null ? null : (SimpleCard)output.Response.Card;
                return output;
            }
            catch
            {
                var speechOutput = "Sorry I did not understand. Please create order or check status";
                return new SkillResponse
                {
                    Response = new Response
                    {
                        OutputSpeech = new PlainTextOutputSpeech
                        {
                            Text = speechOutput
                        }
                    }
                };
            }
        }
    }
}