namespace Formularios
{
    partial class imagen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(imagen));
            this.mostrar_imagen = new System.Windows.Forms.PictureBox();
            this.cmbfechas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_imagen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mostrar_imagen
            // 
            this.mostrar_imagen.Location = new System.Drawing.Point(38, 99);
            this.mostrar_imagen.Name = "mostrar_imagen";
            this.mostrar_imagen.Size = new System.Drawing.Size(515, 258);
            this.mostrar_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mostrar_imagen.TabIndex = 0;
            this.mostrar_imagen.TabStop = false;
            this.mostrar_imagen.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmbfechas
            // 
            this.cmbfechas.FormattingEnabled = true;
            this.cmbfechas.Location = new System.Drawing.Point(177, 57);
            this.cmbfechas.Name = "cmbfechas";
            this.cmbfechas.Size = new System.Drawing.Size(160, 21);
            this.cmbfechas.TabIndex = 1;
            this.cmbfechas.SelectedIndexChanged += new System.EventHandler(this.cmbfechas_SelectedIndexChanged);
            this.cmbfechas.SelectedValueChanged += new System.EventHandler(this.cmbfechas_SelectedValueChanged);
            this.cmbfechas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbfechas_MouseClick);
            this.cmbfechas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cmbfechas_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, -58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de Lesiones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(157, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "LESIONES GRAFICAS";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(343, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.cmbfechas);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 93);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // imagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 382);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mostrar_imagen);
            this.Name = "imagen";
            this.Text = "imagen";
            this.Load += new System.EventHandler(this.imagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_imagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mostrar_imagen;
        private System.Windows.Forms.ComboBox cmbfechas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}