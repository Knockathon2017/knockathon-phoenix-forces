using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCredits.DAL
{
    public class Traders
    {
        public long id { get; set; }
        public string address { get; set; }
        public string companyname { get; set; }
        public string place { get; set; }
        public string zip { get; set; }
        public string sector { get; set; }
        public string product { get; set; }
        public string website { get; set; }
        public string region { get; set; } 
    }
}
