using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using SendCalendarInviteEmail.Entities;
using SendCalendarInviteEmail.Services;

namespace SendCalendarInviteEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly ISender _sender;

        public MeetingController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Send Meeting Invitation to List of contacts
        /// </summary>
        /// <param name="smtp">Preferred smtp. Values = 1 for Microsoft and 2 for Google.</param>
        /// <param name="meeting">Meeting Details</param>
        /// <returns></returns>
        [HttpPost("Send/smtp/{smtp}")]
        public IActionResult SendInvite([FromRoute]SmtpType smtp, [FromBody]MeetingDetail meeting)
        {
            if (smtp == default)
            {
                return BadRequest("Given SMTP Not supported");
            }

            _sender.SendEmail(smtp, meeting);
            return Ok("Meeting invitation sent!");
        }
    }
}
