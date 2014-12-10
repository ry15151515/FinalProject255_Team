using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{
    class clsSupply
    {
        public int? ID { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public double Diameter { get; set; }

        public clsSupply()
        {
            ID = null;
            Size = 0;
            Color = "";
            Price = 0;
            Date = DateTime.Now;
            Diameter = 0;
        }

        public clsSupply(
            int id, int size, string color,
            decimal price, DateTime date)
        {
            ID = id;
            Size = size;
            Color = color;
            Price = price;
            Date = date;
            Diameter = 0;
        }

        public clsSupply(
            int size, string color,
            decimal price, DateTime date)
        {
            ID = null;
            Size = size;
            Color = color;
            Price = price;
            Date = date;
            Diameter = 0;
        }

        public clsSupply(OleDbDataReader rdr)
        {
            ID = (int)rdr["Supply_ID"];
            Size = (int)rdr["SpoolSize"];
            Color = (string)rdr["Color"];
            Price = (decimal)rdr["Price"];
            Date = (DateTime)rdr["EntryDate"];
            Diameter = 0;
        }

        public override string ToString()
        {
            return
                Size.ToString().PadRight(18) +
                Color.ToString().PadRight(18) +
                Price.ToString("$0.##").PadRight(18) +
                Date.ToString("yyyy-MM-dd").PadRight(18);
        }


    }
}
