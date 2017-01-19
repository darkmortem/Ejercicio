using GlobantEjercicio.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioGlabant.Clases
{
    public class Archivo
    {
       Dictionary<string, Ruta> diccionarioCiudad =
             new Dictionary<string, Ruta>();

        List<Viaje> listaViajes = new List<Viaje>();

        string rutas;

        public void readfile(string rutaFileCiudades, string rutaFileViajes)
        {
           // Parallel.ForEach(File.ReadLines("file.txt"), (line, _, lineNumber) =>
           // {
                // your code here
           // });

            int numeroDeHilos = 2;

            foreach (string linea in File.ReadLines(rutaFileCiudades).AsParallel().WithDegreeOfParallelism(numeroDeHilos))
            {
                MessageBox.Show("\t" + linea);
                
                // Split de la linea cuando consiga coma ",".
              
                string[] valores = linea.Split(',');
                MessageBox.Show("\t" + valores[0]);


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

      

            foreach (string linea in File.ReadLines(rutaFileViajes).AsParallel().WithDegreeOfParallelism(numeroDeHilos))
            {
                MessageBox.Show("\t" + linea);

                string[] valores = linea.Split(',');

                MessageBox.Show("\t" + valores.Length);

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

                MessageBox.Show("rutas: " + viaje.CiudadesGetSet);
                rutas = "";

                listaViajes.Add(viaje);
             
                Resultado resultado = new Resultado();
                resultado.ImprimirResultado(100,diccionarioCiudad,listaViajes);

            }

        }
        

    }
}
