using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OpticalShop.Infrastructure
{
    public class OpticalShopException : Exception
    {
        private Exception originalException;

        public OpticalShopException(Exception exception)
        {
            this.originalException = exception;

            if (HttpContext.Current != null)
            {

                #region User information
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null)
                {
                    
                }
                #endregion

                #region Request parameters (GET,POST)
                if (HttpContext.Current.Request != null)
                {
                    HttpRequest request = HttpContext.Current.Request;

                    this.Data.Add("URL", request.Url.ToString());
                    this.Data.Add("HTTP.Method", request.HttpMethod);

                    if (request.HttpMethod.ToUpper() == "POST")
                    {
                        try
                        {
                            foreach (var postKey in request.Form.AllKeys)
                            {
                                this.Data.Add(string.Format("POST.{0}", postKey), request.Form[postKey]);
                            }
                        }
                        catch (Exception) { }
                    }

                    foreach (var headerKey in request.Headers.Keys)
                    {
                        this.Data.Add("HTTP.Header." + headerKey, request.Headers[headerKey.ToString()]);
                    }

                }
                #endregion

            }
        }

        public override string Message
        {
            get
            {
                return originalException.Message;
            }
        }

        public override string HelpLink
        {
            get
            {
                return originalException.HelpLink;
            }
            set
            {
                this.originalException.HelpLink = value;
            }
        }

        public override string Source
        {
            get
            {
                return originalException.Source;
            }
            set
            {
                this.originalException.Source = value;
            }
        }

        public override string StackTrace
        {
            get
            {

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Format("{0} - {1}", this.GetType().FullName, this.Message));
                sb.AppendLine("\r\n================ Data ==================\r\n");

                foreach (DictionaryEntry keyValue in this.Data)
                {
                    sb.AppendFormat("{0}:\t{1}\r\n", keyValue.Key, keyValue.Value);
                }

                int indent = 1;
                ExtractStackTrace(indent, this.originalException, sb);

                return sb.ToString();
            }
        }

        /// <summary>
        /// Extract all inner exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="sb"></param>
        private void ExtractStackTrace(int indent, Exception exception, StringBuilder sb)
        {
            sb.AppendLine(string.Empty);
            sb.AppendLine("------------------ Inner Exception -------------------");
            string tab = string.Empty;
            for (int i = 0; i <= indent; i++)
                tab += "\t";

            sb.AppendLine(string.Format("{0}{1} - {2}", tab, exception.GetType().FullName, exception.Message));
            sb.AppendLine(tab + "StackTrace:\t" + exception.StackTrace);

            indent++;
            if (exception.InnerException != null)
                ExtractStackTrace(indent, exception.InnerException, sb);
        }
    }
}