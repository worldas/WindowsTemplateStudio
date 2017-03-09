using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace RootNamespace.Services
{
    public static class NavigationService
    {
        static NavigationService()
        {
            _frame.Navigated += OnFrameNavigated;
        }

        public static event NavigatedEventHandler Navigated;
        private static Frame _frame = Window.Current.Content as Frame;

        public static void SetNavigationFrame(Frame frame)
        {
            _frame.Navigated -= OnFrameNavigated;
            _frame = frame;
            _frame.Navigated += OnFrameNavigated;
        }

        public static bool CanGoBack => _frame.CanGoBack;
        public static bool CanGoForward => _frame.CanGoForward;

        public static void GoBack() => _frame.GoBack();
        public static void GoForward() => _frame.GoForward();

        public static bool Navigate<T>() where T : Page => _frame.Navigate(typeof(T));
        public static bool Navigate<T>(object parameter) where T : Page => _frame.Navigate(typeof(T), parameter);
        public static bool Navigate<T>(object parameter, NavigationTransitionInfo infoOverride) where T : Page => _frame.Navigate(typeof(T), parameter, infoOverride);

        public static bool Navigate(Type pageType) => _frame.Navigate(pageType);
        public static bool Navigate(Type pageType, object parameter) => _frame.Navigate(pageType, parameter);
        public static bool Navigate(Type pageType, object parameter, NavigationTransitionInfo infoOverride) => _frame.Navigate(pageType, parameter, infoOverride);

        private static void OnFrameNavigated(object sender, NavigationEventArgs e) => Navigated?.Invoke(sender, e);
    }
}