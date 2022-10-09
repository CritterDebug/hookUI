namespace Notifications.Model
{
    public static class Scenarios
    {
        public static ScenarioGroup MainGroup = new ScenarioGroup("notifications scenarios", new IScenario[]
        {

            new ScenarioGroup("toasts", new IScenario[]
            {
                new ScenarioGroup("adaptive templates", new IScenario[]
                {
                    new ScenarioGroup("image", new IScenario[]
                    {
                        new ScenarioGroup("src", new IScenario[]
                        {
                            new Scenario("from app package", typeof(ScenarioPages.Toasts.AdaptiveTemplates.Image.Src.FromAppPackage.ScenarioElement)),
                            new Scenario("from app data", typeof(ScenarioPages.Toasts.AdaptiveTemplates.Image.Src.FromAppData.ScenarioElement)),
                            new Scenario("from internet", typeof(ScenarioPages.Toasts.AdaptiveTemplates.Image.Src.FromInternet.ScenarioElement))
                        })
                    })
                }),

                new ScenarioGroup("actions", new IScenario[]
                {
                    new ScenarioGroup("action (button)", new IScenario[]
                    {
                        new Scenario("text button", typeof(ScenarioPages.Toasts.Actions.Action.Text.ScenarioElement)),
                        new Scenario("text and image button", typeof(ScenarioPages.Toasts.Actions.Action.TextAndImage.ScenarioElement)),
                        new Scenario("quick reply button", typeof(ScenarioPages.Toasts.Actions.Action.QuickReply.ScenarioElement))
                    }),

                    new ScenarioGroup("input text", new IScenario[]
                    {
                        new Scenario("input text - title", typeof(ScenarioPages.Toasts.Actions.InputText.Title.ScenarioElement)),
                        new Scenario("input text - placeholder content", typeof(ScenarioPages.Toasts.Actions.InputText.PlaceholderContent.ScenarioElement)),
                        new Scenario("input text - default input", typeof(ScenarioPages.Toasts.Actions.InputText.DefaultInput.ScenarioElement)),
                        new Scenario("input text - retrieving args", typeof(ScenarioPages.Toasts.Actions.InputText.RetrievingArgs.ScenarioElement))
                    }),

                    new ScenarioGroup("hint-systemCommands", new IScenario[]
                    {
                        new Scenario("SnoozeAndDismiss", typeof(ScenarioPages.Toasts.Actions.SystemCommands.SnoozeAndDismiss.ScenarioElement))
                    })
                }),

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

                new ScenarioGroup("audio", new IScenario[]
                {
                    new Scenario("default", typeof(ScenarioPages.Toasts.Audio.Default.ScenarioElement)),
                    new Scenario("system sound - email", typeof(ScenarioPages.Toasts.Audio.EmailSound.ScenarioElement)),
                    new Scenario("looping", typeof(ScenarioPages.Toasts.Audio.Looping.ScenarioElement)),
                    new Scenario("silent", typeof(ScenarioPages.Toasts.Audio.Silent.ScenarioElement))
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

                new Scenario("update toast", typeof(ScenarioPages.Toasts.UpdateToast.ScenarioElement)),
            })
        });
    }
}
