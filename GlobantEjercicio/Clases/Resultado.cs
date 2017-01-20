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
    /// <summary>  
    ///  La clase Resultado es donde la información almacenada de las colecciones es
    ///  procesada. 
    /// </summary>  
    class Resultado
    {
     
      public object SyncRoot { get { return this; } }

      
        public Resultado()
        {
           
        }

        /// <summary>  
        ///  Imprimir Resultado se encarga de recibir las colecciones y ejecutar el proceso de validacion
        ///  y extraccion de datos.
        /// </summary>  
        public void ImprimirResultado(Dictionary<string,Ruta> diccionarioCiudad ,List<Viaje> listaViaje,List<Ciudad> listaCiudad, List<MediosDeTransporte.MedioDeTransporte> listaMedioDeTransporte)
        {

                foreach (var item in listaViaje)
                { 
                    ValidarRuta(item, diccionarioCiudad, listaCiudad, listaMedioDeTransporte);
                }
        
        }

        /// <summary>  
        ///  El metodo ValidaRuta chequea que la ruta cuente con las condiciones 
        ///  para poder ser tomada en cuenta para el analisis de los datos.
        /// </summary>  
        public bool ValidarRuta(Viaje viaje, Dictionary<string, Ruta> diccionarioCiudad,List<Ciudad> listaCiudad,List<MediosDeTransporte.MedioDeTransporte> listaMedioDeTransporte)
        {
            Ruta ruta;
            Archivo archivo = new Archivo();
            List<Ciudad> listaTemporalCiudad = new List<Ciudad>();
            List<MediosDeTransporte.MedioDeTransporte> listaTemporalMT = new List<MediosDeTransporte.MedioDeTransporte>();

            listaTemporalCiudad = listaCiudad;
            listaTemporalMT = listaMedioDeTransporte; 

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

                        int indexMT = listaTemporalMT.FindIndex(x => x.TipoUnidadGetSet == viaje.TipoVehiculoGetSet);

                        listaTemporalMT[indexMT].MinutosEnViaje(ruta.TiempoGetSet);


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
                archivo.ListaMedioDeTransporteGetSet = listaTemporalMT;
                return (true);
            }

        }


      
        

    }
}
