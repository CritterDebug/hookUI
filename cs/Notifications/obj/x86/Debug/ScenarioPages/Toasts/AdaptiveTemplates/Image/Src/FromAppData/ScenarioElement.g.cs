﻿#pragma checksum "C:\Users\chris\Documents\HookUI\cs\Notifications\ScenarioPages\Toasts\AdaptiveTemplates\Image\Src\FromAppData\ScenarioElement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CA7AD714415FE46043824AA149E6A6B900E78CE5C4D3EA7D845F2607D493514A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notifications.ScenarioPages.Toasts.AdaptiveTemplates.Image.Src.FromAppData
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
            case 1: // ScenarioPages\Toasts\AdaptiveTemplates\Image\Src\FromAppData\ScenarioElement.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                    ((global::Windows.UI.Xaml.Controls.UserControl)element1).Loaded += this.UserControl_Loaded;
                }
                break;
            case 2: // ScenarioPages\Toasts\AdaptiveTemplates\Image\Src\FromAppData\ScenarioElement.xaml line 12
                {
                    this.stepsControl = (global::Notifications.Controls.StepsControl)(target);
                }
                break;
            case 3: // ScenarioPages\Toasts\AdaptiveTemplates\Image\Src\FromAppData\ScenarioElement.xaml line 28
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 4: // ScenarioPages\Toasts\AdaptiveTemplates\Image\Src\FromAppData\ScenarioElement.xaml line 18
                {
                    this.popToastControl = (global::Notifications.Controls.PopToastControl)(target);
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

