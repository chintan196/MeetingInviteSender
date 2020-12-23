# MeetingInviteSender
This repository contains a small project (dotnet core 3.1) to send meeting invites to list of participants using Microsoft or Google as SMTP.

It also has logic to transform C# entity to any string content from C# Objects/Entities. - XSLT Transformation (This can be used to generate ICS Calender Invites and HTML Body for emails)

Owner of this project : Chintan Desai - chintansdesai@gmail.com
Email template reference: These templates are defined using reference from "Internet Calendaring and Scheduling Core Object Specification"
More details on the same can be found on https://tools.ietf.org/html/rfc5545#section-3.2.17

Please note that for your meeting invitations to be displayed properly by clients (Gmail, Outlook) its compulsory to use the same email (email address specified as User Name for SMTP) as an Organiser for the meeting, otherwise some client will not parse ICS correctly.

