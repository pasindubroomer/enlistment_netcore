using enlistment_netcore.Data.Interfaces;
using enlistment_netcore.Models.CustomModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace enlistment_netcore.Controllers
{

    public class UserController : Controller
    {
        private readonly IEnlistment _iEnlistment;
        private readonly ICommon _iCommon;

        public UserController(IEnlistment IEnlistment, ICommon ICommon)
        {
            _iEnlistment = IEnlistment;
            _iCommon = ICommon;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Eligibility()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPersonalDetails([FromBody] List<JsonModel> formDataAll)
        {
            StatusMessage _msg = new StatusMessage
            {
                Status = -1,
                Message = "Error occured!",
                ErrorType = "error"
            };

            try
            {
                #region variable declaration

                String full_name = formDataAll.Where(x => x.name == "full_name").Select(x => x.value).SingleOrDefault();
                String name_with_initial = formDataAll.Where(x => x.name == "name_with_initial").Select(x => x.value).SingleOrDefault();
                String permanent_address = formDataAll.Where(x => x.name == "permanent_address").Select(x => x.value).SingleOrDefault();
                String nic_no = formDataAll.Where(x => x.name == "nic_no").Select(x => x.value).SingleOrDefault();
                String email_address = formDataAll.Where(x => x.name == "email_address").Select(x => x.value).SingleOrDefault();
                String date_of_birth = formDataAll.Where(x => x.name == "date_of_birth").Select(x => x.value).SingleOrDefault();
                String passport_no = formDataAll.Where(x => x.name == "passport_no").Select(x => x.value).SingleOrDefault();
                String civil_status = formDataAll.Where(x => x.name == "civil_status").Select(x => x.value).SingleOrDefault();
                String tel_residence = formDataAll.Where(x => x.name == "tel_residence").Select(x => x.value).SingleOrDefault();
                String gender = formDataAll.Where(x => x.name == "gender").Select(x => x.value).SingleOrDefault();
                String mobile_no = formDataAll.Where(x => x.name == "mobile_no").Select(x => x.value).SingleOrDefault();
                String citizenship = formDataAll.Where(x => x.name == "citizenship").Select(x => x.value).SingleOrDefault();
                String religion = formDataAll.Where(x => x.name == "religion").Select(x => x.value).SingleOrDefault();

                #endregion

                bool status = _iEnlistment.AddPersonalDetails(full_name, name_with_initial, permanent_address, nic_no, email_address, date_of_birth, passport_no, civil_status, tel_residence, gender, mobile_no, citizenship, religion);

                if (status == true)
                {
                    _msg.Status = 1;
                    _msg.Message = "Success";
                    _msg.ErrorType = "success";
                }

                return StatusCode(200, new { response = _msg });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Occured");
            }
        }

        [HttpPost]
        public IActionResult AddOLDetails([FromBody] List<JsonModel> formDataAll)
        {
            StatusMessage _msg = new StatusMessage
            {
                Status = -1,
                Message = "Error occured!",
                ErrorType = "error"
            };

            try
            {
                #region variable declaration

                String school_name = formDataAll.Where(x => x.name == "ol_school_name").Select(x => x.value).SingleOrDefault();
                String index_no = formDataAll.Where(x => x.name == "ol_index_no").Select(x => x.value).SingleOrDefault();
                String ol_year = formDataAll.Where(x => x.name == "ol_year").Select(x => x.value).SingleOrDefault();

                String subject1 = formDataAll.Where(x => x.name == "subject1").Select(x => x.value).SingleOrDefault();
                String subject2 = formDataAll.Where(x => x.name == "subject2").Select(x => x.value).SingleOrDefault();
                String subject3 = formDataAll.Where(x => x.name == "subject3").Select(x => x.value).SingleOrDefault();
                String subject4 = formDataAll.Where(x => x.name == "subject4").Select(x => x.value).SingleOrDefault();
                String subject5 = formDataAll.Where(x => x.name == "subject5").Select(x => x.value).SingleOrDefault();
                String subject6 = formDataAll.Where(x => x.name == "subject6").Select(x => x.value).SingleOrDefault();
                String subject7 = formDataAll.Where(x => x.name == "subject7").Select(x => x.value).SingleOrDefault();
                String subject8 = formDataAll.Where(x => x.name == "subject8").Select(x => x.value).SingleOrDefault();
                String subject9 = formDataAll.Where(x => x.name == "subject9").Select(x => x.value).SingleOrDefault();

                String subject1_grade = formDataAll.Where(x => x.name == "subject1_grade").Select(x => x.value).SingleOrDefault();
                String subject2_grade = formDataAll.Where(x => x.name == "subject2_grade").Select(x => x.value).SingleOrDefault();
                String subject3_grade = formDataAll.Where(x => x.name == "subject3_grade").Select(x => x.value).SingleOrDefault();
                String subject4_grade = formDataAll.Where(x => x.name == "subject4_grade").Select(x => x.value).SingleOrDefault();
                String subject5_grade = formDataAll.Where(x => x.name == "subject5_grade").Select(x => x.value).SingleOrDefault();
                String subject6_grade = formDataAll.Where(x => x.name == "subject6_grade").Select(x => x.value).SingleOrDefault();
                String subject7_grade = formDataAll.Where(x => x.name == "subject7_grade").Select(x => x.value).SingleOrDefault();
                String subject8_grade = formDataAll.Where(x => x.name == "subject8_grade").Select(x => x.value).SingleOrDefault();
                String subject9_grade = formDataAll.Where(x => x.name == "subject9_grade").Select(x => x.value).SingleOrDefault();

                #endregion

                bool status = _iEnlistment.AddOLDetails(school_name, "922581088V", index_no, ol_year, subject1, subject2, subject3, subject4, subject5, subject6, subject7, subject8, subject9, subject1_grade, subject2_grade, subject3_grade, subject4_grade, subject5_grade, subject6_grade, subject7_grade, subject8_grade, subject9_grade);

                if (status == true)
                {
                    _msg.Status = 1;
                    _msg.Message = "Success";
                    _msg.ErrorType = "success";
                }

                return StatusCode(200, new { response = _msg });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Occured");
            }
        }

        [HttpPost]
        public IActionResult AddALDetails([FromBody] List<JsonModel> formDataAll)
        {
            StatusMessage _msg = new StatusMessage
            {
                Status = -1,
                Message = "Error occured!",
                ErrorType = "error"
            };

            try
            {
                #region variable declaration

                String al_school_name = formDataAll.Where(x => x.name == "al_school_name").Select(x => x.value).SingleOrDefault();
                String passed_al_index_no = formDataAll.Where(x => x.name == "passed_al_index_no").Select(x => x.value).SingleOrDefault();
                String passed_al_year = formDataAll.Where(x => x.name == "passed_al_year").Select(x => x.value).SingleOrDefault();
                String passed_al_attempt = formDataAll.Where(x => x.name == "passed_al_attempt").Select(x => x.value).SingleOrDefault();

                String attempt_1st_index_no = formDataAll.Where(x => x.name == "attempt_1st_index_no").Select(x => x.value).SingleOrDefault();
                String attempt_1st_year = formDataAll.Where(x => x.name == "attempt_1st_year").Select(x => x.value).SingleOrDefault();
                String attempt_2nd_index_no = formDataAll.Where(x => x.name == "attempt_2nd_index_no").Select(x => x.value).SingleOrDefault();
                String attempt_2nd_year = formDataAll.Where(x => x.name == "attempt_2nd_year").Select(x => x.value).SingleOrDefault();
                String attempt_3rd_index_no = formDataAll.Where(x => x.name == "attempt_3rd_index_no").Select(x => x.value).SingleOrDefault();
                String attempt_3rd_year = formDataAll.Where(x => x.name == "attempt_3rd_year").Select(x => x.value).SingleOrDefault();


                String al_subject1 = formDataAll.Where(x => x.name == "al_subject1").Select(x => x.value).SingleOrDefault();
                String al_subject1_grade = formDataAll.Where(x => x.name == "al_subject1_grade").Select(x => x.value).SingleOrDefault();
                String al_subject2 = formDataAll.Where(x => x.name == "al_subject2").Select(x => x.value).SingleOrDefault();
                String al_subject2_grade = formDataAll.Where(x => x.name == "al_subject2_grade").Select(x => x.value).SingleOrDefault();
                String al_subject3 = formDataAll.Where(x => x.name == "al_subject3").Select(x => x.value).SingleOrDefault();
                String al_subject3_grade = formDataAll.Where(x => x.name == "al_subject3_grade").Select(x => x.value).SingleOrDefault();
                String al_english = formDataAll.Where(x => x.name == "al_english").Select(x => x.value).SingleOrDefault();
                String al_english_grade = formDataAll.Where(x => x.name == "al_english_grade").Select(x => x.value).SingleOrDefault();

                String al_general_test = formDataAll.Where(x => x.name == "al_general_test").Select(x => x.value).SingleOrDefault();
                String qualified_for_university = formDataAll.Where(x => x.name == "qualified_for_university").Select(x => x.value).SingleOrDefault();
                String z_score = formDataAll.Where(x => x.name == "z_score").Select(x => x.value).SingleOrDefault();

                #endregion

                bool status = _iEnlistment.AddALDetails(al_school_name, "922581088V", passed_al_index_no, passed_al_year, passed_al_attempt, attempt_1st_index_no, attempt_1st_year, attempt_2nd_index_no, attempt_2nd_year, attempt_3rd_index_no, attempt_3rd_year, al_subject1, al_subject1_grade, al_subject2, al_subject2_grade, al_subject3, al_subject3_grade, al_english_grade, al_general_test, qualified_for_university, z_score);

                if (status == true)
                {
                    _msg.Status = 1;
                    _msg.Message = "Success";
                    _msg.ErrorType = "success";
                }

                return StatusCode(200, new { response = _msg });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Occured");
            }
        }

        [HttpPost]
        public IActionResult AddCadetScoutingDetails([FromBody] List<JsonModel> formDataAll)
        {
            StatusMessage _msg = new StatusMessage
            {
                Status = -1,
                Message = "Error occured!",
                ErrorType = "error"
            };

            try
            {
                #region variable declaration

                String juo = formDataAll.Where(x => x.name == "juo").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String suo = formDataAll.Where(x => x.name == "suo").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String pte = formDataAll.Where(x => x.name == "pte").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String lcpl = formDataAll.Where(x => x.name == "lcpl").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String cpl = formDataAll.Where(x => x.name == "cpl").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String sgt = formDataAll.Where(x => x.name == "sgt").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String pres_scouts = formDataAll.Where(x => x.name == "pres_scouts").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String cc_dc_awards = formDataAll.Where(x => x.name == "cc_dc_awards").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String scouts_award = formDataAll.Where(x => x.name == "scouts_award").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String scouts = formDataAll.Where(x => x.name == "scouts").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String cub_scout_with_star = formDataAll.Where(x => x.name == "cub_scout_with_star").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String cadeting = formDataAll.Where(x => x.name == "cadeting").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String scouting = formDataAll.Where(x => x.name == "scouting").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String prefect = formDataAll.Where(x => x.name == "prefect").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String school_captain = formDataAll.Where(x => x.name == "school_captain").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String house_captain = formDataAll.Where(x => x.name == "house_captain").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String band = formDataAll.Where(x => x.name == "band").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String societies = formDataAll.Where(x => x.name == "societies").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";
                String first_aid = formDataAll.Where(x => x.name == "first_aid").Select(x => x.value).SingleOrDefault() == "on" ? "1" : "0";

                #endregion

                bool status = _iEnlistment.AddCadetScoutingDetails(juo, "922581088V", suo, pte, lcpl, cpl, sgt, pres_scouts, cc_dc_awards, scouts_award, scouts, cub_scout_with_star, cadeting, scouting, prefect, school_captain, house_captain, band, societies, first_aid);

                if (status == true)
                {
                    _msg.Status = 1;
                    _msg.Message = "Success";
                    _msg.ErrorType = "success";
                }

                return StatusCode(200, new { response = _msg });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Occured");
            }
        }

        [HttpPost]
        public IActionResult AddSportsDetails([FromBody] List<SportModel> sportsList)
        {
            StatusMessage _msg = new StatusMessage
            {
                Status = -1,
                Message = "Error occured!",
                ErrorType = "error"
            };

            try
            {
                bool status = false;
                foreach (var item in sportsList)
                {
                    status = _iEnlistment.AddSportsDetails(item.sports_name, "922581088V", item.sport_id, item.sl == true ? "1" : "0", item.sc == true ? "1" : "0", item.zl == true ? "1" : "0", item.dl == true ? "1" : "0", item.pl == true ? "1" : "0", item.pnl == true ? "1" : "0", item.pl_in_nl, item.nc, item.rsl_of_o);
                }

                if (status == true)
                {
                    _msg.Status = 1;
                    _msg.Message = "Success";
                    _msg.ErrorType = "success";
                }

                return StatusCode(200, new { response = _msg });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Occured");
            }
        }

        [HttpPost]
        public IActionResult AddParentGuardianDetails([FromBody] List<JsonModel> formDataAll)
        {
            StatusMessage _msg = new StatusMessage
            {
                Status = -1,
                Message = "Error occured!",
                ErrorType = "error"
            };

            try
            {
                #region variable declaration

                String father_full_name = formDataAll.Where(x => x.name == "father_full_name").Select(x => x.value).SingleOrDefault();
                String father_permanent_address = formDataAll.Where(x => x.name == "father_permanent_address").Select(x => x.value).SingleOrDefault();
                String father_tel_no_residence = formDataAll.Where(x => x.name == "father_tel_no_residence").Select(x => x.value).SingleOrDefault();
                String father_tel_no_mobile = formDataAll.Where(x => x.name == "father_tel_no_mobile").Select(x => x.value).SingleOrDefault();
                String father_present_employment = formDataAll.Where(x => x.name == "father_present_employment").Select(x => x.value).SingleOrDefault();
                String father_previous_employment = formDataAll.Where(x => x.name == "father_previous_employment").Select(x => x.value).SingleOrDefault();

                String mother_full_name = formDataAll.Where(x => x.name == "mother_full_name").Select(x => x.value).SingleOrDefault();
                String mother_permanent_address = formDataAll.Where(x => x.name == "mother_permanent_address").Select(x => x.value).SingleOrDefault();
                String mother_tel_no_residence = formDataAll.Where(x => x.name == "mother_tel_no_residence").Select(x => x.value).SingleOrDefault();
                String mother_tel_no_mobile = formDataAll.Where(x => x.name == "mother_tel_no_mobile").Select(x => x.value).SingleOrDefault();
                String mother_present_employment = formDataAll.Where(x => x.name == "mother_present_employment").Select(x => x.value).SingleOrDefault();
                String mother_previous_employment = formDataAll.Where(x => x.name == "mother_previous_employment").Select(x => x.value).SingleOrDefault();

                String guardian_full_name = formDataAll.Where(x => x.name == "guardian_full_name").Select(x => x.value).SingleOrDefault();
                String guardian_relationship = formDataAll.Where(x => x.name == "guardian_relationship").Select(x => x.value).SingleOrDefault();
                String guardian_permanent_address = formDataAll.Where(x => x.name == "guardian_permanent_address").Select(x => x.value).SingleOrDefault();
                String guardian_tel_no_residence = formDataAll.Where(x => x.name == "guardian_tel_no_residence").Select(x => x.value).SingleOrDefault();
                String guardian_tel_no_mobile = formDataAll.Where(x => x.name == "guardian_tel_no_mobile").Select(x => x.value).SingleOrDefault();

                String forces_type = formDataAll.Where(x => x.name == "forces_type").Select(x => x.value).SingleOrDefault();

                #endregion

                bool status = _iEnlistment.AddParentGuardianDetails("922581088V", father_full_name, father_permanent_address, father_tel_no_residence, father_tel_no_mobile, father_present_employment, father_previous_employment, mother_full_name, mother_permanent_address, mother_tel_no_residence, mother_tel_no_mobile, mother_present_employment, mother_previous_employment, guardian_full_name, guardian_relationship, guardian_permanent_address, guardian_tel_no_residence, guardian_tel_no_mobile, forces_type);

                if (status == true)
                {
                    _msg.Status = 1;
                    _msg.Message = "Success";
                    _msg.ErrorType = "success";
                }

                return StatusCode(200, new { response = _msg });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Occured");
            }
        }


        [HttpGet]
        public IActionResult GetAlsubjectsByStream(string stream)
        {
            try
            {
                return Ok(Json(_iEnlistment.GetAlsubjectsByStream(stream)));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetSports()
        {
            return Json(_iCommon.GetSports());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetEligibileDegrees([FromBody] List<JsonModel> formDataAll)
        {
            try
            {
                #region variable declaration

                List<String> degree_list = new List<string>();

                int al_min_c_pass_count = 0;
                int al_min_s_pass_count = 0;

                int ol_min_c_pass_count = 0;
                int ol_min_s_pass_count = 0;

                String studentship = formDataAll.Where(x => x.name == "studentship").Select(x => x.value).SingleOrDefault();
                String date_of_birth = formDataAll.Where(x => x.name == "date_of_birth").Select(x => x.value).SingleOrDefault();
                String gender_status = formDataAll.Where(x => x.name == "gender_status").Select(x => x.value).SingleOrDefault();
                String nic_passport = formDataAll.Where(x => x.name == "nic_passport").Select(x => x.value).SingleOrDefault();
                String citizenship = formDataAll.Where(x => x.name == "citizenship").Select(x => x.value).SingleOrDefault();
                String civil_status = formDataAll.Where(x => x.name == "civil_status").Select(x => x.value).SingleOrDefault();
                String stream = formDataAll.Where(x => x.name == "stream").Select(x => x.value).SingleOrDefault();
                String al_year = formDataAll.Where(x => x.name == "al_year").Select(x => x.value).SingleOrDefault();
                String al_attempt = formDataAll.Where(x => x.name == "al_attempt").Select(x => x.value).SingleOrDefault();
                String al_subject1 = formDataAll.Where(x => x.name == "al_subject1").Select(x => x.value).SingleOrDefault();
                String al_subject1_grade = formDataAll.Where(x => x.name == "al_subject1_grade").Select(x => x.value).SingleOrDefault();
                String al_subject2 = formDataAll.Where(x => x.name == "al_subject2").Select(x => x.value).SingleOrDefault();
                String al_subject2_grade = formDataAll.Where(x => x.name == "al_subject2_grade").Select(x => x.value).SingleOrDefault();
                String al_subject3 = formDataAll.Where(x => x.name == "al_subject3").Select(x => x.value).SingleOrDefault();
                String al_subject3_grade = formDataAll.Where(x => x.name == "al_subject3_grade").Select(x => x.value).SingleOrDefault();
                String al_english_grade = formDataAll.Where(x => x.name == "al_english_grade").Select(x => x.value).SingleOrDefault();
                String al_english_year = formDataAll.Where(x => x.name == "al_english_year").Select(x => x.value).SingleOrDefault();
                String general_test_marks = formDataAll.Where(x => x.name == "general_test_marks").Select(x => x.value).SingleOrDefault();
                String qualified_university = formDataAll.Where(x => x.name == "qualified_university").Select(x => x.value).SingleOrDefault();
                String z_score = formDataAll.Where(x => x.name == "z_score").Select(x => x.value).SingleOrDefault();
                String maths_ol_grade = formDataAll.Where(x => x.name == "maths_ol_grade").Select(x => x.value).SingleOrDefault();
                String maths_ol_index = formDataAll.Where(x => x.name == "maths_ol_index").Select(x => x.value).SingleOrDefault();
                String maths_ol_year = formDataAll.Where(x => x.name == "maths_ol_year").Select(x => x.value).SingleOrDefault();
                String science_ol_grade = formDataAll.Where(x => x.name == "science_ol_grade").Select(x => x.value).SingleOrDefault();
                String science_ol_index = formDataAll.Where(x => x.name == "science_ol_index").Select(x => x.value).SingleOrDefault();
                String science_ol_year = formDataAll.Where(x => x.name == "science_ol_year").Select(x => x.value).SingleOrDefault();
                String sinhalatamil_ol_grade = formDataAll.Where(x => x.name == "sinhalatamil_ol_grade").Select(x => x.value).SingleOrDefault();
                String sinhalatamil_ol_index = formDataAll.Where(x => x.name == "sinhalatamil_ol_index").Select(x => x.value).SingleOrDefault();
                String sinhalatamil_ol_year = formDataAll.Where(x => x.name == "sinhalatamil_ol_year").Select(x => x.value).SingleOrDefault();
                String english_ol_grade = formDataAll.Where(x => x.name == "english_ol_grade").Select(x => x.value).SingleOrDefault();
                String english_ol_index = formDataAll.Where(x => x.name == "english_ol_index").Select(x => x.value).SingleOrDefault();
                String english_ol_year = formDataAll.Where(x => x.name == "english_ol_year").Select(x => x.value).SingleOrDefault();

                #endregion

                #region al s and c count
                if (al_subject1_grade != "F" && al_subject1_grade != "AB")
                {
                    al_min_s_pass_count = al_min_s_pass_count + 1;
                }

                if (al_subject2_grade != "F" && al_subject2_grade != "AB")
                {
                    al_min_s_pass_count = al_min_s_pass_count + 1;
                }

                if (al_subject3_grade != "F" && al_subject3_grade != "AB")
                {
                    al_min_s_pass_count = al_min_s_pass_count + 1;
                }


                if (al_subject1_grade != "F" && al_subject1_grade != "AB" && al_subject1_grade != "S")
                {
                    al_min_c_pass_count = al_min_c_pass_count + 1;
                }

                if (al_subject2_grade != "F" && al_subject2_grade != "AB" && al_subject2_grade != "S")
                {
                    al_min_c_pass_count = al_min_c_pass_count + 1;
                }

                if (al_subject3_grade != "F" && al_subject3_grade != "AB" && al_subject3_grade != "S")
                {
                    al_min_c_pass_count = al_min_c_pass_count + 1;
                }
                #endregion


                DateTime ageCalculationDate = _iEnlistment.GetAgeCalculationDate();
                DateTime birthdayDateTime = DateTime.ParseExact(date_of_birth, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                DateTime birthDay17Year = birthdayDateTime.AddYears(17);
                DateTime birthDay30Year = birthdayDateTime.AddYears(30);
                DateTime birthDay24Year = birthdayDateTime.AddYears(24);

                double int_general = double.Parse(general_test_marks);

                if (studentship == "dayscholar")
                {
                    if (al_year == "2019" || al_year == "2020")
                    {
                        if (int_general >= 30)
                        {
                            if (english_ol_grade != "AB" && english_ol_grade != "F" && english_ol_grade != "C")
                            {
                                if (ageCalculationDate <= birthDay24Year && ageCalculationDate >= birthDay17Year)
                                {
                                    ///////////////// Faculty of Defence & Strategic Studies
                                    ///////////////// BSc Strategic Studies & International Relations
                                    if (al_min_s_pass_count >= 3)
                                    {
                                        degree_list.Add("BSI");
                                    }

                                    ///////////////// Faculty of Engineering
                                    ///////////////// BSc (Hons) Engineering [Aeronautical/ Biomedical/ Civil / Electrical & Electronic/ Electronic & Telecommunication/ Mechanical / Mechatronic Engineering]
                                    if (stream == "Maths")
                                    {
                                        if (al_subject1 == "2" || al_subject1 == "4" || al_subject1 == "11")
                                        {
                                            if (al_subject2 == "2" || al_subject2 == "4" || al_subject2 == "11")
                                            {
                                                if (al_subject3 == "2" || al_subject3 == "4" || al_subject3 == "11")
                                                {
                                                    if ((al_min_c_pass_count >= 3) || (al_min_c_pass_count >= 2 && (al_min_s_pass_count - al_min_c_pass_count) >= 1))
                                                    {
                                                        degree_list.Add("ENG");
                                                    }
                                                }
                                            }
                                        }

                                    }

                                    ///////////////// Faculty of Law
                                    ///////////////// Bachelor of Laws (LLB)
                                    if (stream == "Maths" || stream == "Bio" || stream == "Commerce" || stream == "Arts")
                                    {
                                        if ((al_min_c_pass_count >= 3) || (al_min_c_pass_count >= 2 && (al_min_s_pass_count - al_min_c_pass_count) >= 1))
                                        {
                                            if (sinhalatamil_ol_grade != "F" && sinhalatamil_ol_grade != "AB" && sinhalatamil_ol_grade != "S")
                                            {
                                                if (al_attempt == "01")
                                                {
                                                    degree_list.Add("LLB");
                                                }
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Management, Social Sciences and Humanities
                                    ///////////////// BSc Management & Technical Sciences
                                    if (stream == "Maths" || stream == "Bio")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("MTS");
                                        }
                                    }

                                    ///////////////// Faculty of Management, Social Sciences and Humanities
                                    ///////////////// BSc Logistics Management
                                    if (stream == "Maths" || stream == "Bio" || stream == "Commerce")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("BLM");
                                        }
                                    }

                                    ///////////////// Faculty of Management, Social Sciences and Humanities
                                    ///////////////// BSc Social Sciences
                                    if ((al_min_s_pass_count >= 3))
                                    {
                                        degree_list.Add("BSS");
                                    }

                                    ///////////////// Faculty of Management, Social Sciences and Humanities
                                    ///////////////// BSc in Applied Data Science Communication
                                    if (stream == "Maths" || stream == "Bio" || stream == "Commerce" || stream == "Arts" || stream == "Technology")
                                    {
                                        if (stream == "Arts")
                                        {
                                            if ((al_subject1 == "38" || al_subject1 == "91") || (al_subject2 == "38" || al_subject2 == "91") || (al_subject3 == "38" || al_subject3 == "91"))
                                            {
                                                if (maths_ol_grade != "F" && maths_ol_grade != "AB" && maths_ol_grade != "S")
                                                {
                                                    degree_list.Add("ADC");
                                                }
                                            }
                                        }
                                        else if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("ADC");
                                        }
                                    }

                                    ///////////////// Faculty of Management, Social Sciences and Humanities
                                    ///////////////// BA in Teaching English to Speakers of Other Languages(TESOL)
                                    if ((al_min_s_pass_count >= 3))
                                    {
                                        if (english_ol_grade == "A" || english_ol_grade == "B")
                                        {
                                            degree_list.Add("BTE");
                                        }
                                    }

                                    ///////////////// Faculty of Computing
                                    ///////////////// [BSc (Hons) Computer Science ,BSc (Hons) Software Engineering , BSc (Hons) Computer Engineering]
                                    if (stream == "Maths" || stream == "Other")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("BCE");
                                            degree_list.Add("BSE");
                                            degree_list.Add("BCS");
                                        }
                                    }

                                    ///////////////// Faculty of Computing
                                    ///////////////// [BSc (Hons) Data Science and Business Analytics]
                                    if (stream == "Maths")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("DBA");
                                        }
                                    }

                                    ///////////////// Faculty of Allied Health Sciences 
                                    ///////////////// BSc (Hons) Nursing (Payment Basis)
                                    if (stream == "Maths" || stream == "Bio")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("BNP");
                                        }
                                    }

                                    ///////////////// Faculty of Allied Health Sciences 
                                    ///////////////// BSc (Hons) Nursing 
                                    if (stream == "Maths" || stream == "Bio")
                                    {
                                        if ((al_subject1 == "3" || al_subject1 == "4"))
                                        {
                                            if ((al_subject1_grade != "F" && al_subject1_grade != "AB" && al_subject1_grade != "S") && (al_min_s_pass_count >= 3))
                                            {
                                                degree_list.Add("PMY");
                                                degree_list.Add("MLS");
                                            }
                                        }
                                        else if ((al_subject2 == "3" || al_subject2 == "4"))
                                        {
                                            if ((al_subject2_grade != "F" && al_subject2_grade != "AB" && al_subject2_grade != "S") && (al_min_s_pass_count >= 3))
                                            {
                                                degree_list.Add("PMY");
                                                degree_list.Add("MLS");
                                            }
                                        }
                                        else if ((al_subject3 == "3" || al_subject3 == "4"))
                                        {
                                            if ((al_subject3_grade != "F" && al_subject3_grade != "AB" && al_subject3_grade != "S") && (al_min_s_pass_count >= 3))
                                            {
                                                degree_list.Add("PMY");
                                                degree_list.Add("MLS");
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Allied Health Sciences 
                                    ///////////////// [ BSc Honours in Physiotherapy / Radiography / Radiotherapy degree programme]
                                    if (stream == "Maths" || stream == "Bio")
                                    {
                                        if ((al_subject1 == "1" || al_subject1 == "2"))
                                        {
                                            if ((al_subject1_grade != "F" && al_subject1_grade != "AB" && al_subject1_grade != "S") && (al_min_s_pass_count >= 3))
                                            {
                                                degree_list.Add("PST");
                                                degree_list.Add("RGY");
                                                degree_list.Add("RTP");
                                            }
                                        }
                                        else if ((al_subject2 == "1" || al_subject2 == "2"))
                                        {
                                            if ((al_subject2_grade != "F" && al_subject2_grade != "AB" && al_subject2_grade != "S") && (al_min_s_pass_count >= 3))
                                            {
                                                degree_list.Add("PST");
                                                degree_list.Add("RGY");
                                                degree_list.Add("RTP");
                                            }
                                        }
                                        else if ((al_subject3 == "1" || al_subject3 == "2"))
                                        {
                                            if ((al_subject3_grade != "F" && al_subject3_grade != "AB" && al_subject3_grade != "S") && (al_min_s_pass_count >= 3))
                                            {
                                                degree_list.Add("PST");
                                                degree_list.Add("RGY");
                                                degree_list.Add("RTP");
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Allied Health Sciences 
                                    ///////////////// BSc (Hons) Nursing (NonPayment Basis)
                                    if (stream == "Maths" || stream == "Bio")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("NNP");
                                        }
                                    }

                                    ///////////////// Faculty of Technology
                                    ///////////////// [Bachelor of Engineering Technology Honours in Building Services Technology,Bachelor of Engineering Technology Honours in Construction Technology,Bachelor of Engineering Technology Honours in Biomedical Instrumentation Technology]
                                    if (stream == "Maths" || stream == "Technology")
                                    {
                                        if (stream == "Maths")
                                        {
                                            if ((al_subject1 == "2" || al_subject1 == "4" || al_subject1 == "11") && (al_subject2 == "2" || al_subject2 == "4" || al_subject2 == "11") && (al_subject3 == "2" || al_subject3 == "4" || al_subject3 == "11"))
                                            {
                                                if (al_min_s_pass_count >= 3)
                                                {
                                                    if ((english_ol_grade != "F" && english_ol_grade != "AB" || english_ol_grade != "S") && (maths_ol_grade != "F" && maths_ol_grade != "AB" || maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB" || science_ol_grade != "S"))
                                                    {
                                                        degree_list.Add("BST");
                                                        degree_list.Add("CST");
                                                        degree_list.Add("BMT");
                                                    }
                                                }
                                            }
                                        }
                                        if (stream == "Technology")
                                        {

                                            if ((al_subject1 == "81" && al_subject2 == "83") || (al_subject1 == "83" && al_subject2 == "81"))
                                            {
                                                if (al_min_s_pass_count >= 3)
                                                {
                                                    if ((english_ol_grade != "F" && english_ol_grade != "AB" || english_ol_grade != "S") && (maths_ol_grade != "F" && maths_ol_grade != "AB" || maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB" || science_ol_grade != "S"))
                                                    {
                                                        degree_list.Add("BST");
                                                        degree_list.Add("CST");
                                                        degree_list.Add("BMT");
                                                    }
                                                }
                                            }
                                            else if ((al_subject1 == "81" && al_subject3 == "83") || (al_subject1 == "83" && al_subject3 == "81"))
                                            {
                                                if (al_min_s_pass_count >= 3)
                                                {
                                                    if ((english_ol_grade != "F" && english_ol_grade != "AB" || english_ol_grade != "S") && (maths_ol_grade != "F" && maths_ol_grade != "AB" || maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB" || science_ol_grade != "S"))
                                                    {
                                                        degree_list.Add("BST");
                                                        degree_list.Add("CST");
                                                        degree_list.Add("BMT");
                                                    }
                                                }
                                            }
                                            else if ((al_subject2 == "81" && al_subject3 == "83") || (al_subject2 == "83" && al_subject3 == "81"))
                                            {
                                                if (al_min_s_pass_count >= 3)
                                                {
                                                    if ((english_ol_grade != "F" && english_ol_grade != "AB" || english_ol_grade != "S") && (maths_ol_grade != "F" && maths_ol_grade != "AB" || maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB" || science_ol_grade != "S"))
                                                    {
                                                        degree_list.Add("BST");
                                                        degree_list.Add("CST");
                                                        degree_list.Add("BMT");
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Built Environment & Spatial Sciences
                                    ///////////////// Bachelor of Architecture
                                    if (stream == "Maths" || stream == "Bio" || stream == "Arts")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            if ((maths_ol_grade != "F" && maths_ol_grade != "AB" || maths_ol_grade != "S"))
                                            {
                                                degree_list.Add("ARC");
                                            }
                                            else if (stream == "Maths")
                                            {
                                                degree_list.Add("ARC");
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Built Environment & Spatial Sciences
                                    ///////////////// BSc (Hons) Surveying Sciences
                                    if (stream == "Maths")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            if ((al_subject1 == "2" || al_subject1 == "11") && (al_subject2 == "2" || al_subject2 == "11") && (al_subject3 == "2" || al_subject3 == "11"))
                                            {
                                                degree_list.Add("BSV");
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Built Environment & Spatial Sciences
                                    ///////////////// BSc (Hons) Quantity Surveying
                                    if (stream == "Maths")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            if ((maths_ol_grade != "F" && maths_ol_grade != "AB" || maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB"))
                                            {
                                                degree_list.Add("QSH");
                                            }
                                        }
                                    }

                                    ///////////////// Faculty of Computing
                                    ///////////////// BSc (Hons) Information Technology
                                    if (stream == "Maths" || stream == "Bio" || stream == "Commerce" || stream == "Arts")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("BIT");
                                        }
                                    }

                                    ///////////////// Faculty of Computing
                                    ///////////////// BSc (Hons) Information Systems
                                    if (stream == "Maths" || stream == "Bio" || stream == "Commerce" || stream == "Arts")
                                    {
                                        if ((al_min_s_pass_count >= 3))
                                        {
                                            degree_list.Add("BIS");
                                        }
                                    }

                                    ///////////////// Faculty of Technology
                                    ///////////////// Bachelor of Technology Honours in Information and Communication Technology
                                    if (stream == "Maths" || stream == "Bio" || stream == "Technology")
                                    {
                                        if (stream == "Maths")
                                        {
                                            if ((al_subject1 == "2" || al_subject1 == "4" || al_subject1 == "11") && (al_subject2 == "2" || al_subject2 == "4" || al_subject2 == "11") && (al_subject3 == "2" || al_subject3 == "4" || al_subject3 == "11"))
                                            {
                                                if (al_min_s_pass_count >= 3)
                                                {
                                                    if ((english_ol_grade != "F" && english_ol_grade != "AB" && english_ol_grade != "S") && (maths_ol_grade != "F" && maths_ol_grade != "AB" && maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB" && science_ol_grade != "S"))
                                                    {
                                                        degree_list.Add("ICT");
                                                    }
                                                }
                                            }
                                        }

                                        if (stream == "Bio")
                                        {
                                            if ((al_subject1 == "1" || al_subject1 == "3" || al_subject1 == "12") && (al_subject2 == "1" || al_subject2 == "3" || al_subject2 == "12") && (al_subject3 == "1" || al_subject3 == "3" || al_subject3 == "12"))
                                            {
                                                if (al_min_s_pass_count >= 3)
                                                {
                                                    if ((english_ol_grade != "F" && english_ol_grade != "AB" && english_ol_grade != "S") && (maths_ol_grade != "F" && maths_ol_grade != "AB" && maths_ol_grade != "S") && (science_ol_grade != "F" && science_ol_grade != "AB" && science_ol_grade != "S"))
                                                    {
                                                        degree_list.Add("ICT");
                                                    }
                                                }
                                            }
                                        }

                                        if (stream == "Technology")
                                        {
                                            degree_list.Add("ICT");
                                        }
                                    }
                                }
                                else if (ageCalculationDate <= birthDay30Year && ageCalculationDate >= birthDay17Year)
                                {
                                    ///////////////// Faculty of Law
                                    ///////////////// Bachelor of Laws (LLB)
                                    if (stream == "Maths" || stream == "Bio" || stream == "Commerce" || stream == "Arts")
                                    {
                                        if ((al_min_c_pass_count >= 3) || (al_min_c_pass_count >= 2 && (al_min_s_pass_count - al_min_c_pass_count) >= 1))
                                        {
                                            if (sinhalatamil_ol_grade != "F" && sinhalatamil_ol_grade != "AB" && sinhalatamil_ol_grade != "S")
                                            {
                                                if (al_attempt == "01")
                                                {
                                                    degree_list.Add("LLB");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                }

                return StatusCode(200, new { Data = degree_list });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Occured");
            }
        }
    }
}
