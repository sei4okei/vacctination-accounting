﻿#pragma checksum "..\..\..\Pages\Add.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AE9B8DEF02083322EB9EA7CCD8355B16C0AAC3ADDE68E1039E3104B7EA5079C0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using courseproject.Pages;


namespace courseproject.Pages {
    
    
    /// <summary>
    /// Add
    /// </summary>
    public partial class Add : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MiddleNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CityTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RegionComboBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InsurancePolicyTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/courseproject;component/pages/add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Add.xaml"
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
            
            #line 9 "..\..\..\Pages\Add.xaml"
            ((courseproject.Pages.Add)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FirstNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.LastNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MiddleNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.CityTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.RegionComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.InsurancePolicyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 29 "..\..\..\Pages\Add.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

