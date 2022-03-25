using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class SpecialRequirement
    {
        public int Id { get; set; }
        public string DegreeCode { get; set; }
        public string AlminimumCreditPassesCount { get; set; }
        public string AlminimumSimplePassesCount { get; set; }
        public string AlminimumCreditPassesSubjects { get; set; }
        public string AlminimumSimplePassesSubjects { get; set; }
        public string AlcompulsarySubjects { get; set; }
        public string OlminimumCreditPassesCount { get; set; }
        public string OlminimumSimplePassesCount { get; set; }
        public string OlminimumCreditPassesSubjects { get; set; }
        public string OlminimumSimplePassesSubjects { get; set; }

        public virtual Eligibilty DegreeCodeNavigation { get; set; }
    }
}
