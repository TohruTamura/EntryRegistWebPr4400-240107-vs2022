﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntryRegistWebPr.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
    internal sealed partial class newFtpServer : global::System.Configuration.ApplicationSettingsBase {
        
        private static newFtpServer defaultInstance = ((newFtpServer)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new newFtpServer())));
        
        public static newFtpServer Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("153.127.49.160")]
        public string ftpServerName {
            get {
                return ((string)(this["ftpServerName"]));
            }
            set {
                this["ftpServerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("153.127.49.160")]
        public string ftpDefaultFolder {
            get {
                return ((string)(this["ftpDefaultFolder"]));
            }
            set {
                this["ftpDefaultFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ftp-user2")]
        public string ftpAccount {
            get {
                return ((string)(this["ftpAccount"]));
            }
            set {
                this["ftpAccount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("darkrope")]
        public string ftpUserPassword {
            get {
                return ((string)(this["ftpUserPassword"]));
            }
            set {
                this["ftpUserPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("153.127.49.160")]
        public string homePageUrl {
            get {
                return ((string)(this["homePageUrl"]));
            }
            set {
                this["homePageUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tTounamentEntry")]
        public string entryFolderName {
            get {
                return ((string)(this["entryFolderName"]));
            }
            set {
                this["entryFolderName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("darkrope")]
        public string WebDbPassword {
            get {
                return ((string)(this["WebDbPassword"]));
            }
            set {
                this["WebDbPassword"] = value;
            }
        }
    }
}
