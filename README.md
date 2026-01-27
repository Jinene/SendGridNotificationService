# SendGrid Email Notification Service

A simple .NET 8 ASP.NET Core Web API that sends transactional emails using SendGrid.

## Features
- Send automated notification emails
- REST API endpoint
- SendGrid Email API integration
- Clean architecture (Controller / Service / Models)

## Technologies
- C#
- ASP.NET Core
- SendGrid API
- JSON configuration

## Run the project
1. Add your SendGrid API Key in `appsettings.json`
2. Run:
   ```bash
   dotnet run
POST to /api/notification/send

Example Request
{
  "to": "user@example.com",
  "subject": "Welcome",
  "message": "Your account has been created"
}
