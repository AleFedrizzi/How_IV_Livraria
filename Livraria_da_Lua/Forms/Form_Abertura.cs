using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria_da_Lua.Forms
{
    public partial class Form_Abertura : Form
    {
        public Form_Abertura()
        {
            //Inicializa o aplicativo
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Encerra a aplicação
            Application.Exit();
        }

        //Botão de Cadastro de aplicativo
        //Após clicar vai para a página de cadastro de Produtos
        private void btnCadProdutos_Click(object sender, EventArgs e)
        {
            using (Form_CadProdutos fp = new Form_CadProdutos())
            {
                fp.ShowDialog();
            }
        }
    }
}
