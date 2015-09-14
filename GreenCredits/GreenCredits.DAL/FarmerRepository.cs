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
            _db.Open();
        }
        public List<Farmer> GetAll()
        {
            return this._db.Query<Farmer>("SELECT * FROM farmers").ToList();
        }


        public Farmer Add(Farmer farmer)
        {
            var sqlQuery = "INSERT INTO farmers (email) VALUES('"+farmer.email+"'); " + " SELECT LAST_INSERT_ID() ";
            var id = this._db.Query<int>(sqlQuery, farmer).Single();
            farmer.id = id;
            return farmer;
        }

        public Farmer Find(string email)
        {
            string query = "SELECT * FROM farmers WHERE email = '" + email + "'";
            return this._db.Query<Farmer>(query).SingleOrDefault();
        }

        public Farmer FindById(long id)
        {
            string query = "SELECT * FROM farmers WHERE id = '" + id + "'";
            return this._db.Query<Farmer>(query).SingleOrDefault();
        }


        public List<CarbonAsset> GetByFramerId(long? fid)
        {
            string query = "SELECT * ,( select address from traders where id = traderid) as companyname , 0 as isActive  FROM carbonasset WHERE farmerid =" + fid;
            return this._db.Query<CarbonAsset>(query).ToList();
        }


        public List<Traders> GetTraders()
        {
            string query = "SELECT * FROM traders WHERE website <> ''";
            return this._db.Query<Traders>(query).ToList();
        }
    }
}
