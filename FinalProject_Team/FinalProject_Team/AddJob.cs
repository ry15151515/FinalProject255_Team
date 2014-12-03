using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Team
{
    

    public partial class AddJob : Form
    {
        ArrayList mAddJob = new ArrayList();

        public AddJob()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int durHrs;
            int durMin;
            if (txtStudentName.Text == "")
            {
                MessageBox.Show("Please enter a student name.");
                return;
            }
            if(txtJobName.Text == "")
            {
                MessageBox.Show("Please enter a job name.");
                return;
            }
            if (txtJobSource.Text == "")
            {
                MessageBox.Show("Please enter a job source.");
                return;
            }
            if (txtWeight.Text == "")
            {
                MessageBox.Show("Please enter a weight.");
                return;
            }
            if (txtDurHr.Text == "")
            {
                MessageBox.Show("Please enter a duration for hours.");
                return;
            }
            if (int.TryParse(txtDurHr.Text, out durHrs) == false)
            {
                MessageBox.Show("Please enter a number value for hours.");
                return;
            }
            if (txtDurMin.Text == "")
            {
                MessageBox.Show("Please enter a duration for minutes.");
                return;
            }
            if (int.TryParse(txtDurMin.Text, out durMin) == false)
            {
                MessageBox.Show("Please enter a number value for minutes.");
                return;
            }
            if (cmbPrinter.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a printer.");
                return;
            }
            if (txtColor.Text == "")
            {
                MessageBox.Show("Please enter a color.");
                return;
            }
            if (txtPriority.Text == "")
            {
                MessageBox.Show("Please enter a priority.");
                return;
            }
            mAddJob.Add(txtStudentName.Text);
            mAddJob.Add(dateTimePicker1);
            mAddJob.Add(txtJobName.Text);
            mAddJob.Add(txtJobSource.Text);
            mAddJob.Add(txtWeight.Text);
            mAddJob.Add(txtDurHr.Text);
            mAddJob.Add(txtDurMin.Text);
            mAddJob.Add(cmbPrinter);
            mAddJob.Add(txtColor.Text);
            mAddJob.Add(txtPriority.Text);
            clearUserInput();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtJobName.Clear();
            txtJobSource.Clear();
            txtWeight.Clear();
            txtDurHr.Clear();
            txtDurMin.Clear();
            cmbPrinter.SelectedIndex = -1;
            txtColor.Clear();
            txtPriority.Clear();
        }

        private void clearUserInput()
        {
            txtStudentName.Clear();
            txtJobName.Clear();
            txtJobSource.Clear();
            txtWeight.Clear();
            txtDurHr.Clear();
            txtDurMin.Clear();
            cmbPrinter.SelectedIndex = -1;
            txtColor.Clear();
            txtPriority.Clear();
        }
    }
}
