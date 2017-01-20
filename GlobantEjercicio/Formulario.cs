using EjercicioGlabant.Clases;
using GlobantEjercicio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioGlabant
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEjecutar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.textBoxCiudad.Text))
            {
                MessageBox.Show("La ruta del archivo Ciudad no es valida",
                  "Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);
            }
            else if (!File.Exists(this.textBoxViajes.Text))
            {
                MessageBox.Show("La ruta del archivo Viajes no es valida",
                  "Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);
            }
            else
            {
                Archivo ar = new Archivo();
                List<Ciudad> listaCiudad = ar.ListaCiudadGetSet;
                List<GlobantEjercicio.Clases.MediosDeTransporte.MedioDeTransporte> listaMedioDeTransporte = ar.ListaMedioDeTransporteGetSet;
                ar.readfile(textBoxCiudad.Text, textBoxViajes.Text);

                richTextBox1.Text = "";
                richTextBox2.Text = "";

                foreach (var item in listaCiudad)
                {
                    richTextBox1.Text = richTextBox1.Text + item.NombreGetSet +" : " + item.NumeroTuristasGetSet + "\r\n";
                }

                foreach (var item in listaMedioDeTransporte)
                {
                    richTextBox2.Text = richTextBox2.Text + item.TipoUnidadGetSet + " : " + item.MinutosTotal +" MIN " + "\r\n";
                }

            }






        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
