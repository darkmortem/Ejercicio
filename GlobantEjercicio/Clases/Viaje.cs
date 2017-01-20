using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGlabant.Clases
{
    /// <summary>  
    ///  La clase Viaje contiene toda las caracteristica de un viajes,
    ///  cuenta con los atributos basicos de un viaje extraido del archivo de texto.
    /// </summary>  
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
