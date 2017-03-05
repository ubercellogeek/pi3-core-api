using System;


namespace Pi3CoreApi.Models
{
    public class RequestLogItem
    {
        public string RequestMethod { get; set; }
        public string RequestPath { get; set; }
        public int? StatusCode { get; set; }
        public string Elapsed { get; set; }
        public string RequestID { get; set; }
        public DateTime Timestamp { get; set; }

    }
}