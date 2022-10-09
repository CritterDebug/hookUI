using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BackgroundTasks.Helpers;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;
using Windows.UI.Xaml.Media.Imaging;

namespace BackgroundTasks
{
    public sealed class ToastNotificationsListener : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            System.Diagnostics.Debug.WriteLine("Notifications are allowed");

        }

    }
}
