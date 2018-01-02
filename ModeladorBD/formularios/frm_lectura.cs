using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ModeladorBD
{
    public partial class frm_lectura : Form
    {
        public frm_lectura()
        {
            InitializeComponent();
        }
        //ABRIR ARCHIVO Y COPIAR CONTENIDO
        private void button1_Click(object sender, EventArgs e)
        {
                //Abrimos el Archivo y realizamos la Lectura 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {   //Copiamos el Contenido en el Cuadro de Texto
                txt_query.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }
        //Salir
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //EJECUCION DE ARCHIVO
        private void btn_proceder_Click(object sender, EventArgs e)
        {   //FORMULARIO DE ESTRUCTURA 
            frm_principal estruc = new frm_principal();
            //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
            String query = this.txt_query.Text;
            //CONEXION A BASE DATOS 
            estruc.mensaje("Realizando la Ejecucion...");
            estruc.abrirCerrarFormulario(true);
            //Alamcenamos en variables "LUEGO SE VALIDA SU VALOR VACIO"
            String cuser = this.txtUser.Text, cpass = this.txtPass.Text, cport = this.txtPuerto.Text,
                cdata = this.txtBaseDatos.Text, chost = this.txtServidor.Text;
            if (ClsDatos.Conectar(cuser, cpass, chost, cport, cdata))
            {
                //ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                if (ClsDatos.run_script(query))
                {
                    //MENSAJE DE CONFIRMACION
                    MessageBox.Show("Ejecución Realizada");
                    this.Close();
                }
            }
            //CERRAMOS FORMULARIO DE MENSAJE
            estruc.abrirCerrarFormulario(false);
        }
    }
}
