using System.Collections.Generic;

namespace SendCalendarInviteEmail.Entities
{
    public class ApplicationSettings
    {
        public List<SmtpSetting> AvailableProviders { get; set; }
    }
}
