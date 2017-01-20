using EjercicioGlabant.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobantEjercicio.Clases
{
    class Resultado
    {
      private int minutosViajeCombi;
      private int minutosViajeMicro;
      private int minutosViajeTaxi;
      public object SyncRoot { get { return this; } }

      
        public Resultado()
        {
            minutosViajeCombi = 0;
            minutosViajeMicro = 0;
            minutosViajeTaxi = 0;
        }

        public void ImprimirResultado(Dictionary<string,Ruta> diccionarioCiudad ,List<Viaje> listaViaje,List<Ciudad> listaCiudad)
        {

                foreach (var item in listaViaje)
                { 
                    ValidarRuta(item, diccionarioCiudad, listaCiudad);
                }
        
        }

        public bool ValidarRuta(Viaje viaje, Dictionary<string, Ruta> diccionarioCiudad,List<Ciudad> listaCiudad)
        {
            Ruta ruta;
            Archivo archivo = new Archivo();
            List<Ciudad> listaTemporalCiudad = new List<Ciudad>();
            listaTemporalCiudad = listaCiudad;

            lock (SyncRoot)
            {
                string[] valores = viaje.CiudadesGetSet.Split(',');      

                for(int i = 0; i < valores.Length ; i++ )
                {
                      char[] charArray = valores[i].ToString().ToCharArray();
                      Array.Reverse(charArray);
                      string invertido = new string(charArray);

                    if ((diccionarioCiudad.TryGetValue(valores[i], out ruta)) || (diccionarioCiudad.TryGetValue(invertido, out ruta)))
                    {
                        string ciudadLlegada = valores[i];
                        char last = ciudadLlegada[ciudadLlegada.Length - 1];
                        int index = listaTemporalCiudad.FindIndex(x => x.NombreGetSet == last.ToString());

                        listaTemporalCiudad[index].NumeroTuristasGetSet = listaTemporalCiudad[index].NumeroTuristasGetSet + viaje.CantidadPasajerosGetSet;

                        switch (viaje.TipoVehiculoGetSet)
                        {
                            case "combi":
                                if (ruta.TipoViaGetSet == "calle")
                                {
                                    return false;
                                }
                                break;
                            case "micro":
                                if (ruta.TipoViaGetSet == "autopista" || ruta.TipoViaGetSet == "calle")
                                {
                                    return false;
                                }
                                break;

                        }

                        
                    }
                    else
                    {
                        return (false);
                    }

                }

                archivo.ListaCiudadGetSet = listaTemporalCiudad;
                return (true);
            }

        }


      
        public int MinutosViajeCombi
        {
            get { return minutosViajeCombi; }
            set { minutosViajeCombi = value; }
        }

        public int MinutosViajeMicro
        {
            get { return minutosViajeMicro; }
            set { minutosViajeTaxi = value; }
        }

        public int MinutosViajeTaxi
        {
            get { return minutosViajeTaxi; }
            set { minutosViajeTaxi = value; }
        }

    }
}
