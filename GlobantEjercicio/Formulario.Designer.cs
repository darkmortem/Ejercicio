namespace EjercicioGlabant
{
    partial class Formulario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEjecutar = new System.Windows.Forms.Button();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelViajes = new System.Windows.Forms.Label();
            this.textBoxCiudad = new System.Windows.Forms.TextBox();
            this.textBoxViajes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonEjecutar
            // 
            this.buttonEjecutar.Location = new System.Drawing.Point(389, 135);
            this.buttonEjecutar.Name = "buttonEjecutar";
            this.buttonEjecutar.Size = new System.Drawing.Size(87, 30);
            this.buttonEjecutar.TabIndex = 0;
            this.buttonEjecutar.Text = "Ejecutar";
            this.buttonEjecutar.UseVisualStyleBackColor = true;
            this.buttonEjecutar.Click += new System.EventHandler(this.buttonEjecutar_Click);
            // 
            // labelCiudad
            // 
            this.labelCiudad.AutoSize = true;
            this.labelCiudad.Location = new System.Drawing.Point(60, 34);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(116, 13);
            this.labelCiudad.TabIndex = 1;
            this.labelCiudad.Text = "Ruta Archivo Ciudades";
            this.labelCiudad.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelViajes
            // 
            this.labelViajes.AutoSize = true;
            this.labelViajes.Location = new System.Drawing.Point(62, 83);
            this.labelViajes.Name = "labelViajes";
            this.labelViajes.Size = new System.Drawing.Size(114, 13);
            this.labelViajes.TabIndex = 2;
            this.labelViajes.Text = "Ruta Archivo de viajes";
            // 
            // textBoxCiudad
            // 
            this.textBoxCiudad.Location = new System.Drawing.Point(213, 31);
            this.textBoxCiudad.Name = "textBoxCiudad";
            this.textBoxCiudad.Size = new System.Drawing.Size(263, 20);
            this.textBoxCiudad.TabIndex = 3;
            // 
            // textBoxViajes
            // 
            this.textBoxViajes.Location = new System.Drawing.Point(213, 80);
            this.textBoxViajes.Name = "textBoxViajes";
            this.textBoxViajes.Size = new System.Drawing.Size(263, 20);
            this.textBoxViajes.TabIndex = 4;
            this.textBoxViajes.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 289);
            this.Controls.Add(this.textBoxViajes);
            this.Controls.Add(this.textBoxCiudad);
            this.Controls.Add(this.labelViajes);
            this.Controls.Add(this.labelCiudad);
            this.Controls.Add(this.buttonEjecutar);
            this.Name = "Formulario";
            this.Text = "Formulario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEjecutar;
        private System.Windows.Forms.Label labelCiudad;
        private System.Windows.Forms.Label labelViajes;
        private System.Windows.Forms.TextBox textBoxCiudad;
        private System.Windows.Forms.TextBox textBoxViajes;
    }
}

