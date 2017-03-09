using Microsoft.HockeyApp;
using Microsoft.HockeyApp.DataContracts;
using System;
using System.Collections.Generic;

namespace RootNamespace.Services
{
    public static class AnalyticsService
    {
        //Enable analytics in yout UWP application.
        //1. Create a new app in HockeyApp to get your AppID. With this yout will have User Metrics and Crash Reporting
        //https://support.hockeyapp.net/kb/client-integration-windows-and-windows-phone/how-to-create-an-app-for-windows-application

        //2. Optionally you can explore HockeyApp data in Application Insights using Bridge App where you can get advance metrics, page views, app events...
        //This app already has page navigation tracking implemented. Configuring the Application Insights bridge you can access to this telemetry.
        //https://azure.microsoft.com/blog/access-hockeyapp-data-in-ai-with-hockeyapp-bridge-app/

         
        public static void Initialize()
        {
            //TODO UWPTemplates: Set your HockeyApp AppID here.
            string appID = "00000000000000000000000000000000";

            var telemetryConfig = new TelemetryConfiguration()
            {
                Collectors = WindowsCollectors.Metadata | WindowsCollectors.Session | WindowsCollectors.UnhandledException
            };
            
            var config = HockeyClient.Current.Configure(appID, telemetryConfig);
            config.SetExceptionDescriptionLoader((Exception ex) =>
            {
                return $"Exception HResult: {ex.HResult}";
            });
            
            NavigationService.Navigated += (sender, e)=> TrackPageView(e.SourcePageType.FullName);
        }


        public static void Flush()
            => HockeyClient.Current.Flush();

        public static void TrackDependency(string dependencyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success)
            => HockeyClient.Current.TrackDependency(dependencyName, commandName, startTime, duration, success);

        public static void TrackDependency(DependencyTelemetry telemetry)
            => HockeyClient.Current.TrackDependency(telemetry);

        public static void TrackEvent(string eventName)
            => HockeyClient.Current.TrackEvent(eventName);

        public static void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
            => HockeyClient.Current.TrackEvent(eventName, properties, metrics);

        public static void TrackEvent(EventTelemetry telemetry)
            => HockeyClient.Current.TrackEvent(telemetry);

        public static void TrackException(Exception ex, IDictionary<string, string> properties = null)
            => HockeyClient.Current.TrackException(ex, properties);

        public static void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
            => HockeyClient.Current.TrackMetric(name, value, properties);

        public static void TrackMetric(MetricTelemetry telemetry)
            => HockeyClient.Current.TrackMetric(telemetry);

        public static void TrackPageView(string name)
            => HockeyClient.Current.TrackPageView(name);

        public static void TrackPageView(PageViewTelemetry telemetry)
            => HockeyClient.Current.TrackPageView(telemetry);

        public static void TrackTrace(string message)
            => HockeyClient.Current.TrackTrace(message);

        public static void TrackTrace(string message, SeverityLevel severityLevel)
            => HockeyClient.Current.TrackTrace(message, severityLevel);

        public static void TrackTrace(string message, IDictionary<string, string> properties)
            => HockeyClient.Current.TrackTrace(message, properties);

        public static void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
            => HockeyClient.Current.TrackTrace(message, severityLevel, properties);

        public static void TrackTrace(TraceTelemetry telemetry)
            => HockeyClient.Current.TrackTrace(telemetry);
    }
}
