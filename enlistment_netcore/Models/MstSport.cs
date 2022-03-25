using System;
using System.Collections.Generic;

#nullable disable

namespace enlistment_netcore.Models
{
    public partial class MstSport
    {
        public int AutoId { get; set; }
        public int? SportId { get; set; }
        public string SportName { get; set; }
    }
}
