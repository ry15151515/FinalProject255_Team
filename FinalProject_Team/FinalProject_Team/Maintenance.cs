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

    public partial class Maintenance : Form
    {
        private List<clsMaintenance> mLogs = new List<clsMaintenance>();

        public Maintenance()
        {
            InitializeComponent();
        }

        public void loadMaintenance()
        {

          mLogs.Add(new clsMaintenance("HP N02", DateTime.Now, "Unknown", "It doesn't turn on"));
          mLogs.Add(new clsMaintenance("HP N03", DateTime.Now, "Physical", "The USB cable has broken"));
          mLogs.Add(new clsMaintenance("HP N03", DateTime.Now, "Logical", "Print error #441527"));

        }

        public void loadMaintenanceList()
        {
            string header = "PRINTER                DATE/TIME               CATEGORY";
            lstMaintenance.Items.Add(header);

            foreach(clsMaintenance line in mLogs)
            {
                string output =
                    line.Printer + "        " + line.DateTime.ToString() + "        " + line.Cateogory;
                lstMaintenance.Items.Add(output);
            }
        }

        public void loadPrinters()
        {
            clsComboBoxItem item = new clsComboBoxItem();

            item.Text = "HP 002";
            item.Value = "HP 002";
            cmbPrinter.Items.Add(item);

            item.Text = "HP 003";
            item.Value = "HP 002";
            cmbPrinter.Items.Add(item);

            item.Text = "HP 004";
            item.Value = "HP 002";
            cmbPrinter.Items.Add(item);

        }

        public void loadCategories()
        {
            clsComboBoxItem item = new clsComboBoxItem();

            item.Text = "Unknown";
            item.Value = "HP 002";
            cmbCategory.Items.Add(item);

            item.Text = "Physical";
            item.Value = "HP 002";
            cmbCategory.Items.Add(item);

            item.Text = "Logical";
            item.Value = "HP 002";
            cmbCategory.Items.Add(item);

        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            loadMaintenance();
            loadMaintenanceList();
            loadPrinters();
            loadCategories();
        }

        private void lstMaintenance_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstMaintenance.SelectedIndex - 1;

            clsMaintenance selected = mLogs[index];

            txtDetails.Text = selected.Details;
            cmbPrinter.Text = selected.Printer;
            cmbCategory.Text = selected.Cateogory;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
