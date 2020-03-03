using System.Collections.Generic;
using CustomersBusiness.Models;
using ProtoBuf;

namespace CustomersBusiness.Helpers
{
    [ProtoContract(IgnoreListHandling = true)]
    public class CustomersPagedResult
    {
        [ProtoMember(1)]
        public int TotalResultCount { get; set; }
        [ProtoMember(2)]
        public List<CustomerDTO> data { get; set; }
    }
}
