using enlistment_netcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enlistment_netcore.Data.Interfaces
{
    public interface ICommon
    {
        public int GetMinimumAge();
        public int GetMaximumAge();
        public bool ValidateNIC(String nicno);
        List<MstSport> GetSports();
    }
}
