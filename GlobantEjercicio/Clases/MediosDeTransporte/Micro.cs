using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantEjercicio.Clases.MediosDeTransporte
{
    /// <summary>  
    ///  La clase Micro describe un tipo de transporte y hereda de la clase medio de transporte.
    /// </summary> 
    class Micro : MedioDeTransporte
    {
        public Micro(string nombre)
        {
            this.TipoUnidadGetSet = nombre;
            this.MinutosTotal = 0;
        }
        public override void MinutosEnViaje(int minutos)
        {
            this.MinutosTotal += minutos;
        }

    }
}
