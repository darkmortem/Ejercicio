using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGlabant.Clases
{
    class Ciudad
    {
        private String ciudadA;
        private String ciudadB;
        private int tiempo;
        private String tipoVia;
        

        public int TiempoGetSet
        {
            get { return tiempo; }
            set { tiempo = value; }
        }

        public String CiudadAGetSet
        {
            get { return ciudadA; }
            set { ciudadA = value; }
        }

        public String CiudadBGetSet
        {
            get { return ciudadB; }
            set { ciudadB = value; }
        }

        public String TipoVia
        {
            get { return tipoVia; }
            set { tipoVia = value; }
        }

    }
}
