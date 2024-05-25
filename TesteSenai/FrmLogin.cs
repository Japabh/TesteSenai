using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static TesteSenai.Conexao;

namespace TesteSenai
{
    public partial class FrmLogin : Form
    {

        private void LimparCampos()
        {
            TxtEmail.Clear();
            TxtSenha.Clear();
        }


        private string stringConexao = "Server=sql.freedb.tech;Database=freedb_Teste;Uid=freedb_TesteSenai;Password=*NN8Zugt234nM&B;";

        Conexao con = new Conexao();
        MySqlConnector.MySqlCommand cmd;
        string Email;
        string Senha;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void chamarLogin()
        {
            if (TxtEmail.Text.Trim() == "" || TxtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Digite seu Email");

                return;
            }
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            chamarLogin();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Este evento não tem nenhuma implementação.
            // Se você não planeja usar este evento, pode removê-lo do código.
        }

        private void label1_Click(object sender, EventArgs e)
        {
        // Este evento não tem nenhuma implementação.
        // Se você não planeja usar este evento, pode removê-lo do código.
        }

        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {
            // Este evento não tem nenhuma implementação.
            // Se você não planeja usar este evento, pode removê-lo do código.
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            // Este evento não tem nenhuma implementação.
            // Se você não planeja usar este evento, pode removê-lo do código.
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            // Obtém os dados do formulário
            string Email = TxtEmail.Text;
            string senha = TxtSenha.Text;

            // Verifica se o nome de usuário e a senha foram fornecidos
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            ConexaoBD conexaoBD = new ConexaoBD(); // Cria uma instância da classe ConexaoBD

            // Cria os parâmetros para a consulta SQL
            MySql.Data.MySqlClient.MySqlParameter parametroNome = new MySql.Data.MySqlClient.MySqlParameter("@nome", Email);
            MySql.Data.MySqlClient.MySqlParameter parametroSenha = new MySql.Data.MySqlClient.MySqlParameter("@senha", senha);

            // Inserir os dados do usuário no banco de dados
            if (conexaoBD.ExecutarInstrucao("INSERT INTO usuarios (nome, senha) VALUES (@nome, @senha)", parametroNome, parametroSenha))
            {
                MessageBox.Show("Usuário cadastrado com sucesso!");
                LimparCampos(); // Método para limpar os campos do formulário após o cadastro
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar usuário.");
            }
        }

        // Método para verificar se um usuário já está cadastrado
        private bool UsuarioExiste(string Email)
        {
            // Verifica se o arquivo de usuários existe
            if (File.Exists(Email))
            {
                // Lê todas as linhas do arquivo
                string[] linhas = File.ReadAllLines(Email);

                // Verifica se alguma linha contém o nome do usuário fornecido
                foreach (string linha in linhas)
                {
                    string[] dadosUsuario = linha.Split(',');
                    if (dadosUsuario.Length > 0 && dadosUsuario[0].Equals(Email, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // Este evento não tem nenhuma implementação.
            // Se você não planeja usar este evento, pode removê-lo do código.
        }
    }
}
