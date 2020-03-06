using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace CustomersBusiness.Models
{
    [ProtoContract]
    [ProtoInclude(101, typeof(CustomerDTO))]
    public abstract class CustomerBaseDTO
    {
        [ProtoMember(2)]
        [Required]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Required]
        public string Address { get; set; }
        [ProtoMember(4)]
        [Required]
        public string Business { get; set; }
    }
}
