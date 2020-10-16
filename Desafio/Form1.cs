using Desafio.Services;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desafio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConsumirApi_Click(object sender, EventArgs e)
        {
            var consumer = new Consumer();
            consumer.GetUsersFromApi();
            MessageBox.Show("Dados Carregados com Sucesso");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string company = txtEmpresa.Text;

            var userService = new UserService();

            if (userService.GetAllUsers().Count() == 0)
            {
                MessageBox.Show("Clique em Consumir Api para Buscar os dados");
                return;
            };

            var lstUsers = userService.SearchUsers(user, company);

            if (lstUsers.Count() == 0)
            {
                MessageBox.Show("Dados não encontrado.Tente Novamente");
            }

            dataGridView1.DataSource = lstUsers.ToList();

        }
    }
}
