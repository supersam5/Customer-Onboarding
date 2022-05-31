using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Onboarding
{
    public class StatesAndLgas
    {
        public string state { get; set; }

        public string alias { get; set; }

        public List<string> lgas { get; set; }
    }
}
