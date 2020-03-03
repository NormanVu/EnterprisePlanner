using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Entities
{
    public class Endpoint
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string DNSName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
