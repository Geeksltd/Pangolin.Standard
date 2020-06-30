using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Geeks.Pangolin.Service.Helper.XmlHelper
{
    public class XmlSerializer<T> where T : class, new()
    {
        #region [Property]

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public static T Deserialize(string xml) => Deserialize(xml, Encoding.UTF8, null);

        public static T Deserialize(string xml, Encoding encoding) => Deserialize(xml, encoding, null);

        public static T Deserialize(string xml, XmlReaderSettings settings) => Deserialize(xml, Encoding.UTF8, settings);

        public static T Deserialize(string xml, Encoding encoding, XmlReaderSettings settings)
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentException("XML cannot be null or empty", "xml");

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                using (var xmlReader = XmlReader.Create(memoryStream, settings))
                {
                    return (T)xmlSerializer.Deserialize(xmlReader);
                }
            }
        }

        public static T DeserializeFromFile(string filename) => DeserializeFromFile(filename, new XmlReaderSettings());

        public static T DeserializeFromFile(string filename, XmlReaderSettings settings)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename", "XML filename cannot be null or empty");

            if (!File.Exists(filename))
                throw new FileNotFoundException("Cannot find XML file to deserialize", filename);

            using (var reader = XmlReader.Create(filename, settings))
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static string Serialize(T source) => Serialize(source, null, GetIndentedSettings());

        public static string Serialize(T source, XmlSerializerNamespaces namespaces) => Serialize(source, namespaces, GetIndentedSettings());

        public static string Serialize(T source, XmlWriterSettings settings) => Serialize(source, null, settings);

        public static string Serialize(T source, XmlSerializerNamespaces namespaces, XmlWriterSettings settings)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Object to serialize cannot be null");

            string xml = null;
            var serializer = new System.Xml.Serialization.XmlSerializer(source.GetType());

            using (var memoryStream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
                {
                    var x = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    x.Serialize(xmlWriter, source, namespaces);

                    memoryStream.Position = 0; // rewind the stream before reading back.
                    using (var sr = new StreamReader(memoryStream))
                    {
                        xml = sr.ReadToEnd();
                    }
                }
            }

            return xml;
        }

        public static void SerializeToFile(T source, string filename) => SerializeToFile(source, filename, null, GetIndentedSettings());

        public static void SerializeToFile(T source, string filename, XmlSerializerNamespaces namespaces) => SerializeToFile(source, filename, namespaces, GetIndentedSettings());

        public static void SerializeToFile(T source, string filename, XmlWriterSettings settings) => SerializeToFile(source, filename, null, settings);

        public static void SerializeToFile(T source, string filename, XmlSerializerNamespaces namespaces, XmlWriterSettings settings)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Object to serialize cannot be null");

            var serializer = new XmlSerializer(source.GetType());

            using (var xmlWriter = XmlWriter.Create(filename, settings))
            {
                (new System.Xml.Serialization.XmlSerializer(typeof(T))).Serialize(xmlWriter, source, namespaces);
            }
        }

        #endregion

        #region [Private Method]

        private static XmlWriterSettings GetIndentedSettings()
        {
            var xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;
            return xmlWriterSettings;
        }

        #endregion
    }
}
