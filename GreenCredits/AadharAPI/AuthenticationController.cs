using GreenCredits.DAL;
using StructureMap;
using System.Collections.Generic;
using System.Web.Http;

namespace GreenCredits.API
{
    public class AuthenticationController :ApiController
    {
        // GET api/authentication 
        public IEnumerable<Farmer> Get()
        {
            return ObjectFactory.GetInstance<IFarmerRepository>().GetAll();
        }
        // POST api/authentication 
        public void Post([FromBody]string value)
        {
        } 
    }
}
