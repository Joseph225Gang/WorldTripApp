using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public partial class Member
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [StringLength(10)]
        public string MobilePhone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        public string PassWord { get; set; }
    }
}
