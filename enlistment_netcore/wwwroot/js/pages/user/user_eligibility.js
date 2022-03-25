$(document).ready(function () {

    getSubjects();
    var _formEligibility;
    var _validationEligiblityDetails;

    Init();
    initEligiblityValidation();

    function Init() {
        _formEligibility = KTUtil.getById('eligibiity_form');
    }

    function initEligiblityValidation() {
        _validationEligiblityDetails = FormValidation.formValidation(
            _formEligibility,
            {
                fields: {
                    nic_passport: {
                        validators: {
                            notEmpty: {
                                message: 'NIC/Passport required'
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
                    general_english_marks: {
                        validators: {
                            notEmpty: {
                                message: 'General marks is required'
                            }
                        }
                    },
                    maths_ol_index: {
                        validators: {
                            notEmpty: {
                                message: 'Index no is required'
                            }
                        }
                    },
                    science_ol_index: {
                        validators: {
                            notEmpty: {
                                message: 'Index no is required'
                            }
                        }
                    },
                    sinhalatamil_ol_index: {
                        validators: {
                            notEmpty: {
                                message: 'Index no is required'
                            }
                        }
                    },
                    english_ol_index: {
                        validators: {
                            notEmpty: {
                                message: 'Index no is required'
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



    function getSubjects() {
        $.ajax({
            url: "/User/GetAlsubjectsByStream",
            type: "GET",
            data: { stream: $('#stream').val() },
            async: true,
            beforeSend: function () {
                //KTApp.blockPage();
            },
            complete: function () {
                KTApp.unblockPage();
            },
            success: function (data) {
                $("#al_subject1").empty();
                $("#al_subject2").empty();
                $("#al_subject3").empty();

                for (i = 0; i < data.value.length; i++) {
                    $('#al_subject1').append($('<option>', {
                        value: data.value[i].id,
                        text: data.value[i].subjectName
                    }));
                    $('#al_subject2').append($('<option>', {
                        value: data.value[i].id,
                        text: data.value[i].subjectName
                    }));
                    $('#al_subject3').append($('<option>', {
                        value: data.value[i].id,
                        text: data.value[i].subjectName
                    }));
                }
            },
            error: function (response) {

            },
            complete: function () {
                $('#btnSubmit').removeAttr('disabled');
            }
        })

    }

    $("#eligibiity_form").submit(function (event) {
        event.preventDefault();


        _validationEligiblityDetails.validate().then(function (status) {
            if (status == 'Valid') {
                var formDataList = $("#eligibiity_form").serializeArray();

                for (var i = 0; i < formDataList.length; i++) {
                    if (isEmpty(formDataList[i].value)) {
                        isValid = false;
                    }
                }
                var formDataAll = JSON.stringify(formDataList);

                $('#btnSubmit').attr('disabled', 'disabled');

                $.ajax({
                    url: "/User/GetEligibileDegrees",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: formDataAll,
                    traditional: true,
                    async: false,
                    dataType: "json",
                    headers: {
                        "RequestVerificationToken":
                            $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    success: function (response) {
                        Swal.fire({
                            title: 'Warning',
                            text: response.data,
                            icon: response.data.errorType,
                            confirmButtonColor: '#3e7dfa',
                        })
                        //alert(response);
                        //if (response.data.errorStatus == 0) {
                        //    Swal.fire({
                        //        title: 'Warning',
                        //        text: response.data.errorMessage,
                        //        icon: response.data.errorType,
                        //        confirmButtonColor: '#3e7dfa',
                        //    })
                        //} else {
                        //    //window.location.href = (response.newUrl);
                        //}
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
                        $('#btnSubmit').removeAttr('disabled');
                    }
                })

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
    });





    $('#stream').on('change', function () {
        getSubjects();
    });


    function isEmpty(value) {
        return typeof value == 'string' && !value.trim() || typeof value == 'undefined' || value === null;
    }
});
