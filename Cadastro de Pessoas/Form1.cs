using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cadastro_de_Pessoas.Models;

namespace Cadastro_de_Pessoas
{
    public partial class Form1 : Form
    {
        Pessoa pessoa = new Pessoa();
        public Form1()
        {
            InitializeComponent();
            maskedTextBox1.Visible = true;
            textBox3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e) // cadastrar
        {
            textBox3.Visible = false;
            maskedTextBox1.Visible = true;
            pessoa.setCod(textBox1.Text);
            pessoa.setNome(textBox2.Text);
            pessoa.setIdade(calcularIdade());
            if (radioButton1.Checked)
            {
                pessoa.setSexo("M");
            } else if(radioButton2.Checked)
            {
                pessoa.setSexo("F");
            }

            PessoaBLL.validarCampos(pessoa);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            } else
            {
                MessageBox.Show("Dados inseridos com sucesso");
            }
        }

        public String calcularIdade()
        {
            string data = maskedTextBox1.Text;
            string[] parteData = data.Split('/');
            int ano = int.Parse(parteData[2]);

            int pegarAno = DateTime.Now.Year;

            string idadeReal = (pegarAno - ano).ToString();

            return idadeReal;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            PessoaBLL.desconectar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pessoa.setCod(textBox1.Text);
            PessoaBLL.validarCodigo(pessoa);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                textBox1.Text = pessoa.getCod();
                textBox2.Text = pessoa.getNome();
                maskedTextBox1.Visible = false;
                textBox3.Visible = true;
                textBox3.Text = pessoa.getIdade();
                if(pessoa.getSexo() == "F" || pessoa.getSexo() == "f")
                {
                    radioButton2.Checked = true;
                } else if(pessoa.getSexo()=="M" || pessoa.getSexo() == "m")
                {
                    radioButton1.Checked = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Visible =true;
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox3.Visible = false;
            radioButton1.Checked=false;
            radioButton2.Checked=false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PessoaBLL.conectar();
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
        }
    }
}
