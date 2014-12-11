using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Team
{

    // Form written by Tyler Philbrick
    // CRUD Operations wriiten by Ryan Ludwig

    public partial class UserAdd : Form
    {

        private List<clsUser> mUsers = new List<clsUser>();
        private OleDbConnection mDB;
        private string mClientFile;

        public UserAdd()
        {
            InitializeComponent();
            //loadExampleData();
            displayData();
        }

        //private void loadExampleData()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        mUsers.Add(new clsUser("Tyler", "Philbrick", "Technology",
        //            "CIT", "Toys", "Student", DateTime.Now, "t5@purdue.edu", false));
        //    }
        //}

        private void loadUsers(string sql)
        {
            clsUser user;
            mUsers.Clear();

            if (File.Exists(mClientFile) == false)
            {
                Utility.ShowMessage(mClientFile + "does not exist.");
            }

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;

                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();

                while (rdr.Read() == true)
                {
                    user = new clsUser((int)rdr["User_ID"],
                            (string)rdr["FName"],
                            (string)rdr["Lname"],
                            (string)rdr["College"],
                            (string)rdr["Major"],
                            (string)rdr["PInterest"],
                            (string)rdr["Status"],
                            (DateTime)rdr["Birthdate"],
                            (string)rdr["Phone"],
                            (string)rdr["Email"],
                            (string)rdr["Gender"]);
                    mUsers.Add(user);
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Utility.ShowMessage("There was an unexpected error loading the data: " + ex);

            }
            finally
            {
                closeDatabaseConnection();
            }

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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql;

            clsUser tmp = checkedNewUser();
            if (tmp == null)
                return;
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                sql = "INSERT INTO User (FName, LName, College, Major, PInterest, Status, Birthdate, Phone, Email, Gender) VALUES (" +
                  clsSQL.ToSql(tmp.FName) + ", " +
                  clsSQL.ToSql(tmp.LName) + ", " +
                  clsSQL.ToSql(tmp.College) + ", " +
                  clsSQL.ToSql(tmp.Major) + ", " +
                  clsSQL.ToSql(tmp.Interest) + ", " +
                  clsSQL.ToSql(tmp.Status) + ", " +
                  clsSQL.ToSql(tmp.Birthday) + ", " +
                  clsSQL.ToSql(tmp.Phone) + ", " +
                  clsSQL.ToSql(tmp.Email) + ", " +
                  clsSQL.ToSql(tmp.Gender) + ";";

                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

                //Lookup ID of Entry? Then add to Associative Entity?

                //sql = "SELECT * FROM User WHERE FName = " + clsSQL.ToSql(txtFName.Text) + " AND LName = " + clsSQL.ToSql(txtLName.Text);

                //OleDbDataReader rdr;
                //cmd = new OleDbCommand(sql, mDB);
                //rdr = cmd.ExecuteReader();
                //rdr.Read();
                //int userID = (int)rdr["User_ID"];
                //rdr.Close();


            }

            catch (Exception ex)
            {
                Utility.ShowMessage("An Error Occured while adding a user: " + ex);
                return;
            }

            finally
            {
                closeDatabaseConnection();
            }
            //mUsers.Add(tmp);
            displayData();
        }

        private void displayData()
        {
            lstOutput.Items.Clear();
            lstOutput.Items.Add(
                "Name                " +
                "College        " +
                "Major     " +
                "Interest       " +
                "Status         " +
                "Birthday       " +
                "Email                    " +
                "Gender         " +
                "Phone"
            );
            foreach (clsUser tmp in mUsers)
            {
                lstOutput.Items.Add(tmp.ToString());
            }
        }



        private void lstOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOutput.SelectedIndex < 1)
            {
                return;
            }
            clsUser tmp = mUsers[lstOutput.SelectedIndex - 1];
            txtFName.Text = tmp.FName;
            txtLName.Text = tmp.LName;
            txtCollege.Text = tmp.College;
            txtMajor.Text = tmp.Major;
            txtInterest.Text = tmp.Interest;
            txtStatus.Text = tmp.Status;
            dtpBirthday.Value = tmp.Birthday;
            txtPhone.Text = tmp.Phone;
            txtEmail.Text = tmp.Email;
            if (tmp.Gender == "Female")
            {
                rdoFemale.Checked = true;
                rdoMale.Checked = false;
            }
            else
            {
                rdoFemale.Checked = false;
                rdoMale.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            if (lstOutput.SelectedIndex < 1)
            {
                Utility.ShowMessage("Please select a user before clicking Edit User");
                return;
            }
            clsUser tmp = checkedNewUser();

            clsUser tmp2 = (clsUser)mUsers[lstOutput.SelectedIndex - 1];
            if (tmp == null)
                return;

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;

                sql = "UPDATE Users SET FName = " + clsSQL.ToSql(tmp.FName) +
                    ", LName = " + clsSQL.ToSql(tmp.LName) +
                    ", College = " + clsSQL.ToSql(tmp.College) +
                    ", Major = " + clsSQL.ToSql(tmp.Major) +
                    ", PInterest = " + clsSQL.ToSql(tmp.Interest) +
                    ", Status = " + clsSQL.ToSql(tmp.Status) +
                    ", Birthdate = " + clsSQL.ToSql(tmp.Birthday) +
                    ", Phone = " + clsSQL.ToSql(tmp.Phone) +
                    ", Email = " + clsSQL.ToSql(tmp.Email) +
                    ", Gender = " + clsSQL.ToSql(tmp.Gender) +
                    " WHERE User_ID = " + clsSQL.ToSql(tmp2.UserID);
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Utility.ShowMessage("An Error Occured while Editing the DB: " + ex);
            }

            finally
            {
                closeDatabaseConnection();
            }

            loadUsers("SELECT * FROM Users");
            displayData();
        }

        private clsUser checkedNewUser()
        {
            string fname, lname, college, major;
            string interest, status, phone, email;
            DateTime birthdate;
            string gender = "";
            if (!(
                Utility.validateInput(txtFName, out fname) &&
                Utility.validateInput(txtLName, out lname) &&
                Utility.validateInput(txtCollege, out college) &&
                Utility.validateInput(txtMajor, out major) &&
                Utility.validateInput(txtInterest, out interest) &&
                Utility.validateInput(txtStatus, out status) &&
                Utility.validateInput(txtEmail, out email) &&
                Utility.validateInput(txtPhone, out phone)
            ))
            {
                return null;
            }
            birthdate = dtpBirthday.Value;
            phone = txtPhone.Text;
            if (!(rdoMale.Checked || rdoFemale.Checked))
            {
                Utility.ShowMessage("You must select Male or Female");
                return null;
            }

            if (rdoMale.Checked == true)
            {
                gender = "Male";
            }
            else if (rdoFemale.Checked == true)
            {
                gender = "Female";
            }

            clsUser tmp = new clsUser(fname, lname, college, major, interest,
                status, birthdate, phone, email, gender);
            return tmp;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;


            if (lstOutput.SelectedIndex < 1)
            {
                Utility.ShowMessage("Please select a record before deleting");
                return;
            }
            clsUser user = (clsUser)mUsers[lstOutput.SelectedIndex - 1];

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;

                sql = "DELETE FROM Users WHERE User_ID = " + clsSQL.ToSql(user.UserID);

                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Utility.ShowMessage("There was an unexpected error deleting a record: " + ex);
            }
            finally
            {
                closeDatabaseConnection();
            }

            mUsers.RemoveAt(lstOutput.SelectedIndex - 1);


            displayData();
        }

        private void btnLoadDB_Click(object sender, EventArgs e)
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
            loadUsers("SELECT * FROM Users");
            displayData();
        }

    }
}
