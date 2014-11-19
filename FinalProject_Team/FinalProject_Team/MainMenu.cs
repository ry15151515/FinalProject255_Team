using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Team
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_Maintenance_Info_Click(object sender, EventArgs e)
        {
            Form maintenance = new Maintenance();
            maintenance.ShowDialog();
        }

        private void btnPrinterUse_Click(object sender, EventArgs e)
        {
            Form printer = new PrinterUse();
            printer.ShowDialog();
        }

        private void btnSupplies_Click(object sender, EventArgs e)
        {
            Form supplies = new Supplies();
            supplies.ShowDialog();
        }

        private void btnAddJob_Click(object sender, EventArgs e)
        {
            Form job = new AddJob();
            job.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form user = new UserAdd();
            user.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Form login = new LoginForm();
            login.ShowDialog();
        }

    }
}
