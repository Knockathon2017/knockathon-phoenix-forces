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
        //Employee Find(int? id);
        //Employee Add(Employee employee);
        //Employee Update(Employee employee);
        //void Remove(int id);
    }
}
