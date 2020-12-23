using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace SendCalendarInviteEmail
{
    public static class XSLTransformer
    {
        public static string Transform(MemoryStream xmlStream, MemoryStream xsltTemplateStream)
        {
            try
            {
                xmlStream.Seek(0, SeekOrigin.Begin);
                //load the Xml doc
                XPathDocument myXPathDoc = new XPathDocument(xmlStream);
                XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Ignore;
                settings.ValidationType = ValidationType.None;
                settings.CheckCharacters = false;
                settings.IgnoreComments = true;

                //load the Xsl 
                xslCompiledTransform.Load(XmlReader.Create(xsltTemplateStream, settings));

                MemoryStream strm = new MemoryStream();
                //create the output stream
                StreamWriter streamWriter = new StreamWriter(strm);

                //do the actual transform of Xml
                xslCompiledTransform.Transform(myXPathDoc, null, streamWriter);
                strm.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(strm);
                string result = reader.ReadToEnd();
                strm.Close();

                if (string.IsNullOrEmpty(result))
                {
					//log
                }

                return result;
            }
            catch (Exception ex)
            {
				//log
                return "";
            }
        }
    }
}