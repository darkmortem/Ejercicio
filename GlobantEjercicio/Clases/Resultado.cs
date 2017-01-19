using EjercicioGlabant.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

      private List<Tuple<string, int>> turistasPorCiudad = new List<Tuple<string, int>>();

      
      //  rutaes.Add(9);

        public Resultado()
        {
            minutosViajeCombi = 0;
            minutosViajeMicro = 0;
            minutosViajeTaxi = 0;

            turistasPorCiudad.Add(Tuple.Create("A", 29));
            turistasPorCiudad.Add(Tuple.Create("B", 31));

        }

        public void ImprimirResultado(int index, Dictionary<string,Ruta> diccionarioCiudad ,List<Viaje> listaViaje) {


            lock (SyncRoot)
            {
                for (int i = index; i < listaViaje.Count - 1; i++)
                {
                 
                    ValidarRuta(listaViaje[i],diccionarioCiudad);

                }
               
            }

            MessageBox.Show("\t" + turistasPorCiudad[0].Item1 + " // " + turistasPorCiudad[1].Item2);

        }

        public bool ValidarRuta(Viaje viaje, Dictionary<string, Ruta> diccionarioCiudad)
        {
            Ruta ruta; 

            lock (SyncRoot)
            {
                string[] valores = viaje.CiudadesGetSet.Split(',');      

                for(int i = 0; i < valores.Length-1 ; i++ )
                {
                      char[] charArray = valores[0].ToString().ToCharArray();
                      Array.Reverse(charArray);
                      string invertido = charArray.ToString();

                    if ((diccionarioCiudad.TryGetValue(valores[0], out ruta)) || (diccionarioCiudad.TryGetValue(valores[0], out ruta)))
                    {
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

        public List<Tuple<string, int>> TuristasCiudad
        {
            get { return turistasPorCiudad; }
            set { turistasPorCiudad = value; }
        }

    }
}
