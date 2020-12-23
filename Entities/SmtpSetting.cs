namespace SendCalendarInviteEmail.Entities
{
    public class SmtpSetting
    {
        public SmtpType SmtpType { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
