﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CellNetixApps.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=cel-sql-011;Initial Catalog=CELLAPPS;Persist Security Info=True;User " +
            "ID=sa;Password=mp789@i")]
        public string CELLAPPSConnectionString {
            get {
                return ((string)(this["CELLAPPSConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=cel-lis-001;Initial Catalog=Tools;Persist Security Info=True;User ID=" +
            "sa;Password=mp789@i")]
        public string ToolsConnectionString {
            get {
                return ((string)(this["ToolsConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=CEL-LIS-001;Initial Catalog=tools;Persist Security Info=True;User ID=" +
            "sa;Password=mp789@i")]
        public string tools_testConnectionString {
            get {
                return ((string)(this["tools_testConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=CEL-LIS-001;Initial Catalog=tools;Persist Security Info=True;User ID=" +
            "sa;Password=mp789@i")]
        public string tools_testConnectionString1 {
            get {
                return ((string)(this["tools_testConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=cel-lis-001;Initial Catalog=PowerPath_prod;Persist Security Info=True" +
            ";User ID=sa;Password=mp789@i")]
        public string PowerPath_95_TestConnectionString {
            get {
                return ((string)(this["PowerPath_95_TestConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=cel-sql-011;Initial Catalog=CELLAPPS;Integrated Security=True")]
        public string CELLAPPSConnectionString1 {
            get {
                return ((string)(this["CELLAPPSConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=CEL-SQL-011;Initial Catalog=CELLAPPS;Persist Security Info=True;User " +
            "ID=sa;Password=mp789@i")]
        public string CELLAPPSConnectionString2 {
            get {
                return ((string)(this["CELLAPPSConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=cel-sql-011;Initial Catalog=Rules;Persist Security Info=True;User ID=" +
            "sa;Password=mp789@i")]
        public string RulesConnectionString {
            get {
                return ((string)(this["RulesConnectionString"]));
            }
        }
    }
}
