﻿#pragma checksum "..\..\PokébagWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "54A5A73FA9086F32E900E871C4E653AAA0AC6E9A5FCD0317B53DE822CBF14F7C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PokemonWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PokemonWPF {
    
    
    /// <summary>
    /// PokébagWindow
    /// </summary>
    public partial class PokébagWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvInventory;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbCategory;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortBy;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioasc;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radiodesc;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSort;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\PokébagWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PokemonWPF;component/pok%c3%a9bagwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PokébagWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lvInventory = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.lbCategory = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.cbSortBy = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.radioasc = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.radiodesc = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.btnSort = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\PokébagWindow.xaml"
            this.btnSort.Click += new System.Windows.RoutedEventHandler(this.btnSort_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\PokébagWindow.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

