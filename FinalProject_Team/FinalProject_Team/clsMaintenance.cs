using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{

    class clsMaintenance
    {
        string printer;
        string test;
        public string Printer
        {
            get { return printer; }
            set { printer = value; }
        }
        DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        string cateogory;

        public string Cateogory
        {
            get { return cateogory; }
            set { cateogory = value; }
        }
        string details;

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public clsMaintenance()
        {
            printer = "";
            dateTime = DateTime.Now;
            cateogory = "";
            details = "";
        }

        public clsMaintenance(string myPrinter, DateTime myDateTime, string myCategory, string myDetails)
        {
            printer = myPrinter;
            dateTime = myDateTime;
            cateogory = myCategory;
            details = myDetails;
        }


    }
}
