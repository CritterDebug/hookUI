﻿#pragma checksum "C:\Users\chris\Documents\HookUI\cs\Notifications\Controls\PopToastControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDBD90649EED08FC0AA397920260734AC91C6953B38C660F897544F99CD65607"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notifications.Controls
{
    partial class PopToastControl : 
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
            case 1: // Controls\PopToastControl.xaml line 1
                {
                    this.popToastControl = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                }
                break;
            case 2: // Controls\PopToastControl.xaml line 40
                {
                    this.TextBoxPayload = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Controls\PopToastControl.xaml line 27
                {
                    this.ButtonPopToast = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonPopToast).Click += this.ButtonPopToast_Click;
                }
                break;
            case 4: // Controls\PopToastControl.xaml line 33
                {
                    this.ButtonToggleShowPayload = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonToggleShowPayload).Click += this.ButtonToggleShowPayload_Click;
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

