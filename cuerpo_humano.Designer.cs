namespace Formularios
{
    partial class cuerpo_humano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cuerpo_humano));
            this.cuerpo = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btncargar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picvalor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picvalor)).BeginInit();
            this.SuspendLayout();
            // 
            // cuerpo
            // 
            this.cuerpo.Image = ((System.Drawing.Image)(resources.GetObject("cuerpo.Image")));
            this.cuerpo.InitialImage = ((System.Drawing.Image)(resources.GetObject("cuerpo.InitialImage")));
            this.cuerpo.Location = new System.Drawing.Point(12, 12);
            this.cuerpo.Name = "cuerpo";
            this.cuerpo.Size = new System.Drawing.Size(815, 545);
            this.cuerpo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cuerpo.TabIndex = 0;
            this.cuerpo.TabStop = false;
            this.cuerpo.Click += new System.EventHandler(this.pictureBox1_Click);
            this.cuerpo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(839, 522);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "Limpiar";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btncargar
            // 
            this.btncargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btncargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncargar.Location = new System.Drawing.Point(839, 99);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(82, 48);
            this.btncargar.TabIndex = 6;
            this.btncargar.Text = "cargar";
            this.btncargar.UseVisualStyleBackColor = false;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(839, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(476, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // picvalor
            // 
            this.picvalor.Image = ((System.Drawing.Image)(resources.GetObject("picvalor.Image")));
            this.picvalor.Location = new System.Drawing.Point(27, 70);
            this.picvalor.Name = "picvalor";
            this.picvalor.Size = new System.Drawing.Size(815, 545);
            this.picvalor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picvalor.TabIndex = 9;
            this.picvalor.TabStop = false;
            // 
            // cuerpo_humano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 572);
            this.Controls.Add(this.picvalor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btncargar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cuerpo);
            this.Name = "cuerpo_humano";
            this.Text = "cuerpo_humano";
            this.Load += new System.EventHandler(this.cuerpo_humano_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picvalor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox cuerpo;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picvalor;
    }
}