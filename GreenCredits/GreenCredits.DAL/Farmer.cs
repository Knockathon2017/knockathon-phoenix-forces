using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenCredits.DAL
{
    public class Farmer
    {
        public long id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string Specialization { get; set; }
        public string Affiliation { get; set; }
        public string PAddress { get; set; }
        public string PState { get; set; }
        public string PDistrict { get; set; }
        public string PBlock { get; set; }
        public string PVill { get; set; }
        public string email { get; set; }

        public string Password { get; set; }
    }
}
