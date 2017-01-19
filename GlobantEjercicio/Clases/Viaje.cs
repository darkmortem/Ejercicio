using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGlabant.Clases
{
    class Viaje
    {
        private string tipoVehiculo;
        private int cantidadPasajeros;
        private string ciudades;


        public Viaje() {

            tipoVehiculo = "";
            cantidadPasajeros = 0;
            ciudades = "";
        }

        public string TipoVehiculoGetSet
        {
            get { return tipoVehiculo; }
            set { tipoVehiculo = value; }
        }

        public int CantidadPasajerosGetSet
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }

        public string CiudadesGetSet
        {
            get { return ciudades; }
            set { ciudades = value; }
        }

    }
}
