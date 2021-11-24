using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Livraria_da_Lua.Classes.Databases
{
    public class SQLServerClass
    {
        //Fazendo a conexão com o Banco de dados
        public string stringConn;
        public SqlConnection connDB;

        public SQLServerClass()
        {
            try
            {
                //Conexão com o Banco de Dados SQL Server da Livraria
                stringConn = "Data Source=DESKTOP-LLJVKPA\\SQLEXPRESS;Initial Catalog=Livraria;Integrated Security=True";
                connDB = new SqlConnection(stringConn);
                connDB.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string SQLCommand(string SQL)
        {
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Encerra a conexão com o Bnaco de dados
        public void Close()
        {
            connDB.Close();
        }

    }
}