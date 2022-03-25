
$(document).ready(function () {
    var _wizardEl;
    var _formEl;
    var _formPersonalDet;
    var _formOlDet;
    var _formAlDet;
    var _formCadetScoutingDet;
    var _formParentGuardianDet;
    var _wizardObj;
    var _validations = [];
    var _Sports = [];
    var _validationPersonalDetails;
    var _validationOLDetails;
    var _validationALDetails;
    var _validationParentGuardianDetails;

    init();

    function init() {
        _wizardEl = KTUtil.getById('kt_wizard');
        _formPersonalDet = KTUtil.getById('kt_form_personal_det');
        _formOlDet = KTUtil.getById('kt_form_ol_det');
        _formAlDet = KTUtil.getById('kt_form_al_det');
        _formCadetScoutingDet = KTUtil.getById('kt_form_extra_curricular_cadet_scouting_det');
        _formParentGuardianDet = KTUtil.getById('kt_form_parent_and_guardian_det');
        GetSports();
        initPersonalDetailsValidation();
        initOLDetailsValidation();
        initALDetailsValidation();
        initParentGuardianDetailsValidation();
        initWizard();



        _validations.push(_validationPersonalDetails);
        _validations.push(_validationOLDetails);
        _validations.push(_validationALDetails);
        _validations.push(null);
        _validations.push(null);
        _validations.push(_validationOLDetails);
    }

    function initWizard() {
        _wizardObj = new KTWizard(_wizardEl, {
            startStep: 2, 
            clickableSteps: false,
        });

        _wizardObj.on('change', function (wizard) {

            if (wizard.getStep() > wizard.getNewStep()) {
                return;
            }
            var validator = _validations[wizard.getStep() - 1]; 

            if (wizard.getStep() != 4 && wizard.getStep() != 5) {
                if (validator) {
                    validator.validate().then(function (status) {
                        if (status == 'Valid') {
                            if (wizard.getStep() == 1) {
                                AddPersonalDetails();
                            } else if (wizard.getStep() == 2) {
                                AddOLDetails();
                            } else if (wizard.getStep() == 3) {
                                AddALDetails();
                            }
                        //} else {
                        //    Swal.fire({
                        //        text: "Sorry, looks like there are some errors detected, please try again.",
                        //        icon: "error",
                        //        buttonsStyling: false,
                        //        confirmButtonText: "Ok, got it!",
                        //        customClass: {
                        //            confirmButton: "btn font-weight-bold btn-light"
                        //        }
                        //    }).then(function () {
                        //        KTUtil.scrollTop();
                        //    });
                        }

                    }).catch(error => {
                        console.error(error);
                    });
                }
            }
            else {
                if (wizard.getStep() == 4) {
                    AddCadetScoutingDetails();
                } else if (wizard.getStep() == 5) {
                    AddSportsDetails();
                }
            }
            return false;
        });

        // Change event
        _wizardObj.on('changed', function (wizard) {
            KTUtil.scrollTop();
        });

        // Submit event
        _wizardObj.on('submit', function (wizard) {

            if (_validationParentGuardianDetails) {
                _validationParentGuardianDetails.validate().then(function (status) {
                    if (status == 'Valid') {
                        AddParentGuardianDetails();
                    } else {
                        Swal.fire({
                        	text: "Sorry, looks like there are some errors detected, please try again.",
                        	icon: "error",
                        	buttonsStyling: false,
                        	confirmButtonText: "Ok, got it!",
                        	customClass: {
                        		confirmButton: "btn font-weight-bold btn-light"
                        	}
                        }).then(function () {
                        	KTUtil.scrollTop();
                        });
                    }
                }).catch(error => {
                    console.error(error);
                });
            }
        });

    }

    function initPersonalDetailsValidation() {
        _validationPersonalDetails = FormValidation.formValidation(
            _formPersonalDet,
            {
                fields: {
                    full_name: {
                        validators: {
                            notEmpty: {
                                message: 'Full name is required'
                            }
                        }
                    },
                    name_with_initial: {
                        validators: {
                            notEmpty: {
                                message: 'Name with initial is required'
                            }
                        }
                    },
                    permanent_address: {
                        validators: {
                            notEmpty: {
                                message: 'Permanent address is required'
                            }
                        }
                    },
                    nic_no: {
                        validators: {
                            notEmpty: {
                                message: 'NIC no is required'
                            }
                        }
                    },
                    date_of_birth: {
                        validators: {
                            notEmpty: {
                                message: 'Date of birth is required'
                            }
                        }
                    },
                    tel_residence: {
                        validators: {
                            digits: {
                                message: 'The value is not a valid digits'
                            },
                            stringLength: {
                                min: 10,
                                max: 12,
                                message: 'Please enter valid phone number'
                            }
                        }
                    },
                    mobile_no: {
                        validators: {
                            notEmpty: {
                                message: 'Mobile no is required'
                            },
                            digits: {
                                message: 'The value is not a valid digits'
                            },
                            stringLength: {
                                min: 10,
                                max: 12,
                                message: 'Please enter valid phone number'
                            }
                        }
                    },
                    citizenship: {
                        validators: {
                            notEmpty: {
                                message: 'Citizenship is required'
                            }
                        }
                    },
                    email_address: {
                        validators: {
                            notEmpty: {
                                message: 'Email is required'
                            },
                            emailAddress: {
                                message: 'The value is not a valid email address'
                            }
                        }
                    },
                    student_height: {
                        validators: {
                            notEmpty: {
                                message: 'Student height is required'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        );
    }

    function initOLDetailsValidation() {
        _validationOLDetails = FormValidation.formValidation(
            _formOlDet,
            {
                fields: {
                    ol_school_name: {
                        validators: {
                            notEmpty: {
                                message: 'School name is required'
                            }
                        }
                    },
                    ol_index_no: {
                        validators: {
                            notEmpty: {
                                message: 'Index no is required'
                            }
                        }
                    },
                    ol_year: {
                        validators: {
                            notEmpty: {
                                message: 'OL year is required'
                            }
                        }
                    },
                    subject1: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 1 is required'
                            }
                        }
                    },
                    subject2: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 2 is required'
                            }
                        }
                    },
                    subject3: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 3 is required'
                            }
                        }
                    },
                    subject4: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 4 is required'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        );
    }

    function initALDetailsValidation() {
        _validationALDetails = FormValidation.formValidation(
            _formAlDet,
            {
                fields: {
                    al_school_name: {
                        validators: {
                            notEmpty: {
                                message: 'School name is required'
                            }
                        }
                    },
                    passed_al_index_no: {
                        validators: {
                            notEmpty: {
                                message: 'Index no is required'
                            }
                        }
                    },
                    passed_al_year: {
                        validators: {
                            notEmpty: {
                                message: 'AL year is required'
                            }
                        }
                    },
                    passed_al_attempt: {
                        validators: {
                            notEmpty: {
                                message: 'Attempt is required'
                            }
                        }
                    },
                    attempt_1st_index_no: {
                        validators: {
                            notEmpty: {
                                message: '1st attempt is required'
                            }
                        }
                    },
                    attempt_1st_year: {
                        validators: {
                            notEmpty: {
                                message: '1st attempt year is required'
                            }
                        }
                    },
                    al_subject1: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 1 is required'
                            }
                        }
                    },
                    al_subject2: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 2 is required'
                            }
                        }
                    },
                    al_subject3: {
                        validators: {
                            notEmpty: {
                                message: 'Subject 3 is required'
                            }
                        }
                    },
                    al_general_test: {
                        validators: {
                            notEmpty: {
                                message: 'AL general test marks is required'
                            }
                        }
                    },
                    z_score: {
                        validators: {
                            notEmpty: {
                                message: 'Z-score is required'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        );
    }

    function initParentGuardianDetailsValidation() {
        _validationParentGuardianDetails = FormValidation.formValidation(
            _formParentGuardianDet,
            {
                fields: {
                    father_full_name: {
                        validators: {
                            notEmpty: {
                                message: 'Father full name is required'
                            }
                        }
                    },
                    father_permanent_address: {
                        validators: {
                            notEmpty: {
                                message: 'Father address is required'
                            }
                        }
                    },
                    father_tel_no_mobile: {
                        validators: {
                            notEmpty: {
                                message: 'Father mobile no is required'
                            }
                        }
                    },

                    mother_full_name: {
                        validators: {
                            notEmpty: {
                                message: 'Mother full name is required'
                            }
                        }
                    },
                    mother_permanent_address: {
                        validators: {
                            notEmpty: {
                                message: 'Mother address is required'
                            }
                        }
                    },
                    mother_tel_no_mobile: {
                        validators: {
                            notEmpty: {
                                message: 'Mother mobile no is required'
                            }
                        }
                    },


                    guardian_full_name: {
                        validators: {
                            notEmpty: {
                                message: 'Guardian full name is required'
                            }
                        }
                    },
                    guardian_relationship: {
                        validators: {
                            notEmpty: {
                                message: 'Guardian relationship is required'
                            }
                        }
                    },
                    guardian_permanent_address: {
                        validators: {
                            notEmpty: {
                                message: 'Mother address is required'
                            }
                        }
                    },
                    guardian_tel_no_mobile: {
                        validators: {
                            notEmpty: {
                                message: 'Guardian mobile no is required'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    // Bootstrap Framework Integration
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        //eleInvalidClass: '',
                        eleValidClass: '',
                    })
                }
            }
        );
    }

    function AddPersonalDetails() {
        var formDataList = $("#kt_form_personal_det").serializeArray();
        var formDataAll = JSON.stringify(formDataList);

        $.ajax({
            url: "/User/AddPersonalDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: formDataAll,
            traditional: true,
            async: true,
            dataType: "json",
            headers: {
                "RequestVerificationToken":
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                if (response.response.status == -1) {
                    Swal.fire({
                        title: 'Warning',
                        text: response.response.message,
                        icon: response.response.errorType,
                        confirmButtonColor: '#3e7dfa',
                    });
                }
                else {
                    _wizardObj.goNext();
                    KTUtil.scrollTop();
                    //window.location.href = (response.newUrl);
                }
            },
            error: function (response) {
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        }).catch(error => {
            console.error(error);
        });;
    }

    function AddOLDetails() {
        var formDataList = $("#kt_form_ol_det").serializeArray();
        var formDataAll = JSON.stringify(formDataList);

        $.ajax({
            url: "/User/AddOLDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: formDataAll,
            traditional: true,
            async: true,
            dataType: "json",
            headers: {
                "RequestVerificationToken":
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                if (response.response.status == -1) {
                    Swal.fire({
                        title: 'Warning',
                        text: response.response.message,
                        icon: response.response.errorType,
                        confirmButtonColor: '#3e7dfa',
                    });
                }
                else {
                    _wizardObj.goNext();
                    KTUtil.scrollTop();
                    //window.location.href = (response.newUrl);
                }
            },
            error: function (response) {
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        }).catch(error => {
            console.error(error);
        });;
    }

    function AddALDetails() {
        var formDataList = $("#kt_form_al_det").serializeArray();
        var formDataAll = JSON.stringify(formDataList);

        $.ajax({
            url: "/User/AddALDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: formDataAll,
            traditional: true,
            async: true,
            dataType: "json",
            headers: {
                "RequestVerificationToken":
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                if (response.response.status == -1) {
                    Swal.fire({
                        title: 'Warning',
                        text: response.response.message,
                        icon: response.response.errorType,
                        confirmButtonColor: '#3e7dfa',
                    });
                }
                else {
                    _wizardObj.goNext();
                    KTUtil.scrollTop();
                    //window.location.href = (response.newUrl);
                }
            },
            error: function (response) {
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        }).catch(error => {
            console.error(error);
        });;
    }

    function AddCadetScoutingDetails() {
        var formDataList = $("#kt_form_extra_curricular_cadet_scouting_det").serializeArray();
        var formDataAll = JSON.stringify(formDataList);

        $.ajax({
            url: "/User/AddCadetScoutingDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: formDataAll,
            traditional: true,
            async: true,
            dataType: "json",
            headers: {
                "RequestVerificationToken":
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                if (response.response.status == -1) {
                    Swal.fire({
                        title: 'Warning',
                        text: response.response.message,
                        icon: response.response.errorType,
                        confirmButtonColor: '#3e7dfa',
                    });
                }
                else {
                    _wizardObj.goNext();
                    KTUtil.scrollTop();
                    //window.location.href = (response.newUrl);
                }
            },
            error: function (response) {
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        }).catch(error => {
            console.error(error);
        });;
    }

    function AddSportsDetails() {

        var formDataAll = JSON.stringify(_Sports);

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '/User/AddSportsDetails',
            data: formDataAll,
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                if (response.response.status == -1) {
                    Swal.fire({
                        title: 'Warning',
                        text: response.response.message,
                        icon: response.response.errorType,
                        confirmButtonColor: '#3e7dfa',
                    });
                }
                else {
                    _wizardObj.goNext();
                    KTUtil.scrollTop();
                }
            },
            error: function (response) {
                console.log(response);
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        });

    }

    function AddParentGuardianDetails() {
        var formDataList = $("#kt_form_parent_and_guardian_det").serializeArray();
        var formDataAll = JSON.stringify(formDataList);

        $.ajax({
            url: "/User/AddParentGuardianDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: formDataAll,
            traditional: true,
            async: true,
            dataType: "json",
            headers: {
                "RequestVerificationToken":
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                if (response.response.status == -1) {
                    Swal.fire({
                        title: 'Warning',
                        text: response.response.message,
                        icon: response.response.errorType,
                        confirmButtonColor: '#3e7dfa',
                    });
                }
                else {

                    Swal.fire({
                        text: "All is good!",
                        icon: "success",
                        confirmButtonText: "Ok!",
                    })

                    location.reload();
                    //window.location.href = (response.newUrl);
                }
            },
            error: function (response) {
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        }).catch(error => {
            console.error(error);
        });;

    }

    function GetSports() {
        $.ajax({
            url: "/User/GetSports",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            traditional: true,
            async: true,
            dataType: "json",
            beforeSend: function () {
                KTApp.blockPage();
            },
            success: function (response) {
                $.each(response, function (key, value) {
                    $("#sports").append($('<option>', {
                        value: value.sportId,
                        text: value.sportName,
                    }));
                });
            },
            error: function (response) {
                Swal.fire({
                    title: 'OOps!',
                    text: "Error Occured",
                    icon: "error",
                    confirmButtonColor: '#3e7dfa',
                })
            },
            complete: function () {
                KTApp.unblockPage();
            }
        }).catch(error => {
            console.error(error);
        });;
    }

    $(document).on("click", ".add-sport", function (event) {

        var SL = $('#SL').prop('checked');
        var SC = $('#SC').prop('checked');
        var ZL = $('#ZL').prop('checked');
        var DL = $('#DL').prop('checked');
        var PL = $('#PL').prop('checked');
        var PNL = $('#PNL').prop('checked');

        var pl_in_nl = $('#pl_in_nl').val();
        var nc = $('#nc').val();
        var rsl_of_o = $('#rsl_of_o').val();
        var sport_id = $('#sports').val();
        var sports_name = $('#sports option:selected').text();

        if (SL == false && SC == false && ZL == false && DL == false && PL == false && PNL == false && pl_in_nl == "None" && nc == "None" && rsl_of_o == "None") {
            Swal.fire({
                title: 'Warning',
                text: 'Please select at least 1 options',
                icon: "error",
                confirmButtonColor: '#8950FC',
            });
            return;
        }
        else {
            sportItem = new SportModel(sports_name, sport_id, SL, SC, ZL, DL, PL, PNL, pl_in_nl, nc, rsl_of_o);
            if (!IsExist(sport_id)) {
                _Sports.push(sportItem);
                GenerateTable();
                $('#sportModal').modal('hide')
            }
            else {
                Swal.fire({
                    title: 'Warning',
                    text: 'Sport already exist',
                    icon: "error",
                    confirmButtonColor: '#8950FC',
                });
                return;
            }
        }

    });

    function IsExist(sport_id) {
        var isexist = false;

        for (var i = 0; i < _Sports.length; i++) {

            if (_Sports[i].sport_id == sport_id) {
                isexist = true;
            }

        }
        return isexist;
    }

    function RemoveSport(sport_id) {
        for (var i = 0; i < _Sports.length; i++) {

            if (_Sports[i].sport_id == sport_id) {
                _Sports.splice(i, 1);
            }
        }
        GenerateTable();
    }

    $(document).on("click", ".btn-remove-sport", function (event) {
        var sport_id = event.target.id;
        RemoveSport(sport_id);

    });

    function GenerateTable() {
        var tr;
        $('#sport_list').html('');
        for (var i = 0; i < _Sports.length; i++) {

            tr = $('<tr/>');

            tr.append("<td>" + _Sports[i].sports_name + "</td>");

            if (_Sports[i].sl == true) {
                tr.append("<td> <i class='flaticon2-check-mark'></i></td>");
            }
            else {
                tr.append("<td> <i class='flaticon2-cross'></i></td>");
            }

            if (_Sports[i].sc == true) {
                tr.append("<td> <i class='flaticon2-check-mark'></i></td>");
            }
            else {
                tr.append("<td> <i class='flaticon2-cross'></i></td>");
            }

            if (_Sports[i].zl == true) {
                tr.append("<td> <i class='flaticon2-check-mark'></i></td>");
            }
            else {
                tr.append("<td> <i class='flaticon2-cross'></i></td>");
            }

            if (_Sports[i].dl == true) {
                tr.append("<td> <i class='flaticon2-check-mark'></i></td>");
            }
            else {
                tr.append("<td> <i class='flaticon2-cross'></i></td>");
            }

            if (_Sports[i].pl == true) {
                tr.append("<td> <i class='flaticon2-check-mark'></i></td>");
            }
            else {
                tr.append("<td> <i class='flaticon2-cross'></i></td>");
            }

            if (_Sports[i].pnl == true) {
                tr.append("<td> <i class='flaticon2-check-mark'></i></td>");
            }
            else {
                tr.append("<td> <i class='flaticon2-cross'></i></td>");
            }

            tr.append("<td>" + _Sports[i].pl_in_nl + "</td>");
            tr.append("<td>" + _Sports[i].nc + "</td>");
            tr.append("<td>" + _Sports[i].rsl_of_o + "</td>");
            tr.append("<td>" + "<button type='button' class='btn btn-danger btn-sm btn-remove-sport' id=" + _Sports[i].sport_id + ">REMOVE</button>" + "</td>");

            $('#sport_list').append(tr);

        }

        if (_Sports.length == 0) {
            $('#sport_list').html('');
            var tr;
            tr = $('<tr/>');
            tr.append("<td align='center' colspan='11'>No sports added</td></tr>");
            $('#sport_list').append(tr);
        }
    }
});



class SportModel {
    constructor(sports_name, sport_id, sl, sc, zl, dl, pl, pnl, pl_in_nl, nc, rsl_of_o) {
        this.sports_name = sports_name;
        this.sport_id = sport_id;
        this.sl = sl;
        this.sc = sc;
        this.zl = zl;
        this.dl = dl;
        this.pl = pl;
        this.pnl = pnl;
        this.pl_in_nl = pl_in_nl;
        this.nc = nc;
        this.rsl_of_o = rsl_of_o;
    }
}