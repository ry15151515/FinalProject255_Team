using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{

    class clsMaintenance
    {
        int maintenanceID;

        public int MaintenanceID
        {
            get { return maintenanceID; }
            set { maintenanceID = value; }
        }
        string printer;
        int printerID;


        public int PrinterID
        {
            get { return printerID; }
            set { printerID = value; }
        }

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

        public clsMaintenance(string myPrinter, int myPrinterID, DateTime myDateTime, string myCategory, string myDetails)
        {
            printer = myPrinter;
            printerID = myPrinterID;
            dateTime = myDateTime;
            cateogory = myCategory;
            details = myDetails;
        }

        public clsMaintenance(int myMainID, string myPrinter, int myPrinterID, DateTime myDateTime, string myCategory, string myDetails)
        {
            maintenanceID = myMainID;
            printer = myPrinter;
            printerID = myPrinterID;
            dateTime = myDateTime;
            cateogory = myCategory;
            details = myDetails;
        }


    }
}


/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{

    class clsMaintenance
    {
        string printer;
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
}*/
