using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Intent
{
    public interface IIntent
    {
        SkillRequest SkillRequest { get; set; }
        SkillResponse SkillResponse { get; set; }
        string SuccessResponse { get; set; }
        string ReprontResponse { get; set; }
        string CardTitle { get; set; }
        string CardContent { get; set; }
        bool ParseAndValidate();
        SkillResponse Execute();
    }
}
