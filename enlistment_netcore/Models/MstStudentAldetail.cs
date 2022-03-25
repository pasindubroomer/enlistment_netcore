using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class MstStudentAldetail
    {
        public int AutoId { get; set; }
        public string NicNo { get; set; }
        public string SchoolName { get; set; }
        public string PassedIndexNo { get; set; }
        public string PassedYear { get; set; }
        public string PassedAttempt { get; set; }
        public string Attemp1IndexNo { get; set; }
        public string Attemp2IndexNo { get; set; }
        public string Attemp3IndexNo { get; set; }
        public string Attemp1Year { get; set; }
        public string Attemp2Year { get; set; }
        public string Attemp3Year { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public string EnglishGrade { get; set; }
        public string GeneralTest { get; set; }
        public string QualifiedForUniversity { get; set; }
        public string Zscore { get; set; }
    }
}
