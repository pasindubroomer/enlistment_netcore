using enlistment_netcore.Data;
using enlistment_netcore.Data.Interfaces;
using enlistment_netcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KDUEnlistment.Data
{
    public class EnlistmentDBSql : IEnlistment
    {
        private readonly EnlistmentDBContext _enlistmentDBContext;

        public EnlistmentDBSql(EnlistmentDBContext enlistmentContext)
        {
            _enlistmentDBContext = enlistmentContext;
        }

        public DateTime GetAgeCalculationDate()
        {
            return _enlistmentDBContext.MstAgeCalculateDates.Take(1).Select(x => x.Date).FirstOrDefault();
        }

        public List<MstAlsubject> GetAlsubjectsByStream(string stream)
        {
            return _enlistmentDBContext.MstAlsubjects.Where(x => x.Alstream == stream).ToList();
        }

        public bool ValidateNIC(string nicno)
        {
            throw new System.NotImplementedException();
        }


        public bool AddPersonalDetails(String full_name, String name_with_initial, String permanent_address, String nic_no,string email, String date_of_birth, String passport_no, String civil_status, String tel_residence, String gender, String mobile_no, String citizenship, String religion)
        {
            try
            {
                MstStudentPersonalDetail personalDet = new MstStudentPersonalDetail
                {
                    FullName = full_name,
                    NameWithInitial = name_with_initial,
                    PermanentAddress = permanent_address,
                    NicNo = nic_no,
                    DateOfBirth = DateTime.Parse(date_of_birth),
                    PassportNo = passport_no,
                    CivilStatus = civil_status,
                    TelResidence = tel_residence,
                    Gender = gender,
                    MobileNo = mobile_no,
                    Citizenship = citizenship,
                    Religion = religion,
                    EmailAddress = email
                };
                _enlistmentDBContext.MstStudentPersonalDetails.Add(personalDet);
                _enlistmentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddOLDetails(String school_name,String nic_no, String index_no, String ol_year, String subject1, string subject2, String subject3, String subject4, String subject5, String subject6, String subject7, String subject8, String subject9, String subject1_grade, String subject2_grade, String subject3_grade, String subject4_grade, String subject5_grade, String subject6_grade, String subject7_grade, String subject8_grade, String subject9_grade)
        {
            try
            {
                MstStudentOldetail olDet = new MstStudentOldetail
                {
                    SchoolName = school_name,
                    IndexNo = index_no,
                    Year = ol_year,
                    NicNo = nic_no,
                    Subject1 = subject1,
                    Subject2 = subject2,
                    Subject3 = subject3,
                    Subject4 = subject4,
                    Subject5 = subject5,
                    Subject6 = subject6,
                    Subject7 = subject7,
                    Subject8 = subject8,
                    Subject9 = subject9,
                    Subject1Grade = subject1_grade,
                    Subject2Grade = subject2_grade,
                    Subject3Grade = subject3_grade,
                    Subject4Grade = subject4_grade,
                    Subject5Grade = subject5_grade,
                    Subject6Grade = subject6_grade,
                    Subject7Grade = subject7_grade,
                    Subject8Grade = subject8_grade,
                    Subject9Grade = subject9_grade
                };

                _enlistmentDBContext.MstStudentOldetails.Add(olDet);
                _enlistmentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddALDetails(String al_school_name,String NicNo, String passed_al_index_no, String passed_al_year, String passed_al_attempt, String attempt_1st_index_no, string attempt_1st_year, String attempt_2nd_index_no, String attempt_2nd_year, String attempt_3rd_index_no, String attempt_3rd_year, String al_subject1, String al_subject1_grade, String al_subject2, String al_subject2_grade, String al_subject3, String al_subject3_grade, String al_english_grade, String al_general_test, String qualified_for_university, String z_score)
        {
            try
            {
                MstStudentAldetail alDet = new MstStudentAldetail
                {
                    SchoolName = al_school_name,
                    NicNo = NicNo,
                    PassedIndexNo = passed_al_index_no,
                    PassedYear = passed_al_year,
                    PassedAttempt = passed_al_attempt,
                    Attemp1IndexNo = attempt_1st_index_no,
                    Attemp2IndexNo = attempt_2nd_index_no,
                    Attemp3IndexNo = attempt_3rd_index_no,

                    Attemp1Year = attempt_1st_year,
                    Attemp2Year = attempt_2nd_year,
                    Attemp3Year = attempt_3rd_year,

                    Subject1 = al_subject1,
                    Subject2 = al_subject2,
                    Subject3 = al_subject3,

                    Subject1Grade = al_subject1_grade,
                    Subject2Grade = al_subject2_grade,
                    Subject3Grade = al_subject3_grade,

                    EnglishGrade = al_english_grade,

                    GeneralTest = al_general_test,
                    QualifiedForUniversity = qualified_for_university,
                    Zscore = z_score
                };

                _enlistmentDBContext.MstStudentAldetails.Add(alDet);
                _enlistmentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddCadetScoutingDetails(String juo,String NicNo, String suo, String pte, String lcpl, String cpl, String sgt, String pres_scouts, String cc_dc_awards, String scouts_award, String scouts, String cub_scout_with_star, String cadeting, String scouting, String prefect, String school_captain, String house_captain, String band, String societies, String first_aid)
        {
            try
            {
                MstStudentCadetScoutingDetail cadetScoutingDet = new MstStudentCadetScoutingDetail
                {
                    Juo = juo,
                    NicNo = NicNo,
                    Suo = suo,
                    Pte = pte,
                    Lcpl = lcpl,
                    Cpl = cpl,
                    Sgt = sgt,
                    PresScouts = pres_scouts,
                    CcCcAwards = cc_dc_awards,
                    ScoutsAward = scouts_award,
                    Scouts = scouts,
                    CubScoutWithStar = cub_scout_with_star,
                    Cadeting = cadeting,
                    Scouting = scouting,
                    Prefect = prefect,
                    SchoolCaptain = school_captain,
                    HouseCaptain = house_captain,
                    Band = band,
                    Societies = societies,
                    FirstAid = first_aid
                };

                _enlistmentDBContext.MstStudentCadetScoutingDetails.Add(cadetScoutingDet);
                _enlistmentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddSportsDetails(String sports_name, String NicNo ,String sport_id, String sl, String sc, String zl, String dl, String pl, String pnl, String pl_in_nl, String nc, String rsl_of_o)
        {
            try
            {
                MstStudentSportsDetail sportDet = new MstStudentSportsDetail
                {
                    SportId = int.Parse(sport_id),
                    NicNo = NicNo,
                    SportName = sports_name,
                    Sl = sl,
                    Sc = sc,
                    Zl = zl,
                    Dl = dl,
                    Pl = pl,
                    Pnl = pnl,
                    PlinNl = pl_in_nl,
                    Nc = nc,
                    RslofO = rsl_of_o
                };

                _enlistmentDBContext.MstStudentSportsDetails.Add(sportDet);
                _enlistmentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddParentGuardianDetails(String NicNo, String father_full_name, String father_permanent_address, String father_tel_no_residence, String father_tel_no_mobile, String father_present_employment, String father_previous_employment, String mother_full_name, String mother_permanent_address, String mother_tel_no_residence, String mother_tel_no_mobile, String mother_present_employment, String mother_previous_employment, String guardian_full_name, String guardian_relationship, String guardian_permanent_address, String guardian_tel_no_residence, String guardian_tel_no_mobile,String forces_type)
        {
            try
            {
                MstStudentParentGuardianDetail parentDet = new MstStudentParentGuardianDetail
                {
                    NicNo = NicNo,
                    FatherFullName = father_full_name,
                    FatherAddress = father_permanent_address,
                    FatherResidenceTel = father_tel_no_residence,
                    FatherMobileNo = father_tel_no_mobile,
                    FatherPresentEmployment = father_present_employment,
                    FatherPreviousEmployment = father_previous_employment,
                    MotherFullName = mother_full_name,
                    MotherAddress = mother_permanent_address,
                    MotherResidenceTel = mother_tel_no_residence,
                    MotherMobileNo = mother_tel_no_mobile,
                    MotherPresentEmployment = mother_present_employment,
                    MotherPreviousEmployment = mother_previous_employment,
                    GuardianFullName = guardian_full_name,
                    GuardianAddress = guardian_permanent_address,
                    GuardianResidenceTel = guardian_tel_no_residence,
                    GuardianMobileNo = guardian_tel_no_mobile,
                    GuardianRelationship = guardian_relationship,
                    ForceType = forces_type

                };

                _enlistmentDBContext.MstStudentParentGuardianDetails.Add(parentDet);
                _enlistmentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
