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
                //Se recorre la lista de viajes
                foreach (var item in listaViaje)
                { 
                    //Se valida la ruta para y luego es procesada.
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
            List<Ciudad> listaTemporalCiudad = new List<Ciudad>(); //lista temporal de ciudad. 
            List<MediosDeTransporte.MedioDeTransporte> listaTemporalMT = new List<MediosDeTransporte.MedioDeTransporte>(); //lista temporal de medio de transporte.

            listaTemporalCiudad = listaCiudad;
            listaTemporalMT = listaMedioDeTransporte; 

            lock (SyncRoot)
            {
                //Extraigo las diferences ciudades del viaje en Char Array. Ejemplo (AB, BC)
                string[] valores = viaje.CiudadesGetSet.Split(',');      

                // Hago ciclo segun la cantidad de viajes.
                for(int i = 0; i < valores.Length ; i++ )
                {
                    char[] charArray = valores[i].ToString().ToCharArray();
                    Array.Reverse(charArray); //Invierto el viaje AB -> BA ya que las rutas son ida y vuelta.
                    string invertido = new string(charArray); 

                    //Chequeo si existe esa ruta en el diccionarioCiudad el Key es por ejemplo las rutas posibles.
                    if ((diccionarioCiudad.TryGetValue(valores[i], out ruta)) || (diccionarioCiudad.TryGetValue(invertido, out ruta)))
                    {
                        // Si la ruta cumple con lo permitido por la unidad.
                        switch (viaje.TipoVehiculoGetSet)
                        {
                            case "COMBI":
                                if (ruta.TipoViaGetSet == "CALLE")
                                {
                                    return false;
                                }
                                break;
                            case "MICRO":
                                if (ruta.TipoViaGetSet == "AUTOPISTA" || ruta.TipoViaGetSet == "CALLE")
                                {
                                    return false;
                                }
                                break;
                        }

                        string ciudadLlegada = valores[i];
                        char last = ciudadLlegada[ciudadLlegada.Length - 1];
                        int index = listaTemporalCiudad.FindIndex(x => x.NombreGetSet == last.ToString());

                        //Se almacena los valores de cantidad de turistas por ciudad.
                        listaTemporalCiudad[index].NumeroTuristasGetSet = listaTemporalCiudad[index].NumeroTuristasGetSet + viaje.CantidadPasajerosGetSet;

                        //Se almacena los valores de tiempo del recorrido 
                        int indexMT = listaTemporalMT.FindIndex(x => x.TipoUnidadGetSet == viaje.TipoVehiculoGetSet);

                        listaTemporalMT[indexMT].MinutosEnViaje(ruta.TiempoGetSet);

                         
                    }
                    else
                    {
                        return (false);
                    }

                }

                //Si el viaje cumple con los requerimientos se guardan los datos en las listas.
                archivo.ListaCiudadGetSet = listaTemporalCiudad;
                archivo.ListaMedioDeTransporteGetSet = listaTemporalMT;
                return (true);
            }

        }

    }
}
