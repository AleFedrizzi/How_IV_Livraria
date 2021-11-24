using Livraria_da_Lua.Classes.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_da_Lua.Classes.Database
{
    public class FicharioSQLServer
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public SQLServerClass db;

        public FicharioSQLServer(string Tabela)
        {
            //Conexão com o banco de dados
            status = true;

            try
            {
                //Mensagem de conexão
                db = new SQLServerClass();
                tabela = Tabela;
                mensagem = "Conexão com a Tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com a Tabela com erro: " + ex.Message;
            }
        }

        public void Incluir(string Isbn, string jsonUnit)
        {
            status = true;

            try
            {
                //Conexão com o Banco de dados, teste e inclusão de livro
                //INSERT INTO CLIENT (ISBN, JSON) VALUES ('000001', '{...}')

                var SQL = "INSERT INTO " + tabela + " (Isbn, JSON) VALUES ('" + Isbn + "', '" + jsonUnit + "')";
                db.SQLCommand(SQL);

                status = true;
                mensagem = "Inclusão não permitida porque o Isbn já existe: " + Isbn;

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro" + ex.Message;
            }
        }

        public string Buscar(string Isbn)
        {
            status = true;
            try
            {
                //Conexão com o Banco de dados, teste e busca de dados de livro
                //SELECT ISBN, JSON FROM LIVRO WHERE ISBN = '00001'

                var SQL = "SELECT ISBN, JSON FROM " + tabela + " WHERE ISBN = '" + Isbn + "'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. : " + Isbn;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "ISBN não existente: " + Isbn;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar ISBN do livro" + ex.Message;
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();

            try
            {
                //Conexão com o Banco de dados, teste e buscar todos os livros
                //SELECTISBN, JSON FROM LIVRO

                var SQL = "SELECT ISBN, JSON FROM " + tabela;
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        List.Add(conteudo);

                    }
                    return List;

                }
                else
                {
                    status = false;
                    mensagem = "Não existem livros na base de dados";
                }
            }

            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar ISBN do livro" + ex.Message;
            }
            return List;
        }

        public void Apagar(string Isbn)
        {
            status = true;
            try
            {
                //Conexão com o Banco de dados, teste e apagar dados do livro
                var SQL = "SELECT ISBN, JSON FROM " + tabela + " WHERE ISBN = '" + Isbn + "'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    //DELETE FROM LIVRO WHERE ID '000001'

                    SQL = "DELETE FROM " + tabela + " WHERE ISBN = '" + Isbn + "'";
                    db.SQLCommand(SQL);

                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. : " + Isbn;
                }
                else
                {
                    status = false;
                    mensagem = "ISBN não existente: " + Isbn;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar ISBN do livro" + ex.Message;
            }
        }

        public void Alterar(string Isbn, string jsonUnit)
        {
            status = true;

            try
            {
                //Conexão com o Banco de dados, teste e alterar dados do livro
                var SQL = "SELECT ISBN, JSON FROM " + tabela + " WHERE ISBN = '" + Isbn + "'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    //UPDATE LIVRO SET JSON = '{...}' WHERE ISBN '000001'

                    SQL = "UPDATE " + tabela + " SET JSON = '" + jsonUnit + "' WHERE ISBN = '" + Isbn + "'";
                    db.SQLCommand(SQL);

                    status = true;
                    mensagem = "Alteração efetuada com sucesso. : " + Isbn;
                }
                else
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o livro não existe: " + Isbn;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro" + ex.Message;
            }
        }

    }
}