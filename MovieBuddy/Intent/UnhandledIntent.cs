﻿using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Intent
{
    public class UnhandledIntent: IIntent
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public string SuccessResponse { get; set; }
        public string ReprontResponse { get; set; }
        public string CardTitle { get; set; }
        public string CardContent { get; set; }
        public UnhandledIntent(SkillRequest skillRequest)
        {
            SkillRequest = skillRequest;
        }
        public bool ParseAndValidate()
        {
            SuccessResponse = "Sorry I did not understand. What should I help you with?";
            return true;
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
