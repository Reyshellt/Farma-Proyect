using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_LN;

namespace C_PR
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textUser.Text != "")
            {
                if (textClave.Text != "")
                {
                    userModel user = new userModel();
                    var validLogin = user.loginUser(textUser.Text, textClave.Text);
                    if(validLogin == true)
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o Clave incorrectos. Favor colocar nuevamente.");
                        textClave.Clear();
                        textUser.Focus();
                    }

                }
                else msgError("Por Favor digitar Clave");
            }
            else msgError("Por Favor digitar Usuario");
        }

        private void msgError(string msg)
        {
            lbError.Text = "    " + msg;
            lbError.Visible = true;
        }

        private void Logout (object sender, FormClosedEventArgs e) 
        {
            textClave.Clear ();
            textUser.Clear ();
            lbError.Visible = false;
            this.Show();
            textUser.Focus ();
        
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textClave_TextChanged(object sender, EventArgs e)
        {
            

        }

        
    }
}
