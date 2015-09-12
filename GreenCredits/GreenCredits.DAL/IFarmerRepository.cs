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
        //Employee Find(int? id);
        //Employee Add(Employee employee);
        //Employee Update(Employee employee);
        //void Remove(int id);
    }
}
