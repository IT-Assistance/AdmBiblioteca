﻿using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Acciones
{
    public class AccionesBase
    {
        protected DbLibraryEntityDataContext dbLibContext = new DbLibraryEntityDataContext();
    }
}
