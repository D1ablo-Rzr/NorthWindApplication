using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Customer
    {
        public string CustomerId { get; set; }

        public string CompanyName { get; set; } 
        public string CustomerName { get; set; } 
        public string CustomerTitle { get; set; } 
        public string Address { get; set; }

    }
}
