using GlobantEjercicio.Clases;
using GlobantEjercicio.Clases.MediosDeTransporte;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioGlabant.Clases
{
    public class Archivo
    {
       Dictionary<string, Ruta> diccionarioCiudad =
             new Dictionary<string, Ruta>();

        List<Viaje> listaViajes = new List<Viaje>();

        private List<Ciudad> listaCiudad = new List<Ciudad>();

        private List<MedioDeTransporte> listaMedioDeTransporte = new List<MedioDeTransporte>();
         

       
        public Archivo()
        {
            listaMedioDeTransporte.Add(new Combi("combi"));
            listaMedioDeTransporte.Add(new Taxi("taxi"));
            listaMedioDeTransporte.Add(new Micro("micro"));
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


        string rutas;
        string ciudades;

        public void readfile(string rutaFileCiudades, string rutaFileViajes)
        {
          int numeroDeHilos = 2;

          try
          {
             foreach (string linea in File.ReadLines(rutaFileCiudades).AsParallel().WithDegreeOfParallelism(numeroDeHilos))
             {
               
                // Split de la linea cuando consiga coma ",".
              
                string[] valores = linea.Split(',');

                ciudades = ciudades +valores[0]+valores[1];
                
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
                diccionarioCiudad.Add(ruta.CiudadAGetSet+ruta.CiudadBGetSet, ruta);
         
            }
         }
         catch (IOException e)
         {
            throw e;
         }

            string newCiudades = new string(ciudades.ToCharArray().Distinct().ToArray());

            for (int i = 0; i < newCiudades.Length; i++)
            {
                Ciudad ciudad = new Ciudad();
                ciudad.NombreGetSet = newCiudades[i].ToString() ;
                ciudad.NumeroTuristasGetSet = 0;
                
                listaCiudad.Add(ciudad);

            }
           try
           { 
            foreach (string linea in File.ReadLines(rutaFileViajes).AsParallel().WithDegreeOfParallelism(numeroDeHilos))
            {
                
                string[] valores = linea.Split(',');

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

                for(int i = 2; i < valores.Length-1; i++)
                {
                    int indice = i + 1;
                    rutas = rutas + valores[i] + valores[i+1];

                    if (indice < valores.Length - 1)
                        rutas = rutas + ",";

                }

                viaje.CiudadesGetSet = rutas;
                rutas = "";

                listaViajes.Add(viaje);    
            }

          }
          catch (IOException e)
          {
            throw e;
          }


            Resultado resultado = new Resultado();
            int half = listaViajes.Count() / 2;
            var exceptions = new ConcurrentQueue<Exception>();

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
