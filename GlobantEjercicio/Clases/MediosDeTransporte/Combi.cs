using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantEjercicio.Clases.MediosDeTransporte
{
    class Combi : MedioDeTransporte
    {
        public Combi(string nombre)
        {
            this.TipoUnidadGetSet = nombre;
            this.MinutosTotal = 0;
        }
        public override void MinutosEnViaje( int minutos)
        {
            this.MinutosTotal += minutos;
        }

    }
}
