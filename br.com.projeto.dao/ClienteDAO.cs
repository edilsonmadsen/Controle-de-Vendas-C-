using MySql.Data.MySqlClient;
using Projeto_Controle_Vendas.br.com.projeto.connection;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.dao
{
    public class ClienteDAO
    {
        private MySqlConnection conexao;

        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarCliente
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                // 1 passo - definir o cmd sql - insert into
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                                values (@nome,@rg,@cpf,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                // 2 passo - organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                // 3 passo - abrir conexão e executar o comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region AlterarCliente

        public void alterarCliente(Cliente obj)
        {
            try
            {
                // 1 passo - definir o cmd sql - update set
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,
                    cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                    where id=id";

                // 2 passo - organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                // 3 passo - abrir conexão e executar o comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente alterado com sucesso!");
                conexao.Close();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region ExcluirCliente

        public void excluirCliente(Cliente obj)
        {
            try
            {
                // 1 passo - definir o cmd sql - delete from
                string sql = @"delete from tb_clientes where id=@id";

                // 2 passo - organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
              
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                // 3 passo - abrir conexão e executar o comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluido com sucesso!");
                conexao.Close();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion

        #region ListarClientes
        public DataTable listarClientes()
        {
            try
            {
                // 1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes";

                // 2 passo - Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3 passo - Criar o MySQLDataApter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);
                conexao.Close();
                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region BuscarClientePorNome

        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                // 1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome = @nome";

                // 2 passo - Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3 passo - Criar o MySQLDataApter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);
                conexao.Close();
                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao executar o comando sql: " + erro);
                return null;
            }

        }


        #endregion

        #region ListarClientesPorNome
        public DataTable ListarClientesPorNome(string nome)
        {
            try
            {
                // 1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome like @nome";

                // 2 passo - Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3 passo - Criar o MySQLDataApter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);
                conexao.Close();
                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion
    }
}
