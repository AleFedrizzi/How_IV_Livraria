using System;
using SLRDbConnector;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria_da_Lua.Forms;

namespace Livraria_da_Lua
{
    public partial class Form1 : Form
    {
        DbConnector db;
        public Form1()
        {
            //Fazemos a inicialização do programa e chamamos a começão com o banco de dados
            InitializeComponent();
            db = new DbConnector();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //Encerramos a aplicação
            Application.Exit();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                if (checkLogin())
                {
                    //Se o login e senha estiverem corretos, abre a página de abertura
                    using (Form_Abertura fd = new Form_Abertura())
                    {
                        fd.ShowDialog();
                    }
                }
            }
        }

        private bool checkLogin()
        {
            //Faz o teste se o login e senha com o banco de dados estão corretos
            string userName = db.getSingleValue("select UserName from tblUsers where UserName = '" + txtBoxLogin.Text + "' and Password = '" + txtBoxSenha.Text + "'", out userName, 0);
            if(userName == null)
            {
                //mostra a mensagem que a senha está incorreta
                MessageBox.Show("Login ou senha estão incorretos", "Detalhes incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                //Se tiver tudo ok, ele muda o status para true e libera a página de abertura
                return true;
            }
        }

        private bool isFormValid()
        {
            //Faz o teste se todos os campos estão preenchidos
            if (txtBoxLogin.Text.ToString().Trim() == string.Empty || txtBoxLogin.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Os campos obrigatórios estão vazios", "Por favor preencha todos os campos obrigatórios....!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
