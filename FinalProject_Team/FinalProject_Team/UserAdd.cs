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

    // Form written by Tyler Philbrick

    public partial class UserAdd : Form
    {

        private List<clsUser> mUsers = new List<clsUser>();

        public UserAdd()
        {
            InitializeComponent();
            loadExampleData();
            displayData();
        }
        
        private void loadExampleData()
        {
            for (int i = 0; i < 10; i++)
            {
                mUsers.Add(new clsUser("Tyler", "Philbrick", "Technology",
                    "CIT", "Toys", "Student", DateTime.Now, "t5@purdue.edu", false));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsUser tmp = checkedNewUser();
            if (tmp == null)
                return;
            mUsers.Add(tmp);
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
                "Email          " +
                "Gender"
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
            if (tmp.Gender)
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
            if (lstOutput.SelectedIndex < 1)
            {
                Utility.ShowMessage("Please select a user before clicking Edit User");
                return;
            }
            clsUser tmp = checkedNewUser();
            if (tmp == null)
                return;
            mUsers[lstOutput.SelectedIndex - 1] = tmp;
            displayData();
        }

        private clsUser checkedNewUser()
        {
            string fname, lname, college, major;
            string interest, status, phone, email;
            DateTime birthdate;
            bool gender;
            if (!(
                Utility.validateInput(txtFName, out fname) &&
                Utility.validateInput(txtLName, out lname) &&
                Utility.validateInput(txtCollege, out college) &&
                Utility.validateInput(txtMajor, out major) &&
                Utility.validateInput(txtInterest, out interest) &&
                Utility.validateInput(txtStatus, out status) &&
                Utility.validateInput(txtEmail, out email)
            ))
            {
                return null;
            }
            birthdate = dtpBirthday.Value;
            phone = txtPhone.Text;
            if (!(rdoMale.Checked || rdoMale.Checked))
            {
                Utility.ShowMessage("You must select Male or Female");
                return null;
            }
            gender = rdoFemale.Checked;
            clsUser tmp = new clsUser(fname, lname, college, major, interest,
                status, birthdate, email, gender);
            return tmp;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOutput.SelectedIndex < 1)
            {
                Utility.ShowMessage("Please select a record before deleting");
                return;
            }
            mUsers.RemoveAt(lstOutput.SelectedIndex - 1);
            displayData();
        }

    }
}
