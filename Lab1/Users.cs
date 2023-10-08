using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шаблони_Лаб1
{
    class Users : Meeting
    {
        public int id;
        public string name;
        public string avatar;

        public override string ToString()
        {
            return base.ToString() + $" id: {id} name: {name} avatar: {avatar}";
        }
    }
}
