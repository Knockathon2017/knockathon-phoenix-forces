using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCredits.DAL
{
    public class CarbonAsset
    {
        public long Id { get; set; }
        public string address { get; set; }
        public long farmerid { get; set; }
        public int activetreecount { get; set; }
        public long traderid { get; set; }
        public int passivetreecount { get; set; }
        public string companyname { get; set; }
    }
}
