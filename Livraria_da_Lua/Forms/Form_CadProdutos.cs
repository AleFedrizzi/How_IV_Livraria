using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria_da_Lua.Classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;



namespace Livraria_da_Lua.Forms
{
    public partial class Form_CadProdutos : Form
    {
        public Form_CadProdutos()
        {
            InitializeComponent();
            //chamando LimparFormulário pq se tiver algum dado no formulário ele é limpo
            LimparFormulario();           
        }

        //Transformando todos TextBox e MaskedTextBox em vazio
        private void LimparFormulario()
        {
            Mask_ISBN.Text = "";
            Txt_Titulo.Text = "";
            Txt_SubTitulo.Text = "";
            Txt_Serie.Text = "";
            Txt_Volume.Text = "";
            Txt_Genero.Text = "";
            Txt_Editora.Text = "";
            Txt_Autor.Text = "";
            Txt_Tradutor.Text = "";
            Txt_Idioma.Text = "";
            Txt_edicao.Text = "";
            Txt_Ano.Text = "";
            Txt_Pagina.Text = "";
            Txt_Descricao.Text = "";
        }
        //Para sair do aplicativo
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Para incluir no Banco de dados as informações do livro
        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui chama a classe Prod_Livros.Unit pq estamos incluindo o livro
                Prod_Livros.Unit C = new Prod_Livros.Unit();
                //Chama a classe de de Leitura do Formulário
                C = LeituraFormulario();
                //Chama a classe que valida os dados que foram digitados no formulário
                C.validaClasse();
                C.IncluirFicharioSQL("Livro");

                //Após a inclusão do livro aparece a mensagem na tela do usuário confirmando a inclusão no banco de dados
                MessageBox.Show("OK: Cadastro efetivado", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (ValidationException Ex)
            {
                //Caso contrário mostra os erros encontrado no teste de dados
                MessageBox.Show(Ex.Message, "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Busca se o livro existe e se existir mostrar os dados do livro
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {            
            //Teste para verificar se o campo ISBN está vázio
            if (Mask_ISBN.Text == "")
            {
                MessageBox.Show("ISBN do livro vazio.", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Se ele passar no teste ele faz a busca no Banco de Dados e se retornar um ISBN válido ele preenche os dados.
                    //Se não ele mostra que o livro não existe através de uma mensagem
                    Prod_Livros.Unit C = new Prod_Livros.Unit();
                    C = C.BuscarFicharioSQL(Mask_ISBN.Text, "Livro");
                    if (C == null)
                    {
                        MessageBox.Show("Livro não encontrado", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Chama a função que preenche os campos com os dados do livro
                        EscreveFormulario(C);
                    }

                    EscreveFormulario(C);

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Para alterar dados do livro existente
        private void Btn_Alterar_Click(object sender, EventArgs e)
        {
            //Teste para verificar se o campo ISBN está vazio
            if (Mask_ISBN.Text == "")
            {
                MessageBox.Show("ISBN do livro vazio.", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Prod_Livros.Unit C = new Prod_Livros.Unit();
                    
                    //Chama a classe de de Leitura do Formulário
                    C = LeituraFormulario();
                    
                    //Chama a classe que valida os dados que foram digitados no formulário
                    //Após a validação, atualiza os dados no Banco de Dados.
                    C.validaClasse();
                    C.AlterarFicharioSQL("Livro");

                    //Mostra a mensagem que o livro foi alterado com sucesso.
                    MessageBox.Show("OK: livro alterado com sucesso", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (ValidationException Ex)
                {
                    //Caso contrário mostra os erros encontrado no teste de dados
                    MessageBox.Show(Ex.Message, "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Para excluir todos os dados de um livro
        private void Btn_Excluir_Click(object sender, EventArgs e)
        {
            //Verifica se o ISBN está vazio ou não
            if (Mask_ISBN.Text == "")
            {
                MessageBox.Show("ISBN do livro vazio.", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Faz a busca no banco de dados se o Livro existe
                    Prod_Livros.Unit C = new Prod_Livros.Unit();
                    C = C.BuscarFicharioSQL(Mask_ISBN.Text, "Livro");

                    // Se o livro nao existe ele mostra a mensagem
                    if (C == null)
                    {
                        MessageBox.Show("ISBN não encontrado", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Cx de dialogo para conformação de excluir dados do ISBN
                        EscreveFormulario(C);
                        Frm_Questao Db = new Frm_Questao("cut", "Você quer excluir o livro?");
                        Db.ShowDialog();
                        if (Db.DialogResult == DialogResult.Yes)
                        {
                            C.ExcluirFicharioSQL("Livro");
                            MessageBox.Show("OK: Livro excluido com sucesso", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFormulario();
                        }
                        {
                            //Após a confirmação da exclusão dos dados do livro aparece a mensagem:
                            MessageBox.Show("OK: livro excluido com sucesso", "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFormulario();
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Livraria da Lua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Para limpar todos todos os dados do um livro na página de cadatro de livro
        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            //Chama a classe para limpar o formulário
            LimparFormulario();
        }

        //Interliga os dados do Banco de dados aos campos MaskTextBox e TextBox da página de cadastro de livros
        Prod_Livros.Unit LeituraFormulario()
        {
            Prod_Livros.Unit C = new Prod_Livros.Unit();

            C.Isbn = Mask_ISBN.Text;
            C.Titulo = Txt_Titulo.Text;
            C.SubTitulo = Txt_SubTitulo.Text;
            C.Serie = Txt_Serie.Text;
            C.Volume = Txt_Volume.Text;
            C.Genero = Txt_Genero.Text;
            C.Editora = Txt_Editora.Text;
            C.Autor = Txt_Autor.Text;
            C.Tradutor = Txt_Tradutor.Text;
            C.Idioma = Txt_Idioma.Text;
            C.Edicao = Txt_edicao.Text;
            C.Ano = Txt_Ano.Text;
            C.Paginas = Txt_Pagina.Text;
            C.Descricao = Txt_Descricao.Text;

            return C;
        }

        //Interliga os dados que foram digitados ao Banco de dados
       void EscreveFormulario(Prod_Livros.Unit C)
        {
            Mask_ISBN.Text = C.Isbn;
            Txt_Titulo.Text = C.Titulo;
            Txt_SubTitulo.Text = C.SubTitulo;
            Txt_Serie.Text = C.Serie;
            Txt_Volume.Text = C.Volume;
            Txt_Genero.Text = C.Genero;
            Txt_Editora.Text = C.Editora;
            Txt_Autor.Text = C.Autor;
            Txt_Tradutor.Text = C.Tradutor;
            Txt_Idioma.Text = C.Idioma;
            Txt_edicao.Text = C.Edicao;
            Txt_Ano.Text = C.Ano;
            Txt_Pagina.Text = C.Paginas;
            Txt_Descricao.Text = C.Descricao;
        }

        private void Btn_BuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Prod_Livros.Unit C = new Prod_Livros.Unit();
                var ListaBusca = C.ListaFicharioSQL("Livro");
                Frm_Busca FForm = new Frm_Busca(ListaBusca);
                FForm.ShowDialog();
                if (FForm.DialogResult == DialogResult.OK)
                {
                    var idSelect = FForm.idSelect;
                    //C.BuscarFichario(idSelect, "C:\\Users\\bruno\\Desktop\\WinForms\\UNIVALI\\PetShop\\Fichario");
                    //C.BuscarFicharioDB(idSelect, "Cliente");
                    C.BuscarFicharioSQL(idSelect, "Cliente");

                    if (C == null)
                    {
                        MessageBox.Show("Identificador não encontrado", "Cão.mia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        EscreveFormulario(C);
                    }
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Cão.mia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

