using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{

    // Class written by Tyler Philbrick for UserAdd form

    public class clsUser
    {

        public clsUser()
        {
            
            FName = "";
            LName = "";
            College = "";
            Major = "";
            Interest = "";
            Status = "";
            Phone = "";
            Birthday = DateTime.Now;
            Email = "";
            Gender = "";
        }

        public clsUser(string fname, string lname, string college,
            string major, string interest, string status, DateTime birthday,string phone,
            string email, string gender)
        {
            FName = fname;
            LName = lname;
            College = college;
            Major = major;
            Interest = interest;
            Status = status;
            Birthday = birthday;
            Phone = phone;
            Email = email;
            Gender = gender;
        }

        public clsUser(int userID, string fname, string lname, string college,
    string major, string interest, string status, DateTime birthday, string phone,
    string email, string gender)
        {
            UserID = userID;
            FName = fname;
            LName = lname;
            College = college;
            Major = major;
            Interest = interest;
            Status = status;
            Birthday = birthday;
            Phone = phone;
            Email = email;
            Gender = gender;
        }

        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName
        {
            get
            {
                return this.FName + " " + this.LName;
            }
        }
        public string College { get; set; }
        public string Major { get; set; }
        public string Interest { get; set; }
        public string Status { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // true represents Female, false represents Male
        public string Gender { get; set; }


        public override string ToString()
        {
            return this.FullName.PadRight(20) +
                this.College.PadRight(15) +
                this.Major.PadRight(10) +
                this.Interest.PadRight(15) +
                this.Status.PadRight(15) +
                this.Birthday.ToString("yyyy-MM-dd").PadRight(15) +
                this.Email.PadRight(25) +
                this.Gender.PadRight(10) +
                this.Phone.PadRight(15);
        }
    }
}
