using System;

namespace FinalProject_Team
{
    class clsUserInfo
    {
        //Class Data Members
        private string mFirstName;
        private string mLastName;
        private string mCollege;
        private string mMajor;
        private string mPInterest;
        private string mStatus;
        private DateTime mBirthdate;
        private string mPhone;
        private string mEmail;
        private string mGender;

        //Class Constructor

        public clsUserInfo()
        {
            mFirstName = "";
            mLastName = "";
            mCollege = "";
            mMajor = "";
            mPInterest = "";
            mStatus = "";
            mBirthdate = new DateTime(12,31,9999);
            mPhone = "";
            mEmail = "";
            mGender = "";
        }

        public clsUserInfo(string myFirstName,string myLastName,string myCollege,string myMajor,string myPInterest,string myStatus,DateTime myBirthdate,string myPhone,string myEmail,string myGender)
        {
            mFirstName = myFirstName;
            mLastName = myLastName;
            mCollege = myCollege;
            mMajor = myMajor;
            mPInterest = myPInterest;
            mStatus = myStatus;
            mBirthdate = myBirthdate;
            mPhone = myPhone;
            mEmail = myEmail;
            mGender = myGender;
        }


        //Getter-Setter

        public string FirstName
        {
            get 
            {
                return mFirstName;
            }

            set
            {
                mFirstName = value;
            }
        }

        public string LastName
        {
            get 
            {
                return mLastName;
            }

            set
            {
                mLastName = value;
            }
        }

        public string College
        {
            get 
            {
                return mCollege;
            }

            set
            {
                mCollege = value;
            }
        }

        public string Major
        {
            get 
            {
                return mMajor;
            }

            set
            {
                mMajor = value;
            }
        }
        public string PInterest
        {
            get 
            {
                return mPInterest;
            }

            set
            {
                mPInterest = value;
            }
        }
        public string Status
        {
            get 
            {
                return mStatus;
            }

            set
            {
                mStatus = value;
            }
        }
        public DateTime Birthdate
        {
            get 
            {
                return mBirthdate;
            }

            set
            {
                mBirthdate = value;
            }
        }
        public string Phone
        {
            get 
            {
                return mPhone;
            }

            set
            {
                mPhone = value;
            }
        }
        public string Email
        {
            get 
            {
                return Email;
            }

            set
            {
                Email = value;
            }
        }
        public string Gender
        {
            get
            {
                return Gender;
            }
            set
            {
                Gender = value;
            }
        }
    }


}
