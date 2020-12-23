using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SendCalendarInviteEmail.Entities
{
    public class MeetingDetail
    {
        public Participant Organiser { get; set; }
        public List<Participant> Participants { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public string StartTimeString
        {
            get { return $"{StartTime.ToUniversalTime():yyyyMMddTHHmmssZ}"; }
            set { }
        }

        [JsonIgnore]
        public string EndTimeString
        {
            get { return $"{EndTime.ToUniversalTime():yyyyMMddTHHmmssZ}"; }
            set { }
        }

        [JsonIgnore]
        public string ScheduleTimeString
        {
            get { return $"{DateTime.UtcNow:yyyyMMddTHHmmssZ}"; }
            set { }
        }

        [JsonIgnore]
        public string MeetingUniqueId
        {
            get { return Guid.NewGuid().ToString(); }
            set { }
        }
    }
}
