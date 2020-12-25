<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">BEGIN:VCALENDAR
PRODID:-//Google Inc//Google Calendar 70.9054//EN
VERSION:2.0
CALSCALE:GREGORIAN
METHOD:REQUEST
BEGIN:VEVENT
DTSTART:<xsl:value-of select="MeetingDetail/StartTimeString"/>
DTEND:<xsl:value-of select="MeetingDetail/EndTimeString"/>
DTSTAMP:<xsl:value-of select="MeetingDetail/ScheduleTimeString"/>
ORGANIZER;CN=<xsl:value-of select="MeetingDetail/Organiser/Name"/>:mailto:<xsl:value-of select="MeetingDetail/Organiser/Email"/>
UID:<xsl:value-of select="MeetingDetail/MeetingUniqueId"/>@gmail.com
<xsl:for-each select="MeetingDetail/Participants/Participant">
ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=<xsl:value-of select="RoleTag"/>;PARTSTAT=NEEDS-ACTION;RSVP=TRUE;CN=<xsl:value-of select="Name"/>;X-NUM-GUESTS=0:mailto:<xsl:value-of select="Email"/>
</xsl:for-each>
ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=REQ-PARTICIPANT;PARTSTAT=ACCEPTED;RSVP=TRUE;CN=<xsl:value-of select="MeetingDetail/Organiser/Name"/>;X-NUM-GUESTS=0:mailto:<xsl:value-of select="MeetingDetail/Organiser/Email"/>
DESCRIPTION:{#BODY}
X-ALT-DESC;FMTTYPE=text/html:{#BODY}
LAST-MODIFIED:<xsl:value-of select="MeetingDetail/ScheduleTimeString"/>
CLASS:PUBLIC
SEQUENCE:0
STATUS:CONFIRMED
SUMMARY:<xsl:value-of select="MeetingDetail/Subject"/>
TRANSP:OPAQUE
END:VEVENT
END:VCALENDAR
</xsl:template>
</xsl:stylesheet>