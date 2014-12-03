using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FinalProject_Team
{
    public partial class AddJob : Form
    {
        public AddJob()
        {
            InitializeComponent();
        }


        private ArrayList mJobs = new ArrayList();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Variables

            string name;
            string source;
            double weight;
            int durHours;
            int durMins;
            //Printer Selection goes Here
            string colorPref;
            int priority;

            //***VALIDATIONS***
            if (Utility.validateInput(txtJobName,out name) == false || Utility.validateInput(txtJobSource, out source) == false || Utility.validateInput(txtWeight,0,2000,out weight) == false || Utility.validateInput(txtDurHr,-1,30, out durHours) == false || Utility.validateInput(txtColor, out colorPref) == false || Utility.validateInput(txtPriority,0,5, out priority) == false)
            {
                return;
            }


        }
    }
}
