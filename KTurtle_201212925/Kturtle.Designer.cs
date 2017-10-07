namespace KTurtle_201212925
{
    partial class Kturtle
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kturtle));
            this.MenuKTURLE = new System.Windows.Forms.MenuStrip();
            this.Archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.Archivo_Abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.Archivo_Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.Archivo_GuardarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.Archivo_Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.Run = new System.Windows.Forms.ToolStripMenuItem();
            this.Reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.Ayuda_AcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.Ayuda_Usuario = new System.Windows.Forms.ToolStripMenuItem();
            this.Ayuda_Tecnico = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Consola = new System.Windows.Forms.RichTextBox();
            this.lbl_Salida = new System.Windows.Forms.Label();
            this.PanelCodigo = new System.Windows.Forms.Panel();
            this.txt_codigo = new System.Windows.Forms.RichTextBox();
            this.lbl_codigo = new System.Windows.Forms.Label();
            this.PanelTortuga = new System.Windows.Forms.Panel();
            this.Tortuga = new System.Windows.Forms.PictureBox();
            this.Lienzo = new System.Windows.Forms.Label();
            this.MenuKTURLE.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelCodigo.SuspendLayout();
            this.PanelTortuga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tortuga)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuKTURLE
            // 
            this.MenuKTURLE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Archivo,
            this.Run,
            this.Reportes,
            this.Ayuda});
            this.MenuKTURLE.Location = new System.Drawing.Point(0, 0);
            this.MenuKTURLE.Name = "MenuKTURLE";
            this.MenuKTURLE.Size = new System.Drawing.Size(864, 24);
            this.MenuKTURLE.TabIndex = 0;
            this.MenuKTURLE.Text = "Menu";
            // 
            // Archivo
            // 
            this.Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Archivo_Abrir,
            this.Archivo_Guardar,
            this.Archivo_GuardarComo,
            this.Archivo_Salir});
            this.Archivo.Name = "Archivo";
            this.Archivo.Size = new System.Drawing.Size(60, 20);
            this.Archivo.Text = "Archivo";
            // 
            // Archivo_Abrir
            // 
            this.Archivo_Abrir.Name = "Archivo_Abrir";
            this.Archivo_Abrir.Size = new System.Drawing.Size(159, 22);
            this.Archivo_Abrir.Text = "Abrir";
            this.Archivo_Abrir.Click += new System.EventHandler(this.Archivo_Abrir_Click);
            // 
            // Archivo_Guardar
            // 
            this.Archivo_Guardar.Name = "Archivo_Guardar";
            this.Archivo_Guardar.Size = new System.Drawing.Size(159, 22);
            this.Archivo_Guardar.Text = "Guardar";
            this.Archivo_Guardar.Click += new System.EventHandler(this.Archivo_Guardar_Click);
            // 
            // Archivo_GuardarComo
            // 
            this.Archivo_GuardarComo.Name = "Archivo_GuardarComo";
            this.Archivo_GuardarComo.Size = new System.Drawing.Size(159, 22);
            this.Archivo_GuardarComo.Text = "Guardar como...";
            this.Archivo_GuardarComo.Click += new System.EventHandler(this.Archivo_GuardarComo_Click);
            // 
            // Archivo_Salir
            // 
            this.Archivo_Salir.Name = "Archivo_Salir";
            this.Archivo_Salir.Size = new System.Drawing.Size(159, 22);
            this.Archivo_Salir.Text = "Salir";
            this.Archivo_Salir.Click += new System.EventHandler(this.Archivo_Salir_Click);
            // 
            // Run
            // 
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(40, 20);
            this.Run.Text = "Run";
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Reportes
            // 
            this.Reportes.Enabled = false;
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(65, 20);
            this.Reportes.Text = "Reportes";
            this.Reportes.Click += new System.EventHandler(this.Reportes_Click);
            // 
            // Ayuda
            // 
            this.Ayuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ayuda_AcercaDe,
            this.Ayuda_Usuario,
            this.Ayuda_Tecnico});
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(53, 20);
            this.Ayuda.Text = "Ayuda";
            // 
            // Ayuda_AcercaDe
            // 
            this.Ayuda_AcercaDe.Name = "Ayuda_AcercaDe";
            this.Ayuda_AcercaDe.Size = new System.Drawing.Size(173, 22);
            this.Ayuda_AcercaDe.Text = "Acerca de...";
            this.Ayuda_AcercaDe.Click += new System.EventHandler(this.Ayuda_AcercaDe_Click);
            // 
            // Ayuda_Usuario
            // 
            this.Ayuda_Usuario.Name = "Ayuda_Usuario";
            this.Ayuda_Usuario.Size = new System.Drawing.Size(173, 22);
            this.Ayuda_Usuario.Text = "Manual de Usuario";
            this.Ayuda_Usuario.Click += new System.EventHandler(this.Ayuda_Usuario_Click);
            // 
            // Ayuda_Tecnico
            // 
            this.Ayuda_Tecnico.Name = "Ayuda_Tecnico";
            this.Ayuda_Tecnico.Size = new System.Drawing.Size(173, 22);
            this.Ayuda_Tecnico.Text = "Manual Técnico";
            this.Ayuda_Tecnico.Click += new System.EventHandler(this.Ayuda_Tecnico_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.PanelCodigo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PanelTortuga, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 454);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Consola);
            this.panel1.Controls.Add(this.lbl_Salida);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(651, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 448);
            this.panel1.TabIndex = 2;
            // 
            // txt_Consola
            // 
            this.txt_Consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Consola.Location = new System.Drawing.Point(0, 13);
            this.txt_Consola.Name = "txt_Consola";
            this.txt_Consola.ReadOnly = true;
            this.txt_Consola.Size = new System.Drawing.Size(210, 435);
            this.txt_Consola.TabIndex = 1;
            this.txt_Consola.Text = "";
            // 
            // lbl_Salida
            // 
            this.lbl_Salida.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Salida.Location = new System.Drawing.Point(0, 0);
            this.lbl_Salida.Name = "lbl_Salida";
            this.lbl_Salida.Size = new System.Drawing.Size(210, 13);
            this.lbl_Salida.TabIndex = 0;
            this.lbl_Salida.Text = "Salida:";
            // 
            // PanelCodigo
            // 
            this.PanelCodigo.Controls.Add(this.txt_codigo);
            this.PanelCodigo.Controls.Add(this.lbl_codigo);
            this.PanelCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCodigo.Location = new System.Drawing.Point(3, 3);
            this.PanelCodigo.Name = "PanelCodigo";
            this.PanelCodigo.Size = new System.Drawing.Size(210, 448);
            this.PanelCodigo.TabIndex = 0;
            // 
            // txt_codigo
            // 
            this.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_codigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigo.Location = new System.Drawing.Point(0, 13);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(210, 435);
            this.txt_codigo.TabIndex = 1;
            this.txt_codigo.Text = "";
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_codigo.Location = new System.Drawing.Point(0, 0);
            this.lbl_codigo.Name = "lbl_codigo";
            this.lbl_codigo.Size = new System.Drawing.Size(210, 13);
            this.lbl_codigo.TabIndex = 0;
            this.lbl_codigo.Text = "Codigo:";
            // 
            // PanelTortuga
            // 
            this.PanelTortuga.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelTortuga.Controls.Add(this.Tortuga);
            this.PanelTortuga.Controls.Add(this.Lienzo);
            this.PanelTortuga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTortuga.Location = new System.Drawing.Point(219, 3);
            this.PanelTortuga.Name = "PanelTortuga";
            this.PanelTortuga.Size = new System.Drawing.Size(426, 448);
            this.PanelTortuga.TabIndex = 1;
            // 
            // Tortuga
            // 
            this.Tortuga.ErrorImage = global::KTurtle_201212925.Properties.Resources.Minitortuga;
            this.Tortuga.Image = global::KTurtle_201212925.Properties.Resources.Minitortuga;
            this.Tortuga.InitialImage = global::KTurtle_201212925.Properties.Resources.Minitortuga;
            this.Tortuga.Location = new System.Drawing.Point(100, 100);
            this.Tortuga.Name = "Tortuga";
            this.Tortuga.Size = new System.Drawing.Size(20, 20);
            this.Tortuga.TabIndex = 3;
            this.Tortuga.TabStop = false;
            // 
            // Lienzo
            // 
            this.Lienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lienzo.Location = new System.Drawing.Point(10, 10);
            this.Lienzo.Name = "Lienzo";
            this.Lienzo.Size = new System.Drawing.Size(200, 200);
            this.Lienzo.TabIndex = 1;
            // 
            // Kturtle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 478);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuKTURLE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuKTURLE;
            this.Name = "Kturtle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KTurtle - Edulibre - Kebyn Felipe 201212925";
            this.MenuKTURLE.ResumeLayout(false);
            this.MenuKTURLE.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PanelCodigo.ResumeLayout(false);
            this.PanelTortuga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tortuga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuKTURLE;
        private System.Windows.Forms.ToolStripMenuItem Archivo;
        private System.Windows.Forms.ToolStripMenuItem Archivo_Abrir;
        private System.Windows.Forms.ToolStripMenuItem Archivo_Guardar;
        private System.Windows.Forms.ToolStripMenuItem Archivo_GuardarComo;
        private System.Windows.Forms.ToolStripMenuItem Archivo_Salir;
        private System.Windows.Forms.ToolStripMenuItem Run;
        private System.Windows.Forms.ToolStripMenuItem Reportes;
        private System.Windows.Forms.ToolStripMenuItem Ayuda;
        private System.Windows.Forms.ToolStripMenuItem Ayuda_AcercaDe;
        private System.Windows.Forms.ToolStripMenuItem Ayuda_Usuario;
        private System.Windows.Forms.ToolStripMenuItem Ayuda_Tecnico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel PanelCodigo;
        private System.Windows.Forms.Label lbl_codigo;
        private System.Windows.Forms.RichTextBox txt_codigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Salida;
        private System.Windows.Forms.Panel PanelTortuga;
        private System.Windows.Forms.Label Lienzo;
        private System.Windows.Forms.PictureBox Tortuga;
        private System.Windows.Forms.RichTextBox txt_Consola;
    }
}

