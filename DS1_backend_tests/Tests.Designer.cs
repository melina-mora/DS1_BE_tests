﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DS1_backend_tests {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.2.0.0")]
    internal sealed partial class Tests : global::System.Configuration.ApplicationSettingsBase {
        
        private static Tests defaultInstance = ((Tests)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Tests())));
        
        public static Tests Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DEV")]
        public global::TestData.Environments.Environments Environment {
            get {
                return ((global::TestData.Environments.Environments)(this["Environment"]));
            }
            set {
                this["Environment"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("APIM")]
        public global::TestData.Environments.EnvironmentTypes EnvironmentType {
            get {
                return ((global::TestData.Environments.EnvironmentTypes)(this["EnvironmentType"]));
            }
            set {
                this["EnvironmentType"] = value;
            }
        }
    }
}