﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garcia_Bernardo_Lambda
{
    class Turista_Lugar
    {
        public int CI { get; set; }
        public string IdLugar { get; set; }

        public Turista_Lugar(int cI, string idLugar)
        {
            CI = cI;
            IdLugar = idLugar;
        }
    }
}
