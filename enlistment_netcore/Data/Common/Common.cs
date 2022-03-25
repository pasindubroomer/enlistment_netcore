using enlistment_netcore.Data.Interfaces;
using enlistment_netcore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace enlistment_netcore.Data.Common
{
    public class Common : ICommon
    {
        private readonly EnlistmentDBContext _enlistmentDBContext;
        private readonly IEnlistment _iEnlistment;

        public Common(EnlistmentDBContext enlistmentContext, IEnlistment iEnlistment)
        {
            _enlistmentDBContext = enlistmentContext;
            _iEnlistment = iEnlistment;
        }

        public int GetMinimumAge()
        {
            return _enlistmentDBContext.Eligibilties.Min(x => x.MinimumAge);
        }

        public int GetMaximumAge()
        {
            return _enlistmentDBContext.Eligibilties.Max(x => x.MaximumAge);
        }

        public bool ValidateNIC(String nicno)
        {

            String birthDay = "";
            #region getAgetFromNIC
            int dayText = 0;
            string year = "";
            string month = "";
            int day = 0;
            string gender = "";

            if (nicno.Length == 10)
            {
                year = "19" + nicno.Substring(0, 2);
                dayText = int.Parse(nicno.Substring(2, 3));
            }
            else
            {
                year = nicno.Substring(0, 4);
                dayText = int.Parse(nicno.Substring(4, 3));
            }

            // Gender
            if (dayText > 500)
            {
                gender = "Female";
                dayText = dayText - 500;
            }
            else
            {
                gender = "Male";
            }

            Task.Delay(5000);
            // Day Digit Validation
            if (dayText < 1 && dayText > 366)
            {
            }
            else
            {
                //Month
                if (dayText > 335)
                {
                    day = dayText - 335;
                    month = "12";
                }
                else if (dayText > 305)
                {
                    day = dayText - 305;
                    month = "11";
                }
                else if (dayText > 274)
                {
                    day = dayText - 274;
                    month = "10";
                }
                else if (dayText > 244)
                {
                    day = dayText - 244;
                    month = "09";
                }
                else if (dayText > 213)
                {
                    day = dayText - 213;
                    month = "08";
                }
                else if (dayText > 182)
                {
                    day = dayText - 182;
                    month = "07";
                }
                else if (dayText > 152)
                {
                    day = dayText - 152;
                    month = "06";
                }
                else if (dayText > 121)
                {
                    day = dayText - 121;
                    month = "05";
                }
                else if (dayText > 91)
                {
                    day = dayText - 91;
                    month = "04";
                }
                else if (dayText > 60)
                {
                    day = dayText - 60;
                    month = "03";
                }
                else if (dayText < 32)
                {
                    month = "01";
                    day = dayText;
                }
                else if (dayText > 31)
                {
                    day = dayText - 31;
                    month = "02";
                }
            }
            #endregion

            birthDay = year + "-" + month + "-" + day;

            DateTime birthDayDateObject = DateTime.ParseExact(birthDay, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            DateTime AgeCalculationDate = _iEnlistment.GetAgeCalculationDate();

            int birthDayMinimum = GetMinimumAge();

            int birthDayMaximum = GetMaximumAge();

            DateTime minimumDate = AgeCalculationDate.AddYears(-birthDayMinimum);

            DateTime maximumDate = AgeCalculationDate.AddYears(-birthDayMaximum);


            if (birthDayDateObject >= maximumDate && birthDayDateObject <= minimumDate)
            {
                return true;
            }

            return false;
        }


        public List<MstSport> GetSports()
        {
            return _enlistmentDBContext.MstSports.OrderBy(x=>x.AutoId).ToList();
        }
    }
}
