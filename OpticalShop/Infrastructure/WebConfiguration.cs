using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OpticalShop.Infrastructure
{
    /// <summary>
    /// Configuration for Presentation
    /// </summary>
    public class WebConfiguration
    {
        private static object objLocker = new object();

        public static string HelpPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.HelpPath"]);
            }
        }

        public static string EmailTemplateHeader
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.EmailTemplateHeader"]);
            }
        }

        public static string EmailTemplateBody
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.EmailTemplateBody"]);
            }
        }

        public static string EmailTemplateBodyLoopTroubleshooting
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.EmailTemplateBodyLoopTroubleshooting"]);
            }
        }

        public static string EmailTemplateBodyLoopWarning
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.EmailTemplateBodyLoopWarning"]);
            }
        }

        public static string EmailTemplateFooter
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.EmailTemplateFooter"]);
            }
        }

        public static string DateFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["SPC.DateFormat"];
            }
        }
        public static string UIDateFormat
        {
            get
            {
                return DateFormat.ToLower();
            }
        }

        public static string TimeFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["SPC.TimeFormat"];
            }
        }

        public static string CurrentLanguageCode
        {
            get
            {
                return DefaultLanguage;
            }
        }

        public static List<string> ValidateImageType
        {
            get
            {
                return new List<string>{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            }
        }

        public static string DefaultLogoPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.DefaultLogo"]);
            }
        }

        /// <summary>
        /// SPC Local Database bath
        /// </summary>
        public static string LocalDatabasePath
        {
            get
            {
                string spcLocalDatabase = ConfigurationManager.AppSettings["SPC.LocalDatabase"];
                spcLocalDatabase = HttpContext.Current.Server.MapPath("~\\" + spcLocalDatabase);
                return spcLocalDatabase;
            }
        }

        public static string CharacteristicConfigFile
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SPC.CharacteristicConfigFile"]);
            }
        }

        public static string DefaultLanguage
        {
            get
            {
                return ConfigurationManager.AppSettings["SPC.DefaultLanguage"];
            }
        }

        private static Dictionary<string, string> _languageMode = null;
        public static Dictionary<string, string> LanguageMode
        {
            get
            {
                try
                {
                    if (_languageMode == null)
                    {
                        lock (objLocker)
                        {
                            _languageMode = new Dictionary<string, string>();
                            string value = ConfigurationManager.AppSettings["SPC.Language"];

                            foreach (string line in value.Split(';'))
                            {
                                _languageMode.Add(line.Split('=').First(), line.Split('=').Last());
                            }
                        }
                    }

                    return _languageMode;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}