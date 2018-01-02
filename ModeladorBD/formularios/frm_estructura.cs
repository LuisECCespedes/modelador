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
    public partial class frm_estructura : Form
    {       
        public frm_estructura()
        {
            InitializeComponent();
        }
        //SALIR
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //MODELADO DE EL ESQUEMA SEGUN EL CODIGO GENERADO
        private void btn_modelar_Click(object sender, EventArgs e)
        {
            //FORMULARIO DE ESTRUCTURA 
            frm_principal estruc = new frm_principal();
            //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
            String query = this.txt_query.Text;
            //CONEXION A BASE DATOS 
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
                    MessageBox.Show("Modelado Completado ");
                    this.Close();
                }
            }
            //CERRAMOS FORMULARIO DE MENSAJE
            estruc.abrirCerrarFormulario(false);
        }
        //ALMACENAMOS EL TEXTO MOSTRADO
        private void button1_Click(object sender, EventArgs e)
        {   //VARIABLE DE RUTA
            String path = "";
            //BUSCAMOS LA RUTA PARA GUARDAR EL ARCHIVO
            if (saveFileDialog1.ShowDialog()== DialogResult.OK)
            {   //ALMACENAMOS LA DIRECCION DEL ARCHIVO
                path = saveFileDialog1.FileName;
                //COMPROBAMOS EXISTENCIA Y REEMPLAZO
                if (!File.Exists(path))
                {   // ALMACENAMOS EL TEXTO COMO ARCHIVO
                    File.WriteAllText(path, txt_query.Text);
                    MessageBox.Show("Archivos Almacenados en :" + path);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Copiar al Porta Papeles
            Utiles._cliptext(txt_query.Text);
        }
    }
}
