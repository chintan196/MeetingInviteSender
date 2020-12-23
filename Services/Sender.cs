using Microsoft.Extensions.Options;
using SendCalendarInviteEmail.Entities;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SendCalendarInviteEmail.Services
{
    public class Sender : ISender
    {
        private readonly ApplicationSettings _applicationSettings;

        public Sender(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;
        }

        public void SendEmail(SmtpType smtp, MeetingDetail meeting)
        {
            var smtpDetails = _applicationSettings.AvailableProviders.Single(s => s.SmtpType == smtp);

            // Get ICS file specific to SMTP
            var ics = TransformAndConvertIcs(meeting, smtpDetails.SmtpType);


            // Prepare mail
            MailMessage msg = new MailMessage();
            msg.Headers.Add("method", "REQUEST");
            msg.Headers.Add("charset", "UTF-8");
            msg.Headers.Add("component", "VEVENT");

            msg.From = new MailAddress(smtpDetails.UserName);

            foreach (var participant in meeting.Participants)
            {
                msg.To.Add(new MailAddress(participant.Email, participant.Name));
            }
            msg.Subject = meeting.Subject;

            // Set credentials
            NetworkCredential creds = new NetworkCredential(smtpDetails.UserName, smtpDetails.Password);

            // Prepare client
            var client = new SmtpClient(smtpDetails.Host, smtpDetails.Port);
            client.EnableSsl = true;
            client.Credentials = creds;

            // Add ICS
            ContentType ct = new ContentType("text/calendar;method=REQUEST");
            ct.Parameters.Add("Content-ID", "calendar_message");
            ct.Parameters.Add("Content-Class", "urn:content-classes:calendarmessage");


            AlternateView calendar = AlternateView.CreateAlternateViewFromString(ics, ct);
            msg.AlternateViews.Add(calendar);

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw new Exception("There was some problem while sending email using SMTP client", ex);
            }
        }

        private string TransformAndConvertIcs<T>(T entity, SmtpType smtp)
        {
            try
            {
                string result;
                var meetingTemplate = $"MeetingTemplates/{smtp}.xslt";
                var assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var path = Path.Combine(assemblyPath, meetingTemplate);
                byte[] byteArray = File.ReadAllBytes(path);

                if (byteArray.Length == 0)
                {
                    throw new Exception("XSLT Template was not found for given SMTP Type");
                }

                using (var xsltStream = new MemoryStream(byteArray))
                {
                    XmlSerializer x = new XmlSerializer(entity.GetType());
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);

                    using (var xmlStream = new MemoryStream())
                    {
                        x.Serialize(xmlStream, entity, ns);
                        result = XSLTransformer.Transform(xmlStream, xsltStream);

                        // remove xml element
                        result = Regex.Replace(result, "<[^>]*(>|$)", string.Empty).Replace(@"[\s\r\n]+", "");
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("There was some problem while transforming ICS content", ex);
            }
        }
    }
}
