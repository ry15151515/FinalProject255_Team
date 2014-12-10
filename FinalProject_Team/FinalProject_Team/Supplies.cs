using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace FinalProject_Team
{
    public partial class Supplies : Form
    {
        private List<clsSupply> mSupplies = new List<clsSupply>();
        private string mFile;
        private OleDbConnection mDB;

        public Supplies(/* OleDbConnection DB */)
        {
            InitializeComponent();
            // mDB = DB;
            // UpdateList(null);
        }

        private void UpdateList(string sql)
        {
            string Sql;
            if (sql == null)
            {
                Sql = "SELECT * FROM Supply;";
            }
            else
            {
                Sql = sql;
            }
            mSupplies = new List<clsSupply>();
            try
            {
                openDB();

                OleDbCommand cmd = new OleDbCommand(Sql, mDB);
                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clsSupply tmp = new clsSupply(rdr);
                    mSupplies.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMessage("An error occured; " + ex.Message);
            }
            finally
            {
                mDB.Close();
            }
            UpdateOutput();
        }

        private void UpdateOutput()
        {
            lstOutput.Items.Clear();
            lstOutput.Items.Add(
                "Size".PadRight(18) + "Color".PadRight(18) +
                "Price".PadRight(18) + "Date"
            );
            foreach (clsSupply tmp in mSupplies)
            {
                lstOutput.Items.Add(tmp);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double size = 0;
            string color = txtColor.Text;
            decimal price = 0;
            DateTime date = dtpDate.Value;
            if (!(
                Utility.validateInput(txtSize, 0, 1000, out size) &&
                Utility.validateInput(txtColor) &&
                Utility.validateInput(txtPrice, 0, 1000, out price)
            ))
            {
                return;
            }
            string sql = "INSERT INTO Supply" +
                " (SpoolSize, Color, Price, EntryDate) " +
                "VALUES (" +
                size.ToString() + ", '" + color + "', " +
                price.ToString() + ", #" + date.ToString() + "#)";
            try
            {
                openDB();
                OleDbCommand cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Utility.ShowMessage("An error occured; " + ex.Message);
            }
            finally
            {
                mDB.Close();
            }
            UpdateList(null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOutput.SelectedIndex < 1) {
                Utility.ShowMessage("Select a valid record to delete it");
                return;
            }
            int i = lstOutput.SelectedIndex - 1;
            int indx = (int)mSupplies[i].ID;
            string sql = "DELETE FROM Supply WHERE Supply_ID=" + indx;
            try
            {
                openDB();
                OleDbCommand cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Utility.ShowMessage("An error occured; " + ex.Message);
            }
            finally
            {
                mDB.Close();
            }
            UpdateList(null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double size = 0;
            string color = txtColor.Text;
            decimal price = 0;
            DateTime date = dtpDate.Value;
            if (lstOutput.SelectedIndex < 1)
            {
                Utility.ShowMessage("Select a valid record to update it");
                return;
            }
            int i = lstOutput.SelectedIndex - 1;
            int indx = (int)mSupplies[i].ID;
            if (!(
                Utility.validateInput(txtSize, 0, 1000, out size) &&
                Utility.validateInput(txtColor) &&
                Utility.validateInput(txtPrice, 0M, 1000M, out price)
            ))
            {
                return;
            }
            string sql = "UPDATE Supply SET " +
                "SpoolSize=" + size + ", " +
                "Color='" + color + "', " +
                "Price=" + price.ToString("0.0") +", " +
                "EntryDate=#" + date.ToString() + "# " +
                "WHERE Supply_ID=" + indx;
            try
            {
                openDB();
                OleDbCommand cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Utility.ShowMessage("An error occured; " + ex.Message);
            }
            finally
            {
                mDB.Close();
            }
            UpdateList(null);
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog of;
            string fileName = null;
            try
            {
                of = new OpenFileDialog();
                of.Title = "Select the client file to open";
                of.Filter = "Client Files (*.accdb)|*.accdb|All Files (*.*)|*.*";
                of.InitialDirectory = Path.Combine(Application.StartupPath, @"\Files");
                if (of.ShowDialog() == DialogResult.OK)
                {
                    fileName = of.FileName;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMessage(
                    "There was an unexpected error with the open dialog: " +
                    ex.Message
                );
                return;
            }
            if (fileName == null)
            {
                return;
            }
            mFile = fileName;
            UpdateList(null);
        }

        private void openDB()
        {
            string conn = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"] + mFile;
            mDB = new OleDbConnection(conn);
            mDB.Open();
        }

        private void lstOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOutput.SelectedIndex < 1)
            {
                return;
            }
            clsSupply tmp = mSupplies[lstOutput.SelectedIndex - 1];
            txtColor.Text = tmp.Color;
            txtPrice.Text = tmp.Price.ToString();
            txtSize.Text = tmp.Size.ToString();
            dtpDate.Value = tmp.Date;
        }
    }

}
