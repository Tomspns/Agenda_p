using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

public class GoogleCalendarService
{
    private static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
    private static string ApplicationName = "Your Application Name"; // Remplace par le nom de ton application

    public static CalendarService GetCalendarService()
    {
        UserCredential credential;

        // Utiliser le chemin relatif pour le fichier credentials.json
        string credentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client_secret_929336529430-d7k9c4f7bmub1p27o26pqrj51ddqdjq5.apps.googleusercontent.com.json");

        using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }

        return new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
    }

    public static Events ListUpcomingEvents()
    {
        var service = GetCalendarService();
        EventsResource.ListRequest request = service.Events.List("primary");
        request.TimeMin = DateTime.Now; // Utilise TimeMin au lieu de TimeMinDateTimeOffset
        request.MaxResults = 10;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        return request.Execute();
    }
}