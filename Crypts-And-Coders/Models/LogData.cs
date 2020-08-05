using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class LogData
    {
        public int Id { get; set; }
        public string RequestContentType { get; set; }
        public string RequestContent { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public DateTime? RequestTimestamp { get; set; }
        public string UserName { get; set; }
    }
}
