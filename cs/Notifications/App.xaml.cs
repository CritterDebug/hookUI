using BackgroundTasks.Helpers;
using Notifications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=402347&clcid=0x409

namespace Notifications
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public EventHandler<IActivatedEventArgs> Activated;
        
        public static IActivatedEventArgs ActivatedEventArgs;
        public static LaunchActivatedEventArgs LaunchedEventArgs;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.UnhandledException += Application_UnhandledException;

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            LaunchedEventArgs = e;

            Initialize(e);
        }
        
        private void Initialize(IActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                if (Settings.ScenarioToOpenWhenLaunchedOrActivated != null)
                {
                    rootFrame.Navigate(typeof(ScenarioPage), Scenarios.MainGroup.FindScenario(Settings.ScenarioToOpenWhenLaunchedOrActivated));
                }

                else
                {

                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage));
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

            requestNotificationPermission();

        }

        /// <summary>
        /// If the app is closed and something triggers foreground activation, OnLaunched isn't even executed, only OnActivated is executed.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnActivated(IActivatedEventArgs args)
        {
            ActivatedEventArgs = args;

            if (Activated != null)
            {
                Activated(this, args);
            }

            Initialize(args);
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private async void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            
            await new MessageDialog(e.Exception.ToString(), "Unknown Error").ShowAsync();
        }

        private async void requestNotificationPermission()
        {

            UserNotificationListener listener = UserNotificationListener.Current;
            UserNotificationListenerAccessStatus accessStatus = await listener.RequestAccessAsync();
            
            switch (accessStatus)
            {
                case UserNotificationListenerAccessStatus.Allowed:
                    System.Diagnostics.Debug.WriteLine("Listener access is allowed");
                    break;
                case UserNotificationListenerAccessStatus.Denied:
                    System.Diagnostics.Debug.WriteLine("Listener access is denied");
                    break;
                case UserNotificationListenerAccessStatus.Unspecified:
                    System.Diagnostics.Debug.WriteLine("Listener access is unspecified");
                    break;
            }

        }

        protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            var deferral = args.TaskInstance.GetDeferral();

           
            switch (args.TaskInstance.Task.Name)
            {
                case "UserNotificationChanged":

                    System.Diagnostics.Debug.WriteLine("background activated");
                    // Call your own method to process the new/removed notifications
                    // The next section of documentation discusses this code
                    //await MyWearableHelpers.SyncNotifications();
                    UserNotificationListener listener = UserNotificationListener.Current;

                    if (listener.GetAccessStatus() == UserNotificationListenerAccessStatus.Denied)
                    {
                        System.Diagnostics.Debug.WriteLine("Caught the permission as it was denied");
                        return;
                    }

                    IReadOnlyList<UserNotification> notifs = await listener.GetNotificationsAsync(NotificationKinds.Toast);

                    UserNotification notif = notifs[notifs.Count-1];

                    // Get the app's display name
                    string appDisplayName = notif.AppInfo.DisplayInfo.DisplayName;

                    // Get the app's logo
                    BitmapImage appLogo = new BitmapImage();
                    RandomAccessStreamReference appLogoStream = notif.AppInfo.DisplayInfo.GetLogo(new Size(16, 16));
                    //await appLogo.SetSourceAsync(await appLogoStream.OpenReadAsync());

                    System.Diagnostics.Debug.WriteLine("Display Name: " + appDisplayName);
                    System.Diagnostics.Debug.WriteLine("Description : " + notif.AppInfo.DisplayInfo.Description);
                    System.Diagnostics.Debug.WriteLine("Package Name: " + notif.AppInfo.PackageFamilyName);
                    

                    NotificationBinding toastBinding = notif.Notification.Visual.GetBinding(KnownNotificationBindings.ToastGeneric);

                    if (toastBinding != null)
                    {
                        // And then get the text elements from the toast binding
                        IReadOnlyList<AdaptiveNotificationText> textElements = toastBinding.GetTextElements();

                        // Treat the first text element as the title text
                        string titleText = textElements.FirstOrDefault()?.Text;

                        System.Diagnostics.Debug.WriteLine("title: " + titleText);

                        // We'll treat all subsequent text elements as body text,
                        // joining them together via newlines.
                        string bodyText = string.Join("\n", textElements.Skip(1).Select(t => t.Text));

                        System.Diagnostics.Debug.WriteLine("Contents: " + bodyText);

                    }



                    break;
            }

            deferral.Complete();
        }

    }
}
