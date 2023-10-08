using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Шаблони_Лаб1
{
    class EventXMLReader : EventReader
    {
        public override List<Meeting> ReadFromFile(string FileNme)
        {
            var events = new List<Meeting>();
            using (XmlTextReader reader = new XmlTextReader(FileName))
            {
                StringBuilder str = new StringBuilder();
                reader.ReadStartElement("events");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        var eventReader = EventXmlReaderFabric.Create(reader.Name);
                        events.Add(eventReader.Read(reader));
                    }
                }
            }
            return events;
        }
    }

    class EventXmlReaderFabric
    {
        public static EventXmlReader Create(string type)
        {
            if (type == "event")
                return new EventXmlReader();
            if (type == "users")
                return new UsersXmlReader();
            return null;
        }
    }

    class EventXmlReader
    {
        public virtual Meeting Read(XmlTextReader reader)
        {
            return new Meeting()
            {
                date = DateOnly.Parse(reader.GetAttribute("date")),
                description = reader.GetAttribute("description"),
                url = reader.GetAttribute("url"),
            };
        }
    }

    class UsersXmlReader : EventXmlReader
    {
        public override Meeting Read(XmlTextReader reader)
        {
            return new Users()
            {
                date = DateOnly.Parse(reader.GetAttribute("date")),
                description = reader.GetAttribute("description"),
                url = reader.GetAttribute("url"),
                id = Int32.Parse(reader.GetAttribute("id")),
                name = reader.GetAttribute("name"),
                avatar = reader.GetAttribute("avatar")
            };
        }
    }
}
