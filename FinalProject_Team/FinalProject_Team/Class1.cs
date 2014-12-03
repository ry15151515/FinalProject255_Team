using System;



public class clsAddjob
{
    //List of data members
    private int mID;
    private string mStudentName;
    private DateTime mDate;
    private string mJobName;
    private string mJobSource;
    private double mWeight;
    private int mDurHours;
    private int mDurMinutes;
    private string mPrinter;
    private string mColor;
    private string mPriority;

    //Class Constructors

    public clsAddjob()
    {
        mID = 0;
        mStudentName = "";
        mDate = DateTime.Now;
        mJobName = "";
        mJobSource = "";
        mWeight = 0.0;
        mDurHours = 0;
        mDurMinutes = 0;
        mPrinter = "";
        mColor = "";
        mPriority = "";
    }

    public clsAddjob(int iD, string studentName, DateTime myDate, string jobName, string jobSource, double weight, int durHours, int durMinutes,
        string printer, string color, string priority)
    {
        mID = iD;
        mStudentName = studentName;
        mDate = myDate;
        mJobName = jobName;
        mJobSource = jobSource;
        mWeight = weight;
        mDurHours = durHours;
        mDurMinutes = durMinutes;
        mPrinter = printer;
        mColor = color;
        mPriority = priority;
    }

    //---------Accessor Methods---------

    public int ID
    {
        get
        {
            return mID;
        }
        set
        {
            mID = value;
        }
    }
    public string StudentName
    {
        get
        {
            return mStudentName;
        }
        set
        {
            mStudentName = value;
        }
    }
    public DateTime Date
    {
        get
        {
            return mDate;
        }
        set
        {
            mDate = value;
        }
    }
    public string JobName
    {
        get
        {
            return mJobName;
        }
        set
        {
            mJobName = value;
        }
    }
    public string JobSource
    {
        get
        {
            return mJobSource;
        }
        set
        {
            mJobSource = value;
        }
    }
    public double Weight
    {
        get
        {
            return mWeight;
        }
        set
        {
            mWeight = value;
        }
    }
    public int DurHours
    {
        get
        {
            return mDurHours;
        }
        set
        {
            mDurHours = value;
        }
    }
    public int DurMinutes
    {
        get
        {
            return mDurMinutes;
        }
        set
        {
            mDurMinutes = value;
        }
    }
    public string Printer
    {
        get 
        {
            return mPrinter;
        }
        set
        {
            mPrinter = value;
        }
    }
    public string Color
    {
        get
        {
            return mColor;
        }
        set
        {
            mColor = value;
        }
    }
    public string Priority
    {
        get
        {
            return mPriority;
        }
        set
        {
            mPriority = value;
        }
    }
    //------End of Accessor Method------


}