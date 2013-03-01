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
            notification_.Validate();

            var updateRequest = HttpWebRequest.Create(BuildNotificationRequestUrl(notification_)) as HttpWebRequest;

            updateRequest.ContentLength = 0;
            updateRequest.ContentType = REQUEST_CONTENT_TYPE;
            updateRequest.Method = REQUEST_METHOD_TYPE;

            HttpWebResponse response = (HttpWebResponse) updateRequest.GetResponse();
            string statusCode = string.Empty;
            try
            {
                response = (HttpWebResponse) updateRequest.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String attribs = "";
                StringBuilder output = new StringBuilder();


                using (XmlReader xmlreader = XmlReader.Create(reader))
                {
                    XmlWriterSettings ws = new XmlWriterSettings();
                    ws.Indent = true;
                    using (XmlWriter writer = XmlWriter.Create(output, ws))
                    {
                        // Parse the file and display each of the nodes.
                        while (xmlreader.Read())
                        {
                            switch (xmlreader.NodeType)
                            {
                                case XmlNodeType.Element:
                                  
                                    writer.WriteStartElement(xmlreader.Name);
                                    if (xmlreader.HasAttributes)
                                    {
                                        attribs = "Success code: " + xmlreader[0] + "---Remaining msgs: " + xmlreader[1] +
                                                  "---Resets in: " + xmlreader[2] + " minutes";
                                        xmlreader.MoveToElement();
                                        /*  for (int i = 0; i < xmlreader.AttributeCount; i++)
                                        {
                                            attribs = attribs + xmlreader.Name + xmlreader[i];
                                            inner = reader.ReadInnerXml();
                                        }*/
                                        // Move the reader back to the element node.   
                                    }
                                    break;
                                case XmlNodeType.Text:
                                    writer.WriteString(xmlreader.Value);
                                    break;
                                case XmlNodeType.XmlDeclaration:
                                case XmlNodeType.ProcessingInstruction:
                                    writer.WriteProcessingInstruction(xmlreader.Name, xmlreader.Value);
                                    break;
                                case XmlNodeType.Comment:
                                    writer.WriteComment(xmlreader.Value);
                                    break;
                                case XmlNodeType.EndElement:
                                    writer.WriteFullEndElement();
                                    break;
                            }
                        }
                    }
                    string result = Regex.Replace(output.ToString(), @"<(.|\n)*?>", string.Empty);
                    if (result.Trim() == "" || result.Trim() == null)
                    {
                        reader.Close();
                        dataStream.Close();
                        return attribs;
                    }
                    else
                    {
                        reader.Close();
                        dataStream.Close();
                        return result.Trim();
                    }
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
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
