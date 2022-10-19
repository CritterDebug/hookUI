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


namespace Notifications
{
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
            
            // if (listener.GetAccessStatus() == UserNotificationListenerAccessStatus.Unspecified)
            // {
                UserNotificationListenerAccessStatus accessStatus = await listener.RequestAccessAsync();

                switch (accessStatus)
                {
                    case UserNotificationListenerAccessStatus.Allowed:
                        System.Diagnostics.Debug.WriteLine("Yayy listener access is allowed");
                        break;
                    case UserNotificationListenerAccessStatus.Denied:
                        System.Diagnostics.Debug.WriteLine("Oops listener access is denied");
                        break;
                    case UserNotificationListenerAccessStatus.Unspecified:
                        System.Diagnostics.Debug.WriteLine("Oops listener access is unspecified");
                        break;
                }
            //}

            System.Diagnostics.Debug.WriteLine(listener.GetAccessStatus());

        }

        protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            var deferral = args.TaskInstance.GetDeferral();

            System.Diagnostics.Debug.WriteLine("yoooo");

            switch (args.TaskInstance.Task.Name)
            {
                case "UserNotificationChanged":

                    System.Diagnostics.Debug.WriteLine("Background listener is activated");
   
                    UserNotificationListener listener = UserNotificationListener.Current;

                    if (listener.GetAccessStatus() == UserNotificationListenerAccessStatus.Denied)
                    {
                        System.Diagnostics.Debug.WriteLine("Caught the permission as it was denied");
                        return;
                    }

                    IReadOnlyList<UserNotification> notifs = await listener.GetNotificationsAsync(NotificationKinds.Toast);

                    //if (notifs.Count == 0)
                    //{
                    //    System.Diagnostics.Debug.WriteLine("Caught as size was 0");
                    //    return;
                    //}

                    UserNotification notif = notifs[notifs.Count - 1];
                    // UserNotification notif = notifs[0];

                    // Get the app's display name
                    string appName = notif.AppInfo.DisplayInfo.DisplayName;
                    string appDescription = "";
                    string packageName = "";
           
                    // Get the app's logo
                    BitmapImage appLogo = new BitmapImage();

                    try
                    {
                        RandomAccessStreamReference appLogoStream = notif.AppInfo.DisplayInfo.GetLogo(new Size(10, 10));
                        
                        if (appLogoStream != null)
                        {
                            System.Diagnostics.Debug.WriteLine("There is an image somewhere");
                            await appLogo.SetSourceAsync(await appLogoStream.OpenReadAsync());
                        } else
                        {
                            System.Diagnostics.Debug.WriteLine("It was null");
                        }
                    }
                    catch (NullReferenceException nre)
                    {
                        System.Diagnostics.Debug.WriteLine(nre);
                    }

                    NotificationBinding toastBinding = notif.Notification.Visual.GetBinding(KnownNotificationBindings.ToastGeneric);

                    if (appName.Equals("Discord"))
                    {
                        appDescription = notif.AppInfo.DisplayInfo.Description;
                        packageName = notif.AppInfo.PackageFamilyName;
                        string sender = "";
                        string msgContent = "";

                        if (toastBinding != null)
                        {
                            // And then get the text elements from the toast binding
                            IReadOnlyList<AdaptiveNotificationText> textElements = toastBinding.GetTextElements();

                            // Treat the first text element as the title text
                            sender = textElements.FirstOrDefault()?.Text;

                            // We'll treat all subsequent text elements as body text, joining them together via newlines.
                            msgContent = string.Join("\n", textElements.Skip(1).Select(t => t.Text));

                        }

                        System.Diagnostics.Debug.WriteLine("App Name: " + appName);
                        System.Diagnostics.Debug.WriteLine("App Description: " + appDescription);
                        System.Diagnostics.Debug.WriteLine("Package Name: " + packageName);
                        System.Diagnostics.Debug.WriteLine("Sender: " + sender);
                        System.Diagnostics.Debug.WriteLine("Content: " + msgContent);

                    }

                    break;
            }

            deferral.Complete();
        }

    }
}