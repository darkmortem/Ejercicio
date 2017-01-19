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

        public void readfile(string rutaFileCiudades, string rutaFileViajes)
        {
           // Parallel.ForEach(File.ReadLines("file.txt"), (line, _, lineNumber) =>
           // {
                // your code here
           // });

            string filename = "C:\\prueba\\prueba.txt";
            int n = 2;

            foreach (var line in File.ReadLines(rutaFileCiudades).AsParallel().WithDegreeOfParallelism(n))
            {
                MessageBox.Show("\t" + line);
            }

        }
        

    }
}
