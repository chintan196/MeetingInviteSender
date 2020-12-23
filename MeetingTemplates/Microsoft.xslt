<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">BEGIN:VCALENDAR
METHOD:REQUEST
SEQUENCE:0
PRODID:Microsoft Exchange Server 2010
VERSION:2.0
BEGIN:VEVENT
ORGANIZER;CN=<xsl:value-of select="MeetingDetail/Organiser/Email"/>:mailto:<xsl:value-of select="MeetingDetail/Organiser/Email"/>
<xsl:for-each select="MeetingDetail/Participants/Participant">
ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=<xsl:value-of select="RoleTag"/>;PARTSTAT=NEEDS-ACTION;RSVP=TRUE;CN=<xsl:value-of select="Email"/>:mailto:<xsl:value-of select="Email"/>
</xsl:for-each>
DESCRIPTION;LANGUAGE=en-US:<xsl:value-of select="MeetingDetail/Body"/>
UID:<xsl:value-of select="MeetingDetail/MeetingUniqueId"/>@outlook.com
SUMMARY;LANGUAGE=en-US:<xsl:value-of select="MeetingDetail/Subject"/>
DTSTART:<xsl:value-of select="MeetingDetail/StartTimeString"/>
DTEND:<xsl:value-of select="MeetingDetail/EndTimeString"/>
CLASS:PUBLIC
PRIORITY:5
DTSTAMP:<xsl:value-of select="MeetingDetail/ScheduleTimeString"/>
TRANSP:OPAQUE
STATUS:CONFIRMED
LOCATION;LANGUAGE=en-US:Online
X-MICROSOFT-CDO-APPT-SEQUENCE:0
X-MICROSOFT-CDO-BUSYSTATUS:TENTATIVE
X-MICROSOFT-CDO-INTENDEDSTATUS:BUSY
X-MICROSOFT-CDO-ALLDAYEVENT:FALSE
X-MICROSOFT-CDO-IMPORTANCE:1
X-MICROSOFT-CDO-INSTTYPE:0
X-MICROSOFT-ONLINEMEETINGEXTERNALLINK:
X-MICROSOFT-ONLINEMEETINGCONFLINK:
X-MICROSOFT-DONOTFORWARDMEETING:FALSE
X-MICROSOFT-DISALLOW-COUNTER:FALSE
X-MICROSOFT-LOCATIONS:[]
BEGIN:VALARM
DESCRIPTION:REMINDER
TRIGGER;RELATED=START:-PT15M
ACTION:DISPLAY
END:VALARM
END:VEVENT
END:VCALENDAR
</xsl:template>
</xsl:stylesheet>