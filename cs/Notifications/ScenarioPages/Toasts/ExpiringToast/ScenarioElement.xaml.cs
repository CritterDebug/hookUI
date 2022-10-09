using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Notifications.ScenarioPages.Toasts.ExpiringToast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScenarioElement : UserControl
    {
        private static readonly string BACKGROUND_TASK_NAME = "ToastNotificationsListener";

        public ScenarioElement()
        {
            this.InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {

            base.IsEnabled = false;

            // Clear all existing notifications
            ToastNotificationManager.History.Clear();

            // Register background task
            if (!await RegisterBackgroundTask())
            {
                await new MessageDialog("ERROR: Couldn't register background task.").ShowAsync();
                return;
            }

            System.Diagnostics.Debug.WriteLine("Made it");
            base.IsEnabled = true;

            // Clear all existing notifications
            ToastNotificationManager.History.Clear();

            var longTime = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
            DateTimeOffset expiryTime = DateTime.Now.AddSeconds(30);
            string expiryTimeString = longTime.Format(expiryTime);

            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            //Find the text component of the content
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Set the text on the toast. 
            // The first line of text in the ToastText02 template is treated as header text, and will be bold.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Expiring Toast"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode("It will expire at " +  expiryTimeString));

            // Set the duration on the toast
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the actual toast object using this toast specification.
            ToastNotification toast = new ToastNotification(toastXml);

            toast.ExpirationTime = expiryTime;

            // Send the toast.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private async Task<bool> RegisterBackgroundTask()
        {
            /*
            // Unregister any previous exising background task
            UnregisterBackgroundTask();

            // Request access
            BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();

            // If denied
            if (status != BackgroundAccessStatus.AlwaysAllowed && status != BackgroundAccessStatus.AllowedSubjectToSystemPolicy)
                return false;

            // Construct the background task
            BackgroundTaskBuilder builder = new BackgroundTaskBuilder()
            {
                Name = BACKGROUND_TASK_NAME,
                TaskEntryPoint = "BackgroundTasks.ToastNotificationsListener"
            };

            // Set trigger for Toast History Changed
            builder.SetTrigger(new UserNotificationChangedTrigger(NotificationKinds.Toast));


            // And register the background task
            BackgroundTaskRegistration registration = builder.Register();
            */

            if (!BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals("UserNotificationChanged")))
            {
                // Specify the background task
                var builder = new BackgroundTaskBuilder()
                {
                    Name = "UserNotificationChanged"
                };

                // Set the trigger for Listener, listening to Toast Notifications
                builder.SetTrigger(new UserNotificationChangedTrigger(NotificationKinds.Toast));

                // Register the task
                builder.Register();
            }

            return true;
        }

        private static void UnregisterBackgroundTask()
        {
            var task = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(i => i.Name.Equals(BACKGROUND_TASK_NAME));

            if (task != null)
                task.Unregister(true);
        }

    }

}
