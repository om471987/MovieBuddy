using MovieBuddy.Helper;
using MovieBuddy.Intent;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace MovieBuddy.Request
{
    public class IntentRequest : IRequestService
    {
        public SkillRequest SkillRequest { get; set; }
        public SkillResponse SkillResponse { get; set; }
        public IntentRequest(SkillRequest skillRequest)
        {
            SkillRequest = skillRequest;
        }
        public SkillResponse Execute()
        {
            var intent = IntentFactory.Get(SkillRequest);
            SkillResponse = (IsValidIntent() && intent.ParseAndValidate()) ? intent.Execute() : intent.SkillResponse;
            return SkillResponse;
        }
        private bool IsValidIntent()
        {
            var currentIntent = SkillRequest?.Request?.Intent?.Name;
            SkillResponse = currentIntent.IsNull() ?
                            new SkillResponse
                            {
                                Response = new Response
                                {
                                    OutputSpeech = new PlainTextOutputSpeech
                                    {
                                        Text = "Sorry given Intent is not configured"
                                    }
                                }
                            } : null;
            return currentIntent.IsNotNullOrEmpty();
        }
    }
}