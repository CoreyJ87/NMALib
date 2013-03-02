// By Casey Watson
// http://www.caseywatson.com/
// Refactory and Modifications By Adriano Maia
// http://nma.usk.bz

using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace NMALib
{
    public class NMAClient
    {
        private const string CLIENT_CONFIG_SECTION_NAME = "nmaClient";

        private const string EX_MSG_CLIENT_CONFIG_SECTION_NOT_FOUND =
            "Notify My Android client configuration section [{0}] not found; unable to proceed.";

        private const string POST_NOTIFICATION_BASE_METHOD =
            "notify?apikey={0}&application={1}&description={2}&event={3}&url={4}&priority={5}";

        private const string POST_NOTIFICATION_PROVIDER_PARAMETER = "&developerkey={0}";
        private const string REQUEST_CONTENT_TYPE = "application/x-www-form-urlencoded";
        private const string REQUEST_METHOD_TYPE = "POST";

        private NMAClientConfiguration _clientCfg;

        public NMAClient() : this(null)
        {
        }

        public NMAClient(NMAClientConfiguration clientCfg_)
        {
            if (clientCfg_ == null)
            {
                var cfgSection = ConfigurationManager.GetSection(CLIENT_CONFIG_SECTION_NAME);

                if (cfgSection == null || !(cfgSection is NMAClientConfiguration))
                    throw new InvalidOperationException(String.Format(EX_MSG_CLIENT_CONFIG_SECTION_NOT_FOUND,
                                                                      CLIENT_CONFIG_SECTION_NAME));

                clientCfg_ = (cfgSection as NMAClientConfiguration);
            }

            _clientCfg = clientCfg_;
            _clientCfg.Validate();
        }

        public string PostNotification(NMANotification notification_)
        {
            String theReturn = "";
            notification_.Validate();

            var updateRequest = HttpWebRequest.Create(BuildNotificationRequestUrl(notification_)) as HttpWebRequest;

            updateRequest.ContentLength = 0;
            updateRequest.ContentType = REQUEST_CONTENT_TYPE;
            updateRequest.Method = REQUEST_METHOD_TYPE;

           
          
            try
            {
                HttpWebResponse response = (HttpWebResponse) updateRequest.GetResponse();
                response = (HttpWebResponse) updateRequest.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(reader);
                XmlNode thenode = xmldoc.LastChild.FirstChild;
                if (thenode.Name == "success")
                {
                    theReturn += "Message Sent!";
                    foreach (XmlAttribute att in thenode.Attributes)
                    {

                        theReturn += String.Format("--{0}:{1}", att.Name, att.Value);
                    }
                }
                else
                {
                    theReturn += "Message Not SENT!";
                    theReturn += thenode.InnerText;
                }
                reader.Close();
                if (response != null)
                    response.Close();
                return theReturn;

            }
            catch (WebException e)
            {
                return "Error: Cannot connect to server";
            }
      
        }

        private string BuildNotificationRequestUrl(NMANotification notification_)
        {
            if (!(_clientCfg.BaseUrl.EndsWith("/"))) _clientCfg.BaseUrl += "/";

            var nmaUrlSb = new StringBuilder(_clientCfg.BaseUrl);

            nmaUrlSb.AppendFormat(
                POST_NOTIFICATION_BASE_METHOD,
                HttpUtility.UrlEncode(_clientCfg.ApiKeychain),
                HttpUtility.UrlEncode(_clientCfg.ApplicationName),
                HttpUtility.UrlEncode(notification_.Description),
                HttpUtility.UrlEncode(notification_.Event),
                HttpUtility.UrlEncode(notification_.Url),
                ((sbyte) (notification_.Priority)));

            if (!String.IsNullOrEmpty(_clientCfg.ProviderKey))
                nmaUrlSb.AppendFormat(
                    POST_NOTIFICATION_PROVIDER_PARAMETER,
                    HttpUtility.UrlEncode(_clientCfg.ProviderKey));

            return nmaUrlSb.ToString();
        }
    }
}
