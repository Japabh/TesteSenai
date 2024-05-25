using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using static TesteSenai.Conexao;

namespace TesteSenai
{
    internal class Conexao
    {
        

        public class ConexaoBD
        {
            private MySqlConnection conexao;
            private string stringConexao = "Server=sql.freedb.tech;Database=freedb_Teste;Uid=freedb_TesteSenai;Password=*NN8Zugt234nM&B;";

            public ConexaoBD()
            {
                conexao = new MySqlConnection(stringConexao);
            }

            public void AbrirConexao()
            {
                try
                {
                    conexao.Open();
                    Console.WriteLine("Conexão aberta com sucesso!");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao abrir a conexão: " + ex.Message);
                }
            }

            public void FecharConexao()
            {
                try
                {
                    conexao.Close();
                    Console.WriteLine("Conexão fechada com sucesso!");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
                }
            }

            // Método para executar uma consulta SQL
            public DataTable Consultar(string sql)
            {
                DataTable dataTable = new DataTable();

                try
                {
                    AbrirConexao();
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }

                return dataTable;
            }

            // Método para executar uma instrução SQL que não retorna dados
            public bool ExecutarInstrucao(string sql)
            {
                try
                {
                    AbrirConexao();
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    cmd.Parameters.AddRange(parametros); // Adiciona os parâmetros à consulta SQL
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Instrução executada com sucesso!");
                    return true; // Indica que a instrução foi executada com sucesso
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao executar a instrução: " + ex.Message);
                    return false; // Indica que ocorreu um erro ao executar a instrução
                }
                finally
                {
                    FecharConexao();
                }
            }
        }
    }

}
