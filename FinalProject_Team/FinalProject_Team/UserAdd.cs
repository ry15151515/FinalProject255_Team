using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Team
{
    public partial class UserAdd : Form
    {
        public UserAdd()
        {
            InitializeComponent();
        }


        //Not Sure if Needed...

        //Class Scopes
        private ArrayList mStudents = new ArrayList();
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = "";
            string lastName = "";
            string college = "";
            string major = "";
            string pInterest = "";
            string status = "";
            DateTime birthdate;
            string phone = "";
            string email = "";
            string gender = "";

            //Min-Max DateTime's
            DateTime maxDate = DateTime.Now;
            DateTime minDate = new DateTime(1900,1,1);

            //Assigns DateTimePicker to TextBox to be validated 
            txtbirthdate.Text = dateBirthdate.Value.ToShortDateString();

            //========VALIDATIONS==========
                //First Name
            if (Utility.validateInput(txtfirstName,out firstName) == false)
            {
                return;
            }
                //Last Name
            if (Utility.validateInput(txtlastName, out lastName) == false)
            {
                return;
            }
                //College
            if (Utility.validateInput(txtcollege, out college) == false)
            {
                return;
            }
                //Major
            if (Utility.validateInput(txtmajor, out major) == false)
            {
                return;
            }
                //Primary Interest
            if (Utility.validateInput(txtprimaryInterest, out pInterest) == false)
            {
                return;
            }
                //Status
            if (Utility.validateInput(txtstatus, out status) == false)
            {
                return;
            }
                //Birthdate
            if (Utility.validateInput(txtbirthdate,(DateTime) minDate,(DateTime)maxDate,out birthdate) == false)
            {
                return;
            }
                //Phone Number
            if (Utility.validateInput(txtphone,out phone) == false)
            {
                return;
            }
                //E-mail
            if (Utility.validateInput(txtemail,out email) == false)
            {
                return;
            }

            //Radio Buttons
            if (rdbMale.Checked == false && rdbFemale.Checked == false)
            {
                Utility.ShowMessage("Please Select Your Gender");
                return;
            }
            if (rdbMale.Checked == true)
            {
                gender = "Male";
            }
            if (rdbFemale.Checked == true)
            {
                gender = "Female";
            }
            //********END VALIDATION************



            //***Add Student to ArrayList***
            clsUserInfo temp = new clsUserInfo(firstName, lastName, college, major, pInterest, status, birthdate, phone, email,gender);
            mStudents.Add(temp);



            eraseInputFields();
            Utility.ShowMessage("User " + firstName + " " + lastName + " Successfully Added!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdbMale_Click(object sender, EventArgs e)
        {
            rdbFemale.Checked = false;
        }

        private void rdbFemale_Click(object sender, EventArgs e)
        {
            rdbMale.Checked = false;
        }

        private void eraseInputFields()
        {
            txtfirstName.Text = "";
            txtlastName.Text = "";
            txtcollege.Text = "";
            txtmajor.Text = "";
            txtprimaryInterest.Text = "";
            txtstatus.Text = "";
            dateBirthdate.ResetText();
            txtphone.Text = "";
            txtemail.Text = "";
            rdbFemale.Checked = false;
            rdbMale.Checked = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
