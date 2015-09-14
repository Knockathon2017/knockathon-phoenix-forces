using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCredits.DAL
{
    public interface IFarmerRepository
    {
        List<Farmer> GetAll();
        Farmer Add(Farmer farmer);
        List<CarbonAsset> GetByFramerId(long? fid);
        Farmer Find(string email);
        Farmer FindById(long id);
        List<Traders> GetTraders();
    }
}
