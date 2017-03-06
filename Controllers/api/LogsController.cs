using System.Collections.Generic;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Pi3CoreApi.Models;

namespace Pi3CoreApi.Controllers
{
    [Route("api/logs")]
    public class LogsController : Controller
    {
        readonly LiteDB.LiteDatabase _db;

        public LogsController(LiteDB.LiteDatabase db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<RequestLogItem> Get(int offset = 0, int limit = 20)
        {
            var logs = _db.GetCollection<RequestLogItem>("RequestLogs");
            return logs.Find(Query.All("Timestamp", Query.Descending), offset, limit);
        }
    }
}