using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Request
{
    public interface IRequestService
    {
        SkillRequest SkillRequest { get; set; }
        SkillResponse SkillResponse { get; set; }
        SkillResponse Execute();
    }
}
