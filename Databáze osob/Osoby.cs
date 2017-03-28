using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databáze_osob
{
  public  class Osoby
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string LifeNumber { get; set; }
            public DateTime Date { get; set; }
            public string Sex { get; set; }
            public string DateOfUpdate { get; set; }
            public int Done { get; set; }
            
            public override string ToString()
            {
                return "ID" + ID + " Name " + FirstName + " LastName " + LastName + " LifeNumber " + LifeNumber + " Sex: " + Sex;
            }

       
    }
}
