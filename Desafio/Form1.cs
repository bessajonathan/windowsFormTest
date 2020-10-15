using Desafio.Services;
using System;
using System.Data;
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
        }

    }
}
