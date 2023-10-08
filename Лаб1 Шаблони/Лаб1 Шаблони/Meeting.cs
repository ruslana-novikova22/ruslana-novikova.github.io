using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_Шаблони
{
    class Meeting
    {
        public DateOnly date;
        public string description;
        public string url;
        public List<Users> users;

        public override string ToString()
        {
            return $"{date}: {description}: {url}: {users.ToString}";
        }
    }
}
