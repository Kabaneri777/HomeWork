using System.ComponentModel.DataAnnotations;

namespace HomeWork.Models
{
    public class IdentityInfo
    {
        [Key]
        public int SerialId { get; set; }
        public required string UserName { get; set; }
        public required string IdentityCode { get; set; }
    }
}
