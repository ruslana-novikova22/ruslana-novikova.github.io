using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_Шаблони
{
    abstract class MeetingReader
    {
        public abstract List<Meeting> ReadFromFile(string FileName);

        public static MeetingReader Create(string fileName)
        {
            var parts = fileName.Split(".");
            if (parts[1] == "xml")
                return new MeetingXmlReader();
            return null;
        }
    }
}
