using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Livraria_da_Lua.Classes.Databases
{
    public class Fichario
    {
        public string diretorio;
        public string mensagem;
        public bool status;

        public Fichario(string Diretorio)
        {
            status = true;
            try
            {   //Verifica se o diretorio existe
                if (!(Directory.Exists(Diretorio)))
                {
                    //Se não existir cria o diretorio
                    Directory.CreateDirectory(Diretorio);
                }
                diretorio = Diretorio;
                mensagem = "Conexão com o fichario criada com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro" + ex.Message;
            }
        }

        public void Incluir(string Isbn, string jsonUnit)
        {
            status = true;

            try
            {
                if (File.Exists(diretorio + "\\" + Isbn + ".jspn"))
                {
                    status = false;
                    mensagem = "Inclusão não permitida porque o cliente já existe: " + Isbn;
                }
                else
                {
                    File.WriteAllText(diretorio + "\\" + Isbn + ".jspn", jsonUnit);
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. : " + Isbn;
                }
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
                if (!(File.Exists(diretorio + "\\" + Isbn + ".jspn")))
                {
                    status = false;
                    mensagem = "CPF não existente: " + Isbn;
                }
                else
                {
                    string conteudo = File.ReadAllText(diretorio + "\\" + Isbn + ".jspn");
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. : " + Isbn;
                    return conteudo;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar CPF do cliente" + ex.Message;
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();

            try
            {
                var Arquivos = Directory.GetFiles(diretorio, "*.jspn");

                for (int i = 0; i <= Arquivos.Length - 1; i++)
                {
                    string conteudo = File.ReadAllText(Arquivos[i]);
                    List.Add(conteudo);

                }
                return List;
            }

            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar CPF do cliente" + ex.Message;
            }
            return List;
        }

        public void Apagar(string Isbn)
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + Isbn + ".jspn")))
                {
                    status = false;
                    mensagem = "ISBN não existente: " + Isbn;
                }
                else
                {
                    File.Delete(diretorio + "\\" + Isbn + ".jspn");
                    status = true;
                    mensagem = "Exclusão efetuada com sucesso. : " + Isbn;
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
                if (!(File.Exists(diretorio + "\\" + Isbn + ".jspn")))
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o ISBN não existe: " + Isbn;
                }
                else
                {
                    File.Delete((diretorio + "\\" + Isbn + ".jspn"));
                    File.WriteAllText(diretorio + "\\" + Isbn + ".jspn", jsonUnit);
                    status = true;
                    mensagem = "Alteração realizada com sucesso. : " + Isbn;
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
