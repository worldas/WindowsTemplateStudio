namespace RootNamespace
{
    sealed partial class App : Application
    {
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            //^^            
            Services.AnalyticsService.Initialize();
        }        
    }
}