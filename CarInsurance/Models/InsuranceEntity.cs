using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsurance.Models
{
    public class InsuranceEntity
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set;  }
        public string CarModel { get; set; }
        public bool DUI { get; set; } 
        public int SpeedingTickets { get; set; }
        public bool CoverageType { get; set; } 
        public decimal Qoute { get; set;  }    
        
    }
} 