﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2.Modules
{
    interface IRepository<T>
    {
        List<T> GetAll();
    }
}
