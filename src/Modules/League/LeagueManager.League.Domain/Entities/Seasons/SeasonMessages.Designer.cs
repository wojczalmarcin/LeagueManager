﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeagueManager.League.Domain.Entities.Seasons {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SeasonMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SeasonMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LeagueManager.League.Domain.Entities.Seasons.SeasonMessages", typeof(SeasonMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fixture order number cannot be higher than season fixtures count..
        /// </summary>
        internal static string FixtureNumberValidation {
            get {
                return ResourceManager.GetString("FixtureNumberValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fixture with this teams already exists..
        /// </summary>
        internal static string MatchFixtureValidation {
            get {
                return ResourceManager.GetString("MatchFixtureValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting date of the new season cannot be earlier than ending date of season {1}..
        /// </summary>
        internal static string StartingDayValidation {
            get {
                return ResourceManager.GetString("StartingDayValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Season starting in {0} year already exists..
        /// </summary>
        internal static string StartingYearValidation {
            get {
                return ResourceManager.GetString("StartingYearValidation", resourceCulture);
            }
        }
    }
}
