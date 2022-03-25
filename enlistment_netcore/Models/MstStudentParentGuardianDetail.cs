using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class MstStudentParentGuardianDetail
    {
        public int AutoId { get; set; }
        public string NicNo { get; set; }
        public string FatherFullName { get; set; }
        public string FatherAddress { get; set; }
        public string FatherResidenceTel { get; set; }
        public string FatherMobileNo { get; set; }
        public string FatherPresentEmployment { get; set; }
        public string FatherPreviousEmployment { get; set; }
        public string MotherFullName { get; set; }
        public string MotherAddress { get; set; }
        public string MotherResidenceTel { get; set; }
        public string MotherMobileNo { get; set; }
        public string MotherPresentEmployment { get; set; }
        public string MotherPreviousEmployment { get; set; }
        public string GuardianFullName { get; set; }
        public string GuardianRelationship { get; set; }
        public string GuardianAddress { get; set; }
        public string GuardianResidenceTel { get; set; }
        public string GuardianMobileNo { get; set; }
        public string ForceType { get; set; }
    }
}
