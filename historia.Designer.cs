namespace Formularios
{
    partial class historia
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(historia));
            this.dataSet21BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Formularios.DataSet1();
            this.dataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet3 = new Formularios.DataSet3();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pacientesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bottom1 = new System.Windows.Forms.Button();
            this.txtcedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtnombresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.class1pruebillaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet4 = new Formularios.DataSet4();
            this.dataSet4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacientesDataSetBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtnombresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.class1pruebillaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1BindingSource1
            // 
            this.dataSet1BindingSource1.DataSource = this.dataSet1;
            this.dataSet1BindingSource1.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet3BindingSource
            // 
            this.dataSet3BindingSource.DataSource = this.dataSet3;
            this.dataSet3BindingSource.Position = 0;
            // 
            // dataSet3
            // 
            this.dataSet3.DataSetName = "DataSet3";
            this.dataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.dataSet21BindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.dataSet1BindingSource1;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.dataSet3BindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.dataSet4BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Formularios.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(122, 111);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(843, 563);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // bottom1
            // 
            this.bottom1.FlatAppearance.BorderSize = 0;
            this.bottom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottom1.Image = ((System.Drawing.Image)(resources.GetObject("bottom1.Image")));
            this.bottom1.Location = new System.Drawing.Point(630, 54);
            this.bottom1.Name = "bottom1";
            this.bottom1.Size = new System.Drawing.Size(111, 33);
            this.bottom1.TabIndex = 1;
            this.bottom1.UseVisualStyleBackColor = true;
            this.bottom1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcedula
            // 
            this.txtcedula.Location = new System.Drawing.Point(401, 54);
            this.txtcedula.Multiline = true;
            this.txtcedula.Name = "txtcedula";
            this.txtcedula.Size = new System.Drawing.Size(213, 33);
            this.txtcedula.TabIndex = 2;
            this.txtcedula.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtcedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcedula_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(268, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingresar cédula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(394, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Historia Clinica";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.txtcedula);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bottom1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 90);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtnombresBindingSource
            // 
            this.dtnombresBindingSource.DataMember = "dtnombres";
            this.dtnombresBindingSource.DataSource = this.dataSet1;
            // 
            // class1pruebillaBindingSource
            // 
            this.class1pruebillaBindingSource.DataSource = typeof(Formularios.Class1pruebilla);
            // 
            // dataSet4
            // 
            this.dataSet4.DataSetName = "DataSet4";
            this.dataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet4BindingSource
            // 
            this.dataSet4BindingSource.DataSource = this.dataSet4;
            this.dataSet4BindingSource.Position = 0;
            // 
            // historia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 686);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "historia";
            this.Text = "historia";
            this.Load += new System.EventHandler(this.historia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacientesDataSetBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtnombresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.class1pruebillaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource pacientesDataSetBindingSource;
       
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource class1pruebillaBindingSource;
        private System.Windows.Forms.Button bottom1;
        private System.Windows.Forms.TextBox txtcedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource dataSet21BindingSource;
    
        private System.Windows.Forms.BindingSource dataSet1BindingSource1;
        private System.Windows.Forms.BindingSource dtnombresBindingSource;
        private System.Windows.Forms.BindingSource dataSet3BindingSource;
        private DataSet3 dataSet3;
        private System.Windows.Forms.BindingSource dataSet4BindingSource;
        private DataSet4 dataSet4;
    }
}