using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Onboarding.Models
{
    
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        
        public String Email { get; set; }
        [Required]
        [Phone]
        public String Phone { get; set; }
        [Required]
        public bool IsConfirmed { get; set; } = false;
        [ForeignKey("State")]
        [Required]
        public int StateId { get; set; }
        [Required]
        [ForeignKey("LocalGovtArea")]
        
        public int LocalGovtId { get; set; }
        [Required]
        [StringLength(18)]
        public string Password { get; set; }
        public LocalGovtArea LGA { get; set; }

    }
}
