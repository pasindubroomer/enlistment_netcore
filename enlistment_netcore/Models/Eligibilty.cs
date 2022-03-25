using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class Eligibilty
    {
        public Eligibilty()
        {
            SpecialRequirements = new HashSet<SpecialRequirement>();
        }

        public int Id { get; set; }
        public string DegreeCode { get; set; }
        public string DegreeName { get; set; }
        public string Stream { get; set; }
        public int Duration { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public int Citizenship { get; set; }
        public int AlminimumSpasses { get; set; }
        public string Alyear { get; set; }
        public double CommonGeneralMarks { get; set; }
        public string StudentType { get; set; }
        public string OlmathsMinPass { get; set; }
        public string OlscienceMinPass { get; set; }
        public string OlsinhalaMinPass { get; set; }
        public string Gender { get; set; }
        public int? SpecialRequirement { get; set; }
        public int? PaymentBasis { get; set; }

        public virtual ICollection<SpecialRequirement> SpecialRequirements { get; set; }
    }
}
