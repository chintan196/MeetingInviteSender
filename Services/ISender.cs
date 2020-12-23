using SendCalendarInviteEmail.Entities;
using System.Threading.Tasks;

namespace SendCalendarInviteEmail.Services
{
    public interface ISender
    {
        void SendEmail(SmtpType smtp, MeetingDetail meeting);
    }
}
