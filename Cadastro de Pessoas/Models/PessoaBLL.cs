using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro_de_Pessoas.Database;

namespace Cadastro_de_Pessoas.Models
{
    internal class PessoaBLL
    {
        // transferindo metodos para trabalho de múltiplas camadas
        public static void conectar()
        {
            PessoaDatabase.conectar();
        }
        public static void desconectar()
        {
            PessoaDatabase.fechar();
        }
        //  validando campos
        public static void validarCodigo(Pessoa pessoa)
        {
            Erro.setErro(false);
            if (string.IsNullOrEmpty(pessoa.getCod()))
            {
                Erro.setMsg("O campo código é de preenchimento obrigatório!");
                return;
            }
            PessoaDatabase.consultarPeople(pessoa);
        }
        public static void validarCampos(Pessoa pessoa)
        {
            Erro.setErro(false);
            if (string.IsNullOrEmpty(pessoa.getCod()))
            {
                Erro.setMsg("O campo código é de preenchimento obrigatório!");
                return;
            }
            if (string.IsNullOrEmpty(pessoa.getNome()))
            {
                Erro.setMsg("O campo nome é de preenchimento obrigatório!");
                return;
            }
            if (string.IsNullOrEmpty(pessoa.getIdade()))
            {
                Erro.setMsg("O campo idade é de preenchimento obrigatório!");
                return ;
            }
            if (string.IsNullOrEmpty(pessoa.getSexo()))
            {
                Erro.setMsg("E necessario selecionar o gênero!");
                return;
            }
            try
            {
                int.Parse(pessoa.getIdade());
            }
            catch (Exception)
            {
                Erro.setMsg("A idade deve ser inserida em formato de data 00/00/0000");
                return;
            }

            if(int.Parse(pessoa.getIdade()) <= 0)
            {
                Erro.setMsg("O campo idade so permite valores acima de 0");
                return;
            }
            // após todas verificações ele cadastra o usuário:
            PessoaDatabase.cadastrarPeople(pessoa);
        }
    }
}
