using enlistment_netcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enlistment_netcore.Data.Interfaces
{
    public interface IEnlistment
    {
        List<MstAlsubject> GetAlsubjectsByStream(string stream);

        bool ValidateNIC(string nicno);

        DateTime GetAgeCalculationDate();

        bool AddPersonalDetails(String full_name, String name_with_initial, String permanent_address, String nic_no, string email, String date_of_birth, String passport_no, String civil_status, String tel_residence, String gender, String mobile_no, String citizenship, String religion);

        bool AddOLDetails(String school_name, String nic_no, String index_no, String ol_year, String subject1, string subject2, String subject3, String subject4, String subject5, String subject6, String subject7, String subject8, String subject9, String subject1_grade, String subject2_grade, String subject3_grade, String subject4_grade, String subject5_grade, String subject6_grade, String subject7_grade, String subject8_grade, String subject9_grade);

        bool AddALDetails(String al_school_name,String NicNo, String passed_al_index_no, String passed_al_year, String passed_al_attempt, String attempt_1st_index_no, string attempt_1st_year, String attempt_2nd_index_no, String attempt_2nd_year, String attempt_3rd_index_no, String attempt_3rd_year, String al_subject1, String al_subject1_grade, String al_subject2, String al_subject2_grade, String al_subject3, String al_subject3_grade, String al_english_grade, String al_general_test, String qualified_for_university, String z_score);

        bool AddCadetScoutingDetails(String juo, String NicNo, String suo, String pte, String lcpl, String cpl, String sgt, String pres_scouts, String cc_dc_awards, String scouts_award, String scouts, String cub_scout_with_star, String cadeting, String scouting, String prefect, String school_captain, String house_captain, String band, String societies, String first_aid);

        bool AddSportsDetails(String sports_name, String NicNo, String sport_id, String sl, String sc, String zl, String dl, String pl, String pnl, String pl_in_nl, String nc, String rsl_of_o);

        bool AddParentGuardianDetails(String NicNo, String father_full_name, String father_permanent_address, String father_tel_no_residence, String father_tel_no_mobile, String father_present_employment, String father_previous_employment, String mother_full_name, String mother_permanent_address, String mother_tel_no_residence, String mother_tel_no_mobile, String mother_present_employment, String mother_previous_employment, String guardian_full_name, String guardian_relationship, String guardian_permanent_address, String guardian_tel_no_residence, String guardian_tel_no_mobile, String forces_type);
    }
}
