using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class MstStudentPersonalDetail
    {
        public string NicNo { get; set; }
        public string FullName { get; set; }
        public string NameWithInitial { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PassportNo { get; set; }
        public string CivilStatus { get; set; }
        public string TelResidence { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string Citizenship { get; set; }
        public string EmailAddress { get; set; }
        public string Religion { get; set; }
    }
}
