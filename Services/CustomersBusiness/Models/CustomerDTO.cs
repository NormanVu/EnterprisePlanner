using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace CustomersBusiness.Models
{
    [ProtoContract]
    public class CustomerDTO : CustomerBaseDTO
    {
        [ProtoMember(1)]
        [Required]
        public int Id { get; set; }
    }
}
