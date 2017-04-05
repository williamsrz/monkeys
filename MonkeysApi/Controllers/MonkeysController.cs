using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using MonkeysApi.DataObjects;
using MonkeysApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeysApi.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 
    [MobileAppController]
    public class MonkeysController : ApiController
    {
        private readonly MobileServiceContext context = new MobileServiceContext();
        
        // GET api/monkeys
        public IHttpActionResult Post(Developer developer)
        {
            if (developer == null) return BadRequest();

            context.Developers.Add(developer);

            var monkeys = context.Monkeys.ToList();

            return  Ok(monkeys);

        }
    }
}
