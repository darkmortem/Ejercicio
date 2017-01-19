using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGlabant.Clases
{
    class Viajes
    {
        private string tipoVehiculo;
        private int cantidadPasajeros;
        private string ciudades;


        Viajes() {

            tipoVehiculo = "";
            cantidadPasajeros = 0;
            ciudades = "";
        }

        public string TipoVehiculo
        {
            get { return tipoVehiculo; }
            set { tipoVehiculo = value; }
        }

        public int CantidadPasajeros
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }

        public string Ciudades
        {
            get { return ciudades; }
            set { ciudades = value; }
        }

    }
}
