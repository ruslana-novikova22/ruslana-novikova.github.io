using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шаблони_Лаб1
{
    abstract class EventReader
    {
        public abstract List<Meeting> ReadFromFile(string FileName);

        public static EventReader Create(string Filename)
        {
            var parts = Filename.Split('.');
            if (parts.Length > 1 && parts[parts.Length - 1] == "xml")
                return new EventXMLReader(); 
            return null;
        }
    }
}
