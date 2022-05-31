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

        [EmailAddress]
        public String Email { get; set; }

        [Phone]
        public String Phone { get; set; }

        public bool IsConfirmed { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        [ForeignKey("LocalGovtArea")]
        public int LocalGovtId { get; set; }
        public LocalGovtArea LGA { get; set; }

    }
}
