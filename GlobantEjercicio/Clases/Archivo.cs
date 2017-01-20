using GlobantEjercicio.Clases;
using GlobantEjercicio.Clases.MediosDeTransporte;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioGlabant.Clases
{
    /// <summary>  
    ///  La clase Archivo se encarga de el procesamiento de los archivos de texto, 
    ///  y almacenado de la informacion en diferentes colecciones para luego ser
    ///  procesada.
    /// </summary>  
    public class Archivo
    {
       Dictionary<string, Ruta> diccionarioCiudad =
             new Dictionary<string, Ruta>();

        List<Viaje> listaViajes = new List<Viaje>();

        private List<Ciudad> listaCiudad = new List<Ciudad>();
        private List<MedioDeTransporte> listaMedioDeTransporte = new List<MedioDeTransporte>();

        string rutas;
        string ciudades;
        Regex rgx = new Regex("[^a-zA-Z0-9,]"); //validar lineas del archivo texto.
        ///Constructor de la clase
        public Archivo()
        {
            listaMedioDeTransporte.Add(new Combi("COMBI"));
            listaMedioDeTransporte.Add(new Taxi("TAXI"));
            listaMedioDeTransporte.Add(new Micro("MICRO"));
        }

        public List<MedioDeTransporte> ListaMedioDeTransporteGetSet
        {
            get { return listaMedioDeTransporte; }
            set { listaMedioDeTransporte = value; }
        }


        public List<Ciudad> ListaCiudadGetSet
        {
            get { return listaCiudad; }
            set { listaCiudad = value; }
        }    

        /// <summary>  
        ///  El metodo readfile recibe las direcciones de los archivos.
        ///  Y procesa los archivos de texto.
        /// </summary>  
        public void readfile(string rutaFileCiudades, string rutaFileViajes)
        {
          int numeroDeHilos = 2; // Numero de hilos para procesar el archivo.

          //Inicia el proceso de lectura del archivo ciudades.
          try
          {
             foreach (string linea in File.ReadLines(rutaFileCiudades).AsParallel().WithDegreeOfParallelism(numeroDeHilos))
             {
                   
                 string lineaSinEspacios = rgx.Replace(linea, "");
                    
                 // Split de la linea cuando consiga coma ",".
                 string[] valores = lineaSinEspacios.ToUpper().Split(',');

                // Se comienza a procesar a partir de char array, la linea leida del archivo.

                ciudades = ciudades +valores[0]+valores[1];

                // Se almacena es un objeto Ruta cada linea.
                Ruta ruta = new Ruta(); 
                ruta.CiudadAGetSet = valores[0];
                ruta.CiudadBGetSet = valores[1];

                try
                {
                    ruta.TiempoGetSet = Int32.Parse(valores[2]);
                }
                catch (FormatException e)
                {
                    MessageBox.Show(e.Message);
                }

                ruta.TipoViaGetSet = valores[3];

                //Finalizado se almacena el objeto ruta en un diccionario. La clave sera la ruta ejemplo "AB"
                diccionarioCiudad.Add(ruta.CiudadAGetSet+ruta.CiudadBGetSet, ruta);
         
            }
         }
         catch (IOException e)
         {
            throw e;
         }
            // selecciono de las ciudades solo una ocurrencia de cada una.
            string newCiudades = new string(ciudades.ToCharArray().Distinct().ToArray());

            //Genero una lista de las ciudades
            for (int i = 0; i < newCiudades.Length; i++)
            {
                Ciudad ciudad = new Ciudad();
                ciudad.NombreGetSet = newCiudades[i].ToString() ;
                ciudad.NumeroTuristasGetSet = 0;
                
                listaCiudad.Add(ciudad);

            }

            // Inicia el proceso de lectura del archivo de texto de viajes.
           try
           { 
            foreach (string linea in File.ReadLines(rutaFileViajes).AsParallel().WithDegreeOfParallelism(numeroDeHilos))
            {
                // Se reemplaza los caracteres especiales y espacios en blanco de la linea.
                string lineaSinEspacios = rgx.Replace(linea, "");

                // Split de la linea cuando consiga coma ",".
                string[] valores = lineaSinEspacios.ToUpper().Split(',');

                // Se comienza a procesar la linea y convertirla en un objeto viaje.
                Viaje viaje = new Viaje();
                viaje.TipoVehiculoGetSet = valores[0];
              
                try
                {
                    viaje.CantidadPasajerosGetSet = Int32.Parse(valores[1]);
                }
                catch (FormatException e)
                {
                    MessageBox.Show(e.Message);
                }

                // Se separa las rutas en duplas, A,B,C,D -> AB, BC, CD
                for(int i = 2; i < valores.Length-1; i++)
                {
                    int indice = i + 1;
                    rutas = rutas + valores[i] + valores[i+1];

                    if (indice < valores.Length - 1)
                        rutas = rutas + ",";

                }

                viaje.CiudadesGetSet = rutas;
                rutas = "";

                // Se carga una lista con todos los viajes.
                listaViajes.Add(viaje);    
            }

          }
          catch (IOException e)
          {
            throw e;
          }

            // Se comienza el procesamiento de la informacion
            Resultado resultado = new Resultado();
            int half = listaViajes.Count() / 2; // half busca la mitad de la lista de viajes.
          
            //Se divide el procesamiento de la informacion en dos tareas.
            try
            {
                Parallel.Invoke(() =>
                                {
                                    resultado.ImprimirResultado(diccionarioCiudad, listaViajes.GetRange(0, half+1), listaCiudad, listaMedioDeTransporte);
                                },  // se cierra la primera acción.

                                () =>
                                {
                                int contador = listaViajes.Count- 1 - half;
                                    resultado.ImprimirResultado(diccionarioCiudad, listaViajes.GetRange(half+1, contador), listaCiudad, listaMedioDeTransporte);
                                } //se cierra la segunda acción.
                             
                ); //se cierra el parallel.invoke
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
        

    }
}
