﻿#pragma checksum "C:\Users\Chris\Documents\GitHub\hookUI\cs\Notifications\ScenarioPages\Toasts\HistoryChangedTrigger\BadgeControl\ScenarioElement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85482693D41DCE326CD3B7A5A6CE2193D1C0FD561FAE4A652A2DD1148485ED89"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notifications.ScenarioPages.Toasts.HistoryChangedTrigger.BadgeControl
{
    partial class ScenarioElement : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // ScenarioPages\Toasts\HistoryChangedTrigger\BadgeControl\ScenarioElement.xaml line 11
                {
                    this.stepsControl = (global::Notifications.Controls.StepsControl)(target);
                }
                break;
            case 3: // ScenarioPages\Toasts\HistoryChangedTrigger\BadgeControl\ScenarioElement.xaml line 21
                {
                    this.ButtonPinSecondaryTile = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonPinSecondaryTile).Click += this.ButtonPinSecondaryTile_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

