using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{

    public partial class Maintenance : Form
    {
        private List<clsMaintenance> mLogs = new List<clsMaintenance>();
        OleDbConnection mDB;
        string mClientFile;


        public Maintenance()
        {
            InitializeComponent();
        }

        private void openFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Client DB file to open";
            ofd.Filter = "Client (*.accdb)|*.accdb|All files (*.*)|*.*";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Databases");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Assign the filename
                mClientFile = ofd.FileName;
            }
        }

        public void displayMaintenance()
        {
            lstMaintenance.Items.Clear();

            string header = "PRINTER                DATE/TIME               CATEGORY";
            lstMaintenance.Items.Add(header);

            foreach (clsMaintenance line in mLogs)
            {
                string output =
                    line.Printer + "        " + line.DateTime.ToString() + "        " + line.Cateogory;
                lstMaintenance.Items.Add(output);
            }
        }

        //Fill the comboxes

        public void loadPrinters()
        {

            try
            {
                cmbPrinter.Items.Clear();
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;

                string sql = "SELECT * FROM Printer";

                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();

                while (rdr.Read() == true)
                {
                    clsComboBoxItem item = new clsComboBoxItem();
                    item.Text = (string)rdr["Printer_Name"];
                    item.Value = (object)rdr["Printer_ID"];
                    cmbPrinter.Items.Add(item);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

       /* public void loadCategories()
        {
            cmbCategory.Items.Clear();

            clsComboBoxItem item = new clsComboBoxItem();

            item.Text = "Unknown";
            item.Value = "Unkown";
            cmbCategory.Items.Add(item);

            item.Text = "Physical";
            item.Value = "Physical";
            cmbCategory.Items.Add(item);

            item.Text = "Logical";
            item.Value = "Logical";
            cmbCategory.Items.Add(item);
        }*/

        private void Maintenance_Load(object sender, EventArgs e)
        {
            openFile();
            loadMaintenance("SELECT P.Printer_ID, P.Printer_Name, M.Maintenance_ID, M.Maintenance_DateTime, M.Category, M.Details FROM Maintenance M INNER JOIN Printer P ON M.Printer_ID = P.Printer_ID");
            displayMaintenance();

            //Fill the combo boxes

            loadPrinters();
        }

        private void openDatabaseConnection()
        {

            string connectionString =
                ConfigurationManager.AppSettings["DBConnectionString"] + mClientFile;
            mDB = new OleDbConnection(connectionString);
        }

        private void closeDatabaseConnection()
        {
            if (mDB != null)
            {
                mDB.Close();
            }
        }

        private void lstMaintenance_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstMaintenance.SelectedIndex - 1;

            if (index > -1 && index < mLogs.Count)
            {
                clsMaintenance selected = mLogs[index];

                txtDetails.Text = selected.Details;
                cmbPrinter.Text = selected.Printer;
                txtCategory.Text = selected.Cateogory;
            }
            else
            {
                MessageBox.Show("Select a valid record!");
                index = -1;
                clearInput();
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            string printer;
            int printerID;
            DateTime date;
            string category;
            string details;

            if (cmbPrinter.SelectedIndex < 0)
            {
                MessageBox.Show("Please, select a printer!");
                return;
            }

            if (txtCategory.Text == "")
            {
                MessageBox.Show("Please, select a category!");
                return;
            }

            if (txtDetails.Text == "")
            {
                MessageBox.Show("Please, provide details about the issue");
                return;
            }

            clsComboBoxItem cPrinter = (clsComboBoxItem)cmbPrinter.SelectedItem;
            printerID = (int)cPrinter.Value;
            printer = cPrinter.Text;

            category = cCategory.Text;

            details = txtDetails.Text;
            date = logDate.Value;
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql;
                sql = "INSERT INTO Maintenance (Maintenance_DateTime, Category, Details, Printer_ID) VALUES (" +
                    clsSQL.ToSql(date) + ", " + clsSQL.ToSql(category) + ", " + clsSQL.ToSql(details) + ", " + clsSQL.ToSql(printerID) + ");";

                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
                clearInput();
                loadMaintenance("SELECT * FROM Maintenance");
                displayMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }

        }


        */
        private void loadMaintenance(string sql)
        {
            // Clear out the array before handling the file data.
            mLogs.Clear();
            // Read the data from the specified file.

            if (File.Exists(mClientFile) == false)
            {
                MessageBox.Show(mClientFile + " does not exist. Please open another DB file.");
                return;
            }

            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;

            OleDbDataReader rdr;
            try
            {
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();

                while (rdr.Read() == true)
                {
                    clsMaintenance log = new clsMaintenance(
                        (int)rdr["Maintenance_ID"],
                        (string)rdr["Printer_Name"],
                        (int)rdr["Printer_ID"],
                        (DateTime)rdr["Maintenance_DateTime"],
                        (string)rdr["Category"],
                        (string)rdr["Details"]
                    );

                    mLogs.Add(log);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        // The overloaded validateInput helper methods handle the existence check, type check, and range check for a given 
        // input form object and assigns the equivalent value to its corresponding variable. (This one handles DateTime data.)
        private bool validateInput(TextBox txtInput, DateTime min, DateTime max, out DateTime userInput)
        {
            string fieldName;
            fieldName = txtInput.Name.Substring(3);
            userInput = DateTime.Parse("01/01/1900");
            if (txtInput.Text == "")
            {
                MessageBox.Show("Please enter a date in the format mm/dd/yyyy for " + fieldName);
                txtInput.Focus();
                return false;
            }
            if (DateTime.TryParse(txtInput.Text, out userInput) == false)
            {
                MessageBox.Show("Only dates are allowed for " + fieldName + ". Please re-enter:");
                txtInput.Focus();
                return false;
            }
            if (userInput < min || userInput > max)
            {
                MessageBox.Show(fieldName + " must be between " + min.ToShortDateString() + " and " + max.ToShortDateString());
                txtInput.Focus();
                return false;
            }
            return true;
        }

        private void clearInput()
        {
            cmbPrinter.SelectedIndex = -1;
            txtCategory.Text = "";
            txtDetails.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string printer;
            int printerID;
            DateTime date;
            string category;
            string details;

            if (cmbPrinter.SelectedIndex < 0)
            {
                MessageBox.Show("Please, select a printer!");
                return;
            }

            if (txtCategory.Text == "")
            {
                MessageBox.Show("Please, select a category!");
                return;
            }

            if (txtDetails.Text == "")
            {
                MessageBox.Show("Please, provide details about the issue");
                return;
            }

            clsComboBoxItem cPrinter = (clsComboBoxItem)cmbPrinter.SelectedItem;
            printerID = (int)cPrinter.Value;
            printer = cPrinter.Text;

            category = txtCategory.Text;

            details = txtDetails.Text;
            date = logDate.Value;
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql;

                sql = "INSERT INTO Maintenance (Maintenance_DateTime, Category, Details, User_ID, Printer_ID) VALUES (" +
                    clsSQL.ToSql(date) + ", " + clsSQL.ToSql(category) + ", " + clsSQL.ToSql(details) + ", " + clsSQL.ToSql(1) + ", " + clsSQL.ToSql(printerID) + ");";

                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an unexpected problem: " + ex.Message);
            }
            finally
            {
                closeDatabaseConnection();

                clearInput();

                loadMaintenance("SELECT P.Printer_ID, P.Printer_Name, M.Maintenance_ID, M.Maintenance_DateTime, M.Category, M.Details FROM Maintenance M INNER JOIN Printer P ON M.Printer_ID = P.Printer_ID");
                displayMaintenance();
                //Fill the combo boxes
                loadPrinters();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstMaintenance.SelectedIndex - 1;

            if (index > -1 && index < mLogs.Count)
            {
                clsMaintenance selected = mLogs[index];

                if ((MessageBox.Show(selected.Printer + "'s log will be deleted. Do you want to proceed?", "Watch out!", MessageBoxButtons.OKCancel)) == DialogResult.OK)
                {
                    try
                    {
                        string sql;
                        openDatabaseConnection();
                        mDB.Open();
                        OleDbCommand cmd;
                        sql = "DELETE FROM Maintenance WHERE Maintenance_ID = " + clsSQL.ToSql(selected.MaintenanceID);
                        cmd = new OleDbCommand(sql, mDB);
                        cmd.ExecuteNonQuery();

                        // Erase the input values, notify the user, and display the current client roster
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an unexpected problem when deleting the client: " + ex.Message);
                    }
                    finally
                    {
                        closeDatabaseConnection();

                        clearInput();
                        loadMaintenance("SELECT P.Printer_ID, P.Printer_Name, M.Maintenance_ID, M.Maintenance_DateTime, M.Category, M.Details FROM Maintenance M INNER JOIN Printer P ON M.Printer_ID = P.Printer_ID");
                        displayMaintenance();
                        //Fill the combo boxes
                        loadPrinters();
                    }
                }
                else
                {

                }



            }
            else
            {
                MessageBox.Show("Select a valid record!");
                index = -1;
                clearInput();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int index = lstMaintenance.SelectedIndex - 1;

            if (index > -1 && index < mLogs.Count)
            {
                clsMaintenance selected = mLogs[index];

                string printer;
                int printerID;
                DateTime date;
                string category;
                string details;

                if (cmbPrinter.SelectedIndex < 0)
                {
                    MessageBox.Show("Please, select a printer!");
                    return;
                }

                if (txtCategory.Text == "")
                {
                    MessageBox.Show("Please, select a category!");
                    return;
                }

                if (txtDetails.Text == "")
                {
                    MessageBox.Show("Please, provide details about the issue");
                    return;
                }

                clsComboBoxItem cPrinter = (clsComboBoxItem)cmbPrinter.SelectedItem;
                printerID = (int)cPrinter.Value;
                printer = cPrinter.Text;

                category = txtCategory.Text;

                details = txtDetails.Text;
                date = logDate.Value;

                int maintenanceID = selected.MaintenanceID;

                try
                {
                    openDatabaseConnection();
                    mDB.Open();
                    OleDbCommand cmd;
                    string sql;

                    sql = "UPDATE Maintenance SET Maintenance_DateTime = " + clsSQL.ToSql(date)
                        + ", Category = " + clsSQL.ToSql(category)
                        + ", Details = " + clsSQL.ToSql(details)
                        + ", User_ID = " + clsSQL.ToSql(1)
                        + ", Printer_ID = " + clsSQL.ToSql(printerID)
                        + " WHERE Maintenance_ID = " + clsSQL.ToSql(maintenanceID) + ";";

                    cmd = new OleDbCommand(sql, mDB);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an unexpected problem: " + ex.Message);
                }
                finally
                {
                    closeDatabaseConnection();

                    clearInput();
                    loadMaintenance("SELECT P.Printer_ID, P.Printer_Name, M.Maintenance_ID, M.Maintenance_DateTime, M.Category, M.Details FROM Maintenance M INNER JOIN Printer P ON M.Printer_ID = P.Printer_ID");
                    displayMaintenance();

                    //Fill the combo boxes
                    loadPrinters();
                }
            }
            else
            {
                MessageBox.Show("Select a valid record!");
                index = -1;
                clearInput();
            }
        }

    }
}