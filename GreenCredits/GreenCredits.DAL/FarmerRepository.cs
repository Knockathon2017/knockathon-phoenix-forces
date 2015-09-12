using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GreenCredits.DAL
{
    public class FarmerRepository : IFarmerRepository
    {
        private IDbConnection _db;

        public FarmerRepository(string connnectionString)
        {
            _db = new MySqlConnection(connnectionString);
        }
        public List<Farmer> GetAll()
        {
            return this._db.Query<Farmer>("SELECT * FROM farmers").ToList();
        }
    }
}
