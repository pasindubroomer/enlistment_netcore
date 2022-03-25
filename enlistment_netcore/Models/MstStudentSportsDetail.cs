using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class MstStudentSportsDetail
    {
        public int AutoId { get; set; }
        public string NicNo { get; set; }
        public int? SportId { get; set; }
        public string SportName { get; set; }
        public string Sl { get; set; }
        public string Sc { get; set; }
        public string Zl { get; set; }
        public string Dl { get; set; }
        public string Pl { get; set; }
        public string Pnl { get; set; }
        public string PlinNl { get; set; }
        public string Nc { get; set; }
        public string RslofO { get; set; }
    }
}
