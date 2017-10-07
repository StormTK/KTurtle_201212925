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

namespace KTurtle_201212925
{
    public partial class Kturtle : Form
    {
        List<Tuple<int, String, int, int, int, String>> Tokens = new List<Tuple<int, String, int, int, int, String>>();
        List<Tuple<int, int, int, String>> Errores = new List<Tuple<int, int, int, String>>();
        String RutaDocumento = "nada";
        AnalizadorLexico AnalizarTexto = new AnalizadorLexico();
        Boolean Analisis = false;
        public Kturtle()
        {
            InitializeComponent();
        }

        private void Archivo_Abrir_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog AbrirArchivo = new OpenFileDialog();
                AbrirArchivo.Filter = "Archivo KTURTLE|*.ktl";
                AbrirArchivo.Title = "Abrir Archivo de KTURTLE";
                if (AbrirArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = AbrirArchivo.FileName;
                    RichTextBox PestañaActual = new RichTextBox();
                    StreamReader CargarFile = new StreamReader(Ruta);
                    RutaDocumento = Ruta;
                    txt_codigo.Text = CargarFile.ReadToEnd();
                    CargarFile.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (Analisis)
            {
                DialogResult dialogResult = MessageBox.Show("Ya realizo un Analisis Léxico. \n\r Si desea realizar otro perdera los datos del anterior Analisis Léxico. \n\r ¿Desea continuar con el Analisis Léxico?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Analizar();
                }
            }
            else
            {
                Analizar();
            }
        }

        private void Analizar()
        {
            if (txt_codigo.Text.Equals(""))
            {
                MessageBox.Show("No hay Texto para Analizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Analisis == false)
                {
                    Reportes.Enabled = true;
                }
                Analisis = true;
                try
                {
                    AnalizarTexto.AnalizarTexto(txt_codigo.Text);
                    int[] TamañoLienzo = AnalizarTexto.getTamañoLienzo();
                    Lienzo.Size = (new System.Drawing.Size(TamañoLienzo[0], TamañoLienzo[1]));
                    switch (AnalizarTexto.getColorLienzo())
                    {
                        case 0:
                            {
                                Lienzo.BackColor = Color.White;
                                break;
                            }
                        case 1:
                            {
                                Lienzo.BackColor = Color.SkyBlue;
                                break;
                            }
                        case 2:
                            {
                                Lienzo.BackColor = Color.Yellow;
                                break;
                            }
                    }
                    txt_Consola.Text = AnalizarTexto.getConsola();
                    MessageBox.Show("Se ha realizado el analisis lexico exitosamente.", "Analisis Léxico Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ha ocurrido un error durante  el Analisis Lexico. Intentalo Nuevamente");
                }
            }
        }

        private void GuardarToken()
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "HTML|*.html";
                GuardarArchivo.Title = "Guardar Reporting Service Token";
                GuardarArchivo.DefaultExt = "html";
                GuardarArchivo.AddExtension = true;
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = GuardarArchivo.FileName;
                    StreamWriter Guardar = new StreamWriter(Ruta);
                    Guardar.WriteLine("<html !DOCTYPE> <head><title>Reporting Service - Tokens</title> <style type=\"text/css\"> body {width: 100%; background: #004d4d; font-family: Calibri;} h1{font-size: 30px;text-align: center;color: #fff;font-weight: bold;}table { border-collapse: collapse;margin: 0 auto;}table, th, td {text-align: center;padding: 10px 20px;}th, td {border-bottom: 1px solid #ddd;}th{ background-color: #006767; color: white;padding: 10px;font - size: 20px;font-weight: bold;}tr{background: #fff;}tr:nth-child(even) { background-color: #e5f2f2}tr:hover {background: #4ca6a6; font-weight: bold;}</style></head> <body><h1>Reporting Service - Tokens</h1> <table><tr><th><strong> No. </strong></th><th><strong> Lexema </strong></th><th><strong> Fila </strong></th><th><strong>Columna</strong></th><th><strong>IdToken</strong></th><th><strong>Token</strong></th></th> ");
                    Tokens = AnalizarTexto.getHTMLToken();
                    foreach (var html in Tokens)
                    {
                        Guardar.WriteLine("<tr><td>" + html.Item1 + "</td><td>" + html.Item2 + "</td><td>" + html.Item3 + "</td><td>" + html.Item4 + "</td><td>" + html.Item5 + "</td><td>" + html.Item6 + "</td></tr>");
                    }
                    Guardar.WriteLine("</table></body></html>");
                    Guardar.Close();
                }
            }
            catch
            {

            }
        }
        private void GuardarError()
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "HTML|*.html";
                GuardarArchivo.Title = "Guardar Reporting Service Errores";
                GuardarArchivo.DefaultExt = "html";
                GuardarArchivo.AddExtension = true;
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = GuardarArchivo.FileName;
                    StreamWriter Guardar = new StreamWriter(Ruta);
                    Guardar.WriteLine("<html !DOCTYPE> <head><title>Reporting Service - Errores</title> <style type=\"text/css\"> body {width: 100%; background: #004d4d; font-family: Calibri;} h1{font-size: 30px;text-align: center;color: #fff;font-weight: bold;}table { border-collapse: collapse;margin: 0 auto;}table, th, td {text-align: center;padding: 10px 20px;}th, td {border-bottom: 1px solid #ddd;}th{ background-color: #006767; color: white;padding: 10px;font - size: 20px;font-weight: bold;}tr{background: #fff;}tr:nth-child(even) { background-color: #e5f2f2}tr:hover {background: #4ca6a6; font-weight: bold;}</style></head> <body><h1>Reporting Service - Tokens</h1> <table><tr><th><strong> No. </strong></th><th><strong> Fila </strong></th><th><strong>Columna</strong></th><th><strong>Caracter</strong></th><th><strong>Descripcion</strong></th></tr> ");
                    Errores = AnalizarTexto.getHTMLError();
                    foreach (var html in Errores)
                    {
                        Guardar.WriteLine("<tr><td>" + html.Item1 + "</td><td>" + html.Item2 + "</td><td>" + html.Item3 + "</td><td>" + html.Item4 + "</td><td>" + "Desconocido</td></tr>");
                    }
                    Guardar.WriteLine("</table></body></html>");
                    Guardar.Close();
                }
            }
            catch
            {

            }
        }

        private void Reportes_Click(object sender, EventArgs e)
        {
            GuardarToken();
            if (AnalizarTexto.getCantidadErrores() > 0)
            {
                GuardarError();
            }
        }

        private void Archivo_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "Archivo KTURTLE|*.ktl";
                GuardarArchivo.Title = "Guardar Archivo - KTURTLE";
                GuardarArchivo.DefaultExt = "vp502";
                GuardarArchivo.AddExtension = true;

                if ((RutaDocumento.Equals("nada")))
                {
                    if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                    {
                        String Ruta = GuardarArchivo.FileName;

                        StreamWriter Guardar = new StreamWriter(Ruta);
                        foreach (object line in txt_codigo.Lines)
                        {
                            Guardar.WriteLine(line);
                        }
                        Guardar.Close();
                        RutaDocumento = Ruta;

                        // = Path.GetFileNameWithoutExtension(Ruta) + Path.GetExtension(Ruta);

                    }
                }
                else
                {
                    StreamWriter Guardar = new StreamWriter(RutaDocumento);
                    foreach (object line in txt_codigo.Lines)
                    {
                        Guardar.WriteLine(line);
                    }
                    Guardar.Close();
                }

            }
            catch (Exception)
            {

            }
        }

        private void Archivo_GuardarComo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "Archivo KTURTLE|*.ktl";
                GuardarArchivo.Title = "Guardar Archivo - KTURTLE";
                GuardarArchivo.DefaultExt = "vp502";
                GuardarArchivo.AddExtension = true;
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = GuardarArchivo.FileName;

                    StreamWriter Guardar = new StreamWriter(Ruta);
                    foreach (object line in txt_codigo.Lines)
                    {
                        Guardar.WriteLine(line);
                    }
                    Guardar.Close();
                    RutaDocumento = Ruta;

                    // = Path.GetFileNameWithoutExtension(Ruta) + Path.GetExtension(Ruta);

                }
            }
            catch (Exception)
            {

            }
        }

        private void Archivo_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if ((RutaDocumento.Equals("nada")))
                {
                    DialogResult dialogResult = MessageBox.Show("Cerrará el Programa sin Guardar algunos Archivos. \n\r ¿Desea guardar el Archivo antes de salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveFileDialog GuardarArchivo = new SaveFileDialog();
                        GuardarArchivo.Filter = "Archivo KTURTLE|*.ktl";
                        GuardarArchivo.Title = "Guardar Archivo - KTURTLE";
                        GuardarArchivo.DefaultExt = "vp502";
                        GuardarArchivo.AddExtension = true;
                        if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                        {
                            String Ruta = GuardarArchivo.FileName;

                            StreamWriter Guardar = new StreamWriter(Ruta);
                            foreach (object line in txt_codigo.Lines)
                            {
                                Guardar.WriteLine(line);
                            }
                            Guardar.Close();
                            RutaDocumento = Ruta;

                            // = Path.GetFileNameWithoutExtension(Ruta) + Path.GetExtension(Ruta);

                        }
                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception)
            {

            }
        }

        private void Ayuda_Usuario_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "ManualUsuario_201212925.pdf";
            proc.Start();
        }

        private void Ayuda_Tecnico_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "ManualTecnico_201212925.pdf";
            proc.Start();
        }

        private void Ayuda_AcercaDe_Click(object sender, EventArgs e)
        {
            FormEstudiante Mostrar = new FormEstudiante();
            Mostrar.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Mostrar.Show();
        }
    }
}
