namespace Notifications.Model
{
    public static class Scenarios
    {
        public static ScenarioGroup MainGroup = new ScenarioGroup("Main Page", new IScenario[]
        {

            new ScenarioGroup("Go to toast selection ", new IScenario[]
            {

                new ScenarioGroup("activation types", new IScenario[]
                {
                    new Scenario("foreground with app open", typeof(ScenarioPages.Toasts.ActivationTypes.ForegroundWithAppOpen.ScenarioElement)),
                    new Scenario("foreground with app closed", typeof(ScenarioPages.Toasts.ActivationTypes.ForegroundWithAppClosed.ScenarioElement)),
                    new Scenario("background with app open", typeof(ScenarioPages.Toasts.ActivationTypes.BackgroundWithAppOpen.ScenarioElement)),
                    new Scenario("background with app closed", typeof(ScenarioPages.Toasts.ActivationTypes.BackgroundWithAppClosed.ScenarioElement)),
                    new Scenario("protocol", typeof(ScenarioPages.Toasts.ActivationTypes.Protocol.ScenarioElement)),
                    new ScenarioGroup("system", new IScenario[]
                    {
                        new ScenarioGroup("Snooze", new IScenario[]
                        {
                            new Scenario("Auto Content", typeof(ScenarioPages.Toasts.ActivationTypes.System.Snooze.AutoContent.ScenarioElement)),
                            new Scenario("Custom Content", typeof(ScenarioPages.Toasts.ActivationTypes.System.Snooze.CustomContent.ScenarioElement)),
                            new Scenario("Snoozing", typeof(ScenarioPages.Toasts.ActivationTypes.System.Snooze.Snoozing.ScenarioElement))
                        }),

                        new ScenarioGroup("Dismiss", new IScenario[]
                        {
                            new Scenario("Auto Content", typeof(ScenarioPages.Toasts.ActivationTypes.System.Dismiss.AutoContent.ScenarioElement)),
                            new Scenario("Custom Content", typeof(ScenarioPages.Toasts.ActivationTypes.System.Dismiss.CustomContent.ScenarioElement)),
                            new Scenario("Dismissing", typeof(ScenarioPages.Toasts.ActivationTypes.System.Dismiss.Dismissing.ScenarioElement))
                        })
                    })
                }),

                new Scenario("expiring toast", typeof(ScenarioPages.Toasts.ExpiringToast.ScenarioElement)),
                new Scenario("ghost toast", typeof(ScenarioPages.Toasts.GhostToast.ScenarioElement)),

                new ScenarioGroup("scenarios", new IScenario[]
                {
                    new Scenario("scenario: default", typeof(ScenarioPages.Toasts.Scenarios.Default.ScenarioElement)),
                    new Scenario("scenario: alarm", typeof(ScenarioPages.Toasts.Scenarios.Alarm.ScenarioElement)),
                    new Scenario("scenario: reminder", typeof(ScenarioPages.Toasts.Scenarios.Reminder.ScenarioElement)),
                    new Scenario("scenario: incomingCall", typeof(ScenarioPages.Toasts.Scenarios.IncomingCall.ScenarioElement))
                }),

                new ScenarioGroup("ToastNotificationManager.History", new IScenario[]
                {
                    new ScenarioGroup("Remove(...)", new IScenario[]
                    {
                        new Scenario("Remove(tag)", typeof(ScenarioPages.Toasts.ToastNotificationManagerHistory.Remove.ByTag.ScenarioElement)),
                        new Scenario("Remove(tag, group)", typeof(ScenarioPages.Toasts.ToastNotificationManagerHistory.Remove.ByTagAndGroup.ScenarioElement))
                    }),

                    new ScenarioGroup("RemoveGroup(...)", new IScenario[]
                    {
                        new Scenario("RemoveGroup(group)", typeof(ScenarioPages.Toasts.ToastNotificationManagerHistory.RemoveGroup.ByGroup.ScenarioElement))
                    }),

                    new Scenario("Clear()", typeof(ScenarioPages.Toasts.ToastNotificationManagerHistory.ClearAll.ScenarioElement)),

                    new ScenarioGroup("GetHistory()", new IScenario[]
                    {
                        new Scenario("Visualizer", typeof(ScenarioPages.Toasts.ToastNotificationManagerHistory.GetHistory.Visualizer.ScenarioElement))
                    })
                }),

                 new ScenarioGroup("ToastNotificationHistoryChangedTrigger", new IScenario[] {
                    new Scenario("Responding to toast removal", typeof(ScenarioPages.Toasts.HistoryChangedTrigger.RespondingToToasts.ScenarioElement)),
                    new Scenario("Update badge on toast dismissal", typeof(ScenarioPages.Toasts.HistoryChangedTrigger.BadgeControl.ScenarioElement))
                }),

            })
        });
    }
}
