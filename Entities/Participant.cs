namespace SendCalendarInviteEmail.Entities
{
    public class Participant
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleValue Role { get; set; }

        public string RoleTag
        {
            get { return Role == RoleValue.Required ? "REQ-PARTICIPANT" : "OPT-PARTICIPANT"; }
            set { }
        }
    }

    public enum RoleValue
    {
        Required = 1,
        Optional = 2
    }
}
