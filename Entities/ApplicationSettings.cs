using System.Collections.Generic;

namespace SendCalendarInviteEmail.Entities
{
    public class ApplicationSettings
    {
        public SmtpType PreferredSmtp { get; set; }
        public List<SmtpSetting> AvailableProviders { get; set; }
    }
}
