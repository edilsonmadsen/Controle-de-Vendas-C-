using Projeto_Controle_Vendas.br.com.projeto.dao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Projeto_Controle_Vendas.br.com.projeto.view
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomp.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;

            // 2 passo - Criar um objeto da Classe CLienteDAO e chamar o metodo cadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            //recarregar o gridview
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txttelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            // Botão excluir
            Cliente obj = new Cliente();

            //pegar o codigo
            obj.codigo = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.excluirCliente(obj);

            //recarrega o gridview
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomp.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;

            obj.codigo = int.Parse(txtcodigo.Text);

            // 2 passo - Alterar um objeto da Classe CLienteDAO e chamar o metodo cadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            //recarregar o gridview
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pegar os dados da linha selecionada
            txtcodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtcomp.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            cbuf.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a guia Dados Pessoais
            tabClientes.SelectedTab = tabPage1;
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            //Botão pesquisar
            string nome = txtpesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.BuscarClientePorNome(nome);

            if(tabelaCliente.Rows.Count == 0)
            {
                //recarregar o gridview
                tabelaCliente.DataSource = dao.listarClientes();
            }
        }

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.ListarClientesPorNome(nome);

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            //Botão consultar 

            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/"+cep+"/xml/";

                DataSet dados = new DataSet();

                //dados.ReadXml(xml);
                dados.ReadXml(xml);

                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtcomp.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                cbuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Endereço não encontrado, por favor digite manualmente."+erro);
            }
        }

        private void txtcep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }

}
