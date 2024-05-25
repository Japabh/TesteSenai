using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TesteSenai
{
    public partial class FrmTelaProfessor : Form
    {

        private string stringConexao = "Server=sql.freedb.tech;Database=freedb_Teste;Uid=freedb_TesteSenai;Password=*NN8Zugt234nM&B;";

        MySqlConnector.MySqlCommand cmd;
        string Email;
        string Senha;


        public FrmTelaProfessor()
        {
            InitializeComponent();
        }

        private void FrmTelaProfessor_Load(object sender, EventArgs e)
        {

        }
    }
}
