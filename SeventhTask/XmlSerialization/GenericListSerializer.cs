using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SeventhTask.XmlSerialization
{
    public class GenericListSerializer<T>
    {
        private List<T> GenericList { get; set; }
        private Dictionary<string, XmlSerializer> Serializers { get; set; }

        public GenericListSerializer()
        { 
            Serializers = new Dictionary<string, XmlSerializer>();
        }

        public GenericListSerializer(List<T> genericList) : this()
        {
            GenericList = genericList;
            InitializeSerializers();
        }

        /// <summary>
        /// Initialize serializers dictionary with serializers.
        /// </summary>
        private void InitializeSerializers()
        {
            foreach (var element in GenericList)
            {
                if (!Serializers.ContainsKey(element.GetType().Name))
                {
                    Serializers.Add(element.GetType().Name, new XmlSerializer(element.GetType()));
                }
            }
        }

        /// <summary>
        /// Serialize collection.
        /// </summary>
        /// <param name="outputStream">Ouptup stream to write the serializable data.</param>
        public void Serialize(FileStream outputStream)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = "\t";

            XmlWriter xmlWriter = XmlWriter.Create(outputStream, xmlWriterSettings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement($"ArrayOf{typeof(T).Name}");
            foreach (var element in GenericList)
            {
                Type elementType = element.GetType();
                XmlSerializer elementSerializer = GetXmlSerializerByType(elementType);
                elementSerializer.Serialize(xmlWriter, element);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.WriteEndDocument();
        }

        /// <summary>
        /// Serialize collection.
        /// </summary>
        /// <param name="outputStream">Ouptup stream to write the serializable data.</param>
        /// <param name="serializableList">List to serialize.</param>
        public void Serialize(FileStream outputStream, List<T> serializableList)
        {
            GenericList = serializableList;
            Serialize(outputStream);
        }

        /// <summary>
        /// Return XmlSerializer by type.
        /// </summary>
        /// <param name="type">Type of object to serialize.</param>
        /// <returns></returns>
        private XmlSerializer GetXmlSerializerByType(Type type)
        {
            if(!Serializers.ContainsKey(type.Name))
            {
                Serializers.Add(type.Name, new XmlSerializer(type));
            }

            return Serializers[type.Name];
        }
    }
}
