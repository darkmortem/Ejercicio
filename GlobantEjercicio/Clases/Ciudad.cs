using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGlabant.Clases
{
    class Ciudad
    {
        private string ciudadA;
        private string ciudadB;
        private int tiempo;
        private string tipoVia;

        Ciudad() {

            ciudadA = "";
            ciudadB = "";
            tiempo = 0;
            tipoVia = "";
        }


        public int TiempoGetSet
        {
            get { return tiempo; }
            set { tiempo = value; }
        }

        public string CiudadAGetSet
        {
            get { return ciudadA; }
            set { ciudadA = value; }
        }

        public string CiudadBGetSet
        {
            get { return ciudadB; }
            set { ciudadB = value; }
        }

        public string TipoVia
        {
            get { return tipoVia; }
            set { tipoVia = value; }
        }

    }
}
