using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Core
{
    public class DefaultSettingSingleton
    {
        private static volatile DefaultSettingSingleton _instance; //Singleton instance
        private static object syncRoot = new Object();
        private DefaultSettingSingleton() { }

        public static DefaultSettingSingleton Instance
        {
            get
            {
                if (_instance == null) throw new InvalidOperationException("Singleton not created - use Initialize(DefaultSetting settings)");
                return _instance;
            }
        }

        public static void InitializeReInitialize(DefaultSetting settings)
        {// It will be initialized only one time at the bot start phrase, should be thread safe if nobody hacks this !
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new DefaultSettingSingleton
                        {
                            HeaderTextFormat = settings.HeaderTextFormat,
                            BodyTextFormat = settings.BodyTextFormat,
                            DisclaimerTextFormat = settings.DisclaimerTextFormat,
                            MenuOptionTextFormat = settings.MenuOptionTextFormat,
                            MenuNumberTextFormat = settings.MenuNumberTextFormat,
                            ErrorTextFormat = settings.ErrorTextFormat,
                            GoBackTextFormat = settings.GoBackTextFormat,
                            InactivityTimeout = settings.InactivityTimeout,
                            MobileInactivityTimeout = settings.MobileInactivityTimeout,
                            SystemTextSettings = settings.SystemTextSettings,
                            AgentSystemTextSettings = settings.AgentSystemTextSettings
                        };
                    }
                }
            }
            else
            {// update ..
                _instance.HeaderTextFormat = settings.HeaderTextFormat;
                _instance.BodyTextFormat = settings.BodyTextFormat;
                _instance.DisclaimerTextFormat = settings.DisclaimerTextFormat;
                _instance.MenuOptionTextFormat = settings.MenuOptionTextFormat;
                _instance.MenuNumberTextFormat = settings.MenuNumberTextFormat;
                _instance.ErrorTextFormat = settings.ErrorTextFormat;
                _instance.GoBackTextFormat = settings.GoBackTextFormat;
                _instance.InactivityTimeout = settings.InactivityTimeout;
                _instance.MobileInactivityTimeout = settings.MobileInactivityTimeout;
                _instance.SystemTextSettings = settings.SystemTextSettings;
                _instance.AgentSystemTextSettings = settings.AgentSystemTextSettings;

            }

        }
        public string HeaderTextFormat { get; private set; }//CSS styles for menu header text.
        public string BodyTextFormat { get; private set; }//CSS styles for regular text, such as "you have chosen" and instructional text, including footer text.
        public string DisclaimerTextFormat { get; private set; }//CSS styles for the disclaimer text.
        public string MenuOptionTextFormat { get; private set; }//CSS styles for menu item text.
        public string MenuNumberTextFormat { get; private set; }//CSS styles for menu item number text.
        public string ErrorTextFormat { get; private set; }//CSS styles for error messages.
        public string GoBackTextFormat { get; private set; }//CSS styles for the "go back to the previous menu" system text.
        public int InactivityTimeout { get; private set; }//Overrides the default conversation timeout with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        public int MobileInactivityTimeout { get; private set; }//Overrides the default conversation timeout on mobile clients with  a new timeout. Value is in minutes. (optional) Default is 20 minutes. Use 0 for no override.
        public SystemTextSetting SystemTextSettings { get; private set; }//Default system messages with custom text.
        public AgentSystemTextSetting AgentSystemTextSettings { get; private set; }//System messages from the service desk with custom text.

    }
}
