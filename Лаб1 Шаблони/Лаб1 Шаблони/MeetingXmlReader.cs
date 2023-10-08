using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Лаб1_Шаблони
{
    class MeetingXmlReader : MeetingReader
    {
        public override List<Meeting> ReadFromFile(string FileName)
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
        public static MeetingXmlReader Create(string type)
        {
            if (type == "event")
                return new MeetingXmlReader();
            if (type == "birthday-event")
                return new UsersXmlReader();
            return null;
        }
    }
    class MeetingXmlReader
    {
        public virtual Meeting Read(XmlTextReader reader)
        {
            return new Meeting()
            {
                date = DateOnly.Parse(reader.GetAttribute("date")),
                description = reader.GetAttribute("description"),
                url = reader.GetAttribute("url"),
                users = reader.GetAttributeList("users")
            };
        }
    }
    class UsersXmlReader : MeetingXmlReader
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
