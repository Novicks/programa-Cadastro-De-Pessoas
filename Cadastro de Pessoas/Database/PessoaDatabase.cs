using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Reflection.Emit;
using Cadastro_de_Pessoas.Models;
using System.Runtime.InteropServices;

namespace Cadastro_de_Pessoas.Database
{
    internal class PessoaDatabase
    {
        private static String strConection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BDLivros.mdb"; // altera caminho para redireciona ao banco de dados
        private static OleDbConnection conn = new OleDbConnection(strConection); // cria conexao atraves da string de conexao
        private static OleDbCommand cmd; // executa os comandos sql
        private static OleDbDataReader reader; // le os comandos recebido do banco de dados

        public static void conectar()
        {
            try
            {
                conn.Open();
            }catch (Exception)
            {
                Erro.setMsg("Não foi possivel se conectar ao banco de dados");
            }
        }
        public static void fechar()
        {
            conn.Close();
        }
        public static void cadastrarPeople(Pessoa pessoa)
        {
            String aux = "insert into tabPessoa(codigo,nome,idade,sexo) values (@codigo,@nome,@idade,@sexo)";
            cmd = new OleDbCommand(aux, conn);

            cmd.Parameters.Add("@codigo", OleDbType.VarChar).Value = pessoa.getCod();
            cmd.Parameters.Add("@nome", OleDbType.VarChar).Value = pessoa.getNome();
            cmd.Parameters.Add("@idade", OleDbType.VarChar).Value = pessoa.getIdade();
            cmd.Parameters.Add("@sexo", OleDbType.VarChar).Value = pessoa.getSexo();
        }
        public static void consultarPeople(Pessoa pessoa)
        {
            String aux = "select * from tabPessoa where codigo = @codigo";
            cmd = new OleDbCommand(aux, conn);

            cmd.Parameters.Add("@codigo", OleDbType.VarChar).Value =pessoa.getCod();

            reader = cmd.ExecuteReader();
            Erro.setErro(false); // setando erro como falso para caso retorne verdadeiro significa que o codigo não existe no sistema
            if (reader.Read())
            {
                pessoa.setCod(reader.GetString(0)); 
                pessoa.setNome(reader.GetString(1));
                pessoa.setIdade(reader.GetString(2));
                pessoa.setSexo(reader.GetString(3));
            }
        }
    }
}
