using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantEjercicio.Clases.MediosDeTransporte
{
    public abstract class MedioDeTransporte
    {
        private string tipoUnidad;
        private int minutosTotal;

        public MedioDeTransporte()
        {
            tipoUnidad = "";
            minutosTotal = 0;
        }

        public string TipoUnidadGetSet
        {
            get { return tipoUnidad; }
            set { tipoUnidad = value; }
        }

        public int MinutosTotal
        {
            get { return minutosTotal; }
            set { minutosTotal = value; }
        }

        public virtual void MinutosEnViaje(int minutos)
        {

        }
    }
}
