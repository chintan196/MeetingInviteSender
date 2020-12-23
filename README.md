# MeetingInviteSender
This repository contains a small project (dotnet core 3.1) to send meeting invites to list of participants using Microsoft or Google as SMTP.

Meeting Invitations sent using this utility are parsed and displayed properly. I have verified this with Gmail Web and Outlook Web and Windows versions. 

- XSLT Transformation
This project also demonstrates the logic to transform C# object(s) to string content using XSLT Templates.
This can be used to generate template based items like ICS Calender Invites and HTML Body for emails.

Meeting Template Reference: Meeting templates defined under the project are defined by having some references from "Internet Calendaring and Scheduling Core Object Specification".
More details on the same can be found on https://tools.ietf.org/html/rfc5545#section-3.2.17
I also added few additional properties to templates specific for Office365 and Google Calendar support.

Usage Note: Please note that for your meeting invitations to be displayed properly by clients (Gmail, Outlook) I suggest to use the same email (email address specified as User Name for SMTP) as an Organiser for the meeting, otherwise some client will not parse ICS correctly.


Author : Chintan Desai
