using Microsoft.AspNetCore.Http;    
using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;
using Pi3CoreApi.Models;
using Microsoft.AspNetCore.Hosting;
using LiteDB;

namespace Pi3CoreApi.Middleware 
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate _next;
        readonly IHostingEnvironment _hostingEnvironment;
        readonly LiteDB.LiteDatabase _db;
        private string _dbPath;

        public LoggingMiddleware(RequestDelegate next, LiteDB.LiteDatabase db)
        {
            _db = db;
            if (next == null) throw new ArgumentNullException(nameof(next));
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await _next(httpContext);
                sw.Stop();
            }
            // Never caught, because `LogException()` returns false.
            catch (Exception) 
            {
                sw.Stop();
            }
            finally
            {
                var item = new RequestLogItem();
                item.RequestMethod = httpContext.Request.Method;
                item.RequestPath = httpContext.Request.Path;
                item.StatusCode = httpContext.Response?.StatusCode;
                item.Elapsed = sw.Elapsed.ToString();
                item.RequestID = httpContext.TraceIdentifier;
                
                var logs = _db.GetCollection<RequestLogItem>("RequestLogs");
                logs.Insert(item);
                
            }
        }

    }
}