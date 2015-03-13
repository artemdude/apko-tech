﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APKO.Resources.Models.Account {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ValidationStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("APKO.Resources.Models.Account.ValidationStrings", typeof(ValidationStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A username for that e-mail address already exists. Please enter a different e-mail address..
        /// </summary>
        public static string DuplicateEmail {
            get {
                return ResourceManager.GetString("DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username already exists. Please enter a different user name..
        /// </summary>
        public static string DuplicateUserName {
            get {
                return ResourceManager.GetString("DuplicateUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is incorrect.
        /// </summary>
        public static string IncorrectEmail {
            get {
                return ResourceManager.GetString("IncorrectEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user name or password provided is incorrect..
        /// </summary>
        public static string IncorrectPasswordOrLogin {
            get {
                return ResourceManager.GetString("IncorrectPasswordOrLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current password is incorrect or the new password is invalid..
        /// </summary>
        public static string IncorrectPasswords {
            get {
                return ResourceManager.GetString("IncorrectPasswords", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password retrieval answer provided is invalid. Please check the value and try again..
        /// </summary>
        public static string InvalidAnswer {
            get {
                return ResourceManager.GetString("InvalidAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The e-mail address provided is invalid. Please check the value and try again..
        /// </summary>
        public static string InvalidEmail {
            get {
                return ResourceManager.GetString("InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password provided is invalid. Please enter a valid password value..
        /// </summary>
        public static string InvalidPassword {
            get {
                return ResourceManager.GetString("InvalidPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password retrieval question provided is invalid. Please check the value and try again..
        /// </summary>
        public static string InvalidQuestion {
            get {
                return ResourceManager.GetString("InvalidQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user name provided is invalid. Please check the value and try again..
        /// </summary>
        public static string InvalidUserName {
            get {
                return ResourceManager.GetString("InvalidUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} must be min {1} characters.
        /// </summary>
        public static string MinPasswordLength {
            get {
                return ResourceManager.GetString("MinPasswordLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator..
        /// </summary>
        public static string ProviderError {
            get {
                return ResourceManager.GetString("ProviderError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field is required.
        /// </summary>
        public static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must be under {1} characters.
        /// </summary>
        public static string StringLength {
            get {
                return ResourceManager.GetString("StringLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator..
        /// </summary>
        public static string UnknownError {
            get {
                return ResourceManager.GetString("UnknownError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator..
        /// </summary>
        public static string UserRejected {
            get {
                return ResourceManager.GetString("UserRejected", resourceCulture);
            }
        }
    }
}
