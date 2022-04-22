using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garcia_Bernardo_Lambda
{
    class Paquete
    {
        public int CodPaquete { get; set; }
        public string NomPaquete { get; set; }

        public Paquete(int codPaquete, string nomPaquete)
        {
            CodPaquete = codPaquete;
            NomPaquete = nomPaquete;
        }
    }
}
