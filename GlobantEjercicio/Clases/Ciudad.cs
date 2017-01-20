using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobantEjercicio.Clases
{
    /// <summary>  
    ///  La clase ciudad contiene informacion comun de la ciudad.
    ///  esta entidad es usada para llevar el numero de turistas
    ///  que la visita.
    /// </summary>  
    public class Ciudad
    {
        private string nombreCiudad;
        private int numeroTuristas;

        public Ciudad()
        {
            nombreCiudad = "";
            numeroTuristas = 0;
        }
        

        public string NombreGetSet
        {
            get { return nombreCiudad; }
            set { nombreCiudad = value; }
        }
        public int NumeroTuristasGetSet
        {
            get { return numeroTuristas; }
            set { numeroTuristas = value; }
        }



    }
}
