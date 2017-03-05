using System.Collections.Generic;
using LiteDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pi3CoreApi.Models;

namespace Pi3CoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        readonly LiteDB.LiteDatabase _db;

        public ValuesController(LiteDB.LiteDatabase db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<RequestLogItem> Get()
        {
            var logs = _db.GetCollection<RequestLogItem>("RequestLogs");
            return logs.FindAll();
            //return new List<string>() { "open" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
