using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Pessoas.Models
{
    internal class Pessoa
    {
        private String codigo;
        private String nome;
        private String sexo;
        private String idade;

        public void setCod(String codigo_) {codigo = codigo_;}
        public void setNome(String nome_) { nome = nome_; }
        public void setSexo(String sexo_) { sexo = sexo_; }
        public void setIdade(String idade_) { idade = idade_; }

        public String getCod() {  return codigo; }
        public String getNome() { return nome; }
        public String getSexo() { return sexo; }
        public String getIdade() { return idade; }
    }
}
