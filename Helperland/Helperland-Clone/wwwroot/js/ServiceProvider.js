function openTab(evt, tabName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active";
}


$(document).ready(function () {
    // Get the element with id="defaultOpen" and click on it
    document.getElementById("defaultOpen").click();
});

$(document).ready(function () {
    $("#myTab li:eq(0) a").tab("show"); // show second tab (0-indexed, like an array)

});

function selectAvatar(e) {
    var elems = document.querySelectorAll(".columnAvatar .active");
    [].forEach.call(elems, function (el) {
        el.classList.remove("active");
    });
    e.target.classList.add("active");
    document.getElementById("currentAvatar").src = e.target.src;
}

$(document).ready(function () {
    $('#upcomingServicesTable').DataTable({
        paging: true,
        "pagingType": "full_numbers",
        // bFilter: false,
        ordering: true,
        searching: false,
        info: true,
        "columnDefs": [
            { "orderable": false, "targets": 4 }
        ],
        "oLanguage": {
            "sInfo": "Total Records: _TOTAL_"
        },
        "dom": '<"top">rt<"bottom"lip><"clear">',
        responsive: true,
        "order": []
    });
});


/* ------------------------------------------------------------------------------ */



//var vTabId = "NewServiceRequestTabBtn";
//var url1 = new URLSearchParams(window.location.search);
//var urlcust = url1.toString();
//if (urlcust.includes("=")) {
//    var indexofequl = urlcust.lastIndexOf("=");
//    vTabId = urlcust.substring(indexofequl + 1, urlcust.length);
//}
//document.getElementById(vTabId).click();



/* ---- new serviceereq ----------   */
/*-- row click in new Service req */
/*var serviceId = "";
$("#newServiceRequestTable").click(function (e) {
    serviceId = e.target.closest("tr").getAttribute("data-value");
    if (serviceId != null && e.target.classList != "newReqConflictBtn") {
        document.getElementById("spServiceDetails").click();
        $('#spServiceDetails').modal('show');
    }
});

document.getElementById("spServiceDetails").addEventListener("click", function () {
    getAllServiceDetails();
});

function getAllServiceDetails() {
    var data = {};
    data.ServiceId = parseInt(serviceId);
    $.ajax({
        type: 'GET',
        url: '/ServiceProvider/getAllDetails',
        contentType: 'application/x-www-form-urlencoded; charset=UTF - 8', 
        data: data,
        success: function (result) {
            if (result != null) {
                showAllServiceRequestDetails(result);
            }
            else {
                alert("result is null");
            }
        },
        error: function () {
            alert("error");
        }
    });
}
*/
var ServiceID = "";
$(document).ready(function () {
    $("#newServiceRequests tr,#upcomingServicesTable tr").click(function () {
        //console.log("in fun");
        $("#sExtra").html("");
        //console.log($("#sExtra").text());

        var data1 = $(this).find(".serviceId");
        var serviceId = $(data1).text();
        $("#sId").text(serviceId);

        ServiceID = serviceId;

        var data2 = $(this).find(".serviceDate");
        var serviceDate = $(data2).text();
        $("#sDate").text(serviceDate);

        var data3 = $(this).find(".serviceTime");
        var serviceTime = $(data3).text();
        $("#sTime").text(serviceTime);

        //var data4 = $(this).find("input:hidden[class='totleTime']");
        var data4 = $(this).find(".totleTime");
        var totalTime = $(data4).text();
        $("#sDuration").text(totalTime);

        var data5 = $(this).find(".netAmt");
        var netAmt = $(data5).text();
        $("#netAmount").text(netAmt);

        var data6 = $(this).find(".custName");
        var custName = $(data6).text();
        $("#cName").text(custName);

        var data7 = $(this).find(".serviceAddress");
        var serviceAddress = $(data7).text();
        $("#sAddress").text(serviceAddress);

        var data8 = $(this).find(".extraCabinet");
        var extraCabinet = $(data8).text();
        //console.log(extraCabinet);
        if (extraCabinet == "True") {
            $("#sExtra").append("<p>Extra Cabinet</p>");
        }

        var data9 = $(this).find(".extraOven");
        var extraOven = $(data9).text();
        if (extraOven == "True") {
            $("#sExtra").append("<p>Inside Oven</p>");
        }

        var data10 = $(this).find(".extraWindow");
        var extraWindow = $(data10).text();
        if (extraWindow == "True") {
            $("#sExtra").append("<p>Interior Window</p>");
        }

        var data11 = $(this).find(".extraFridge");
        var extraFridge = $(data11).text();
        if (extraFridge == "True") {
            $("#sExtra").append("<p>Inside Fridge</p>");
        }

        var data12 = $(this).find(".extraLaundry");
        var extraLaundry = $(data12).text();
        if (extraLaundry == "True") {
            $("#sExtra").append("<p>Laundry Wash & dry</p>");
        }

        var data13 = $(this).find(".serviceZip");
        var zipCode = $(data13).text();
        getMap(zipCode);


    });
});

/*---map ----*/
function getMap(zipcode) {
    var embed = "<iframe width='100%25' height='100%25'  frameborder='0'  scrolling='no' marginheight='0' marginwidth='0'     src='https://maps.google.com/maps?&amp;q=" + encodeURIComponent(zipcode) + "&amp;output=embed'><a href='https://www.gps.ie/car-satnav-gps/'>sat navs</a></iframe>";
    $('#newServiceReqMap').html(embed);
}

//function showAllServiceRequestDetails(result) {
//    var dateTime = document.getElementById("SpServiceReqDatetime");
//    var duration = document.getElementById("SpServiceReqDuration");
//    document.getElementById("SpServiceReqId").innerHTML = serviceRequestId;
//    var extra = document.getElementById("SpServiceReqExtra");
//    var amount = document.getElementById("SpServiceReqAmount");
//    var customerName = document.getElementById("SpServiceReqCustomerName");
//    var address = document.getElementById("SpServiceReqAddress");
//    var comment = document.getElementById("SpServiceReqComment");
//    var Status = document.getElementById("SpServiceReqStatus");
//    dateTime.innerHTML = result.date.substring(0, 10) + " " + result.startTime + " - " + result.endTime;
//    duration.innerHTML = result.duration + " Hrs"; extra.innerHTML = "";
//    var dashbtn = "";
//    var servicehistorybtn = "";
//    switch (result.status) {
//        case 1: /*new */
//            dashbtn = "";
//            servicehistorybtn = "d-none";
//            break;
//        case 2: /*pending */
//            dashbtn = "d-none";
//            servicehistorybtn = ""; break;
//        //case 3: /*completed */                   
//        //    dashbtn = "d-none";        
//        //    servicehistorybtn = "";        
//        //    break;        
//        //case 4: /*cancelled*/                   
//        //    dashbtn = "d-none";        
//        //    servicehistorybtn = "d-none";        
//        //    break;        
//        default: /*other status */
//            alert("invalid status ")
//    }
//    document.getElementById("detailPopUpNew").className = dashbtn;
//    document.getElementById("detailPopUpUpComing").className = servicehistorybtn;
//    if (result.cabinet == true) {
//        extra.innerHTML += "<div class='extraElement '> Inside Cabinet </div> ";
//    }
//    if (result.laundry == true) {
//        extra.innerHTML += "<div class='extraElement'>  Laundry Wash & dry </div> ";
//    }
//    if (result.oven == true) {
//        extra.innerHTML += "<div class='extraElement'>  Inside Oven  </div> ";
//    }
//    if (result.fridge == true) {
//        extra.innerHTML += " <div class='extraElement'> Inside </div>  ";
//    }
//    if (result.window == true) {
//        extra.innerHTML += "<div class='extraElement'>  Interior Window</div> ";
//    }
//    amount.innerHTML = result.totalCost + " &euro;";
//    address.innerHTML = result.address;
//    customerName.innerHTML = result.customerName;
//    comment.innerHTML = "";
//    getMap(result.zipCode);
//    if (result.comments != null) {
//        comment.innerHTML = result.comments;
//    }
//}




$(document).ready(function () {
    $("#newServiceReqAccept").on('click', function () {
        var data = {};
        data.ServiceId = parseInt(ServiceID);
        console.log(data);
        $.ajax({
            type: 'GET',
            url: '/ServiceProvider/acceptService',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                if (result == "Suceess") {
                    document.getElementById("acceptAlert").click();
                    $('#NewServiceAcceptStatus').text("Service accepted").css("color", "Green");
                    window.setTimeout(function () {
                        $("#alertPopup").modal("hide");
                        window.location.reload();
                    },
                        3000);
                }
                else if (result == "Service Req Not available") {
                    document.getElementById("acceptAlert").click();
                    $('#NewServiceAcceptStatus').text("Service Req Not available").css("color", "Gray");
                    window.setTimeout(function () {
                        $("#alertPopup").modal("hide");
                        window.location.reload();
                    },
                        3000);
                }
                else if (result == "error") {
                    document.getElementById("acceptAlert").click();
                    $('#NewServiceAcceptStatus').text("error occured").css("color", "Red");
                    window.setTimeout(function () {
                        $("#alertPopup").modal("hide");
                        window.location.reload();
                    },
                        3000);
                }
                else {
                    document.getElementById("acceptAlert").click();
                    $('#NewServiceAcceptStatus').text("Another service request " + result + " has already been assigned which has time overlap with this service request.You can’t pick this one!").css("color", "Red");
                    var conflictbtn = "#Conflict" + ServiceID;
                    $(conflictbtn).removeClass('d-none');
                    window.setTimeout(function () {
                        $("#alertPopup").modal("hide");
                    },
                        3000);
                    alert(result);
                }
            },
            error: function () {
                alert("error");
            }
        });
    });
});

$(".newReqConflictBtn").on('click', function () {
    var temp = this.id.toString();
    var id = temp.substring(8, temp.length);
    var data = {};
    data.ServiceRequestId = parseInt(id);
    $.ajax({
        type: 'GET',
        url: '/ServiceProvider/ConflictDetails',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            document.getElementById("acceptAlert").click();
            $('#NewServiceAcceptStatus').text(result).css("color", "Red");
            //var conflictbtn = "#Conflict" + serviceRequestId;            
            //$(conflictbtn).addClass('d-none');            
            window.setTimeout(function () { $("#alertPopup").modal("hide"); }, 5000);
        }, error: function () { alert("error"); }
    });
});

$(document).ready(function () {
    $("#upcomingServicesTable").click(function (e) {
        serviceRequestId = e.target.closest("tr").getAttribute("data-value");
        //alert(serviceRequestId);
        if (e.target.classList.contains("completeService")) {
            document.getElementById("completedRequestId").value = serviceRequestId;
            //alert("In if");
            //alert(document.getElementById("updateRequestId").value);
        }
        if (e.target.classList.contains("cancelService")) {
            document.getElementById("cancelRequestId").value = serviceRequestId;
            //alert("In if");
        }
    });
});

//$(document).ready(function () {
//    $("#serviceHistoryTable").click(function (e) {
//        serviceRequestId = e.target.closest("tr").getAttribute("data-value");
//        //alert(serviceRequestId);
//        if (e.target.classList.contains("completeService")) {
//            document.getElementById("completedRequestId").value = serviceRequestId;
//            //alert("In if");
//            //alert(document.getElementById("updateRequestId").value);
//        }
//        if (e.target.classList.contains("cancelService")) {
//            document.getElementById("cancelRequestId").value = serviceRequestId;
//            //alert("In if");
//        }
//    });
//});

$(document).ready(function () {
    $("#completeServiceRequest").on('click', function () {
        console.log("Clicked");
        var ServiceRequestId = document.getElementById("completedRequestId").value;
        alert(ServiceRequestId);
        var data = {};
        data.serviceId = ServiceRequestId;
     
        alert(data.serviceId);
        $.ajax({
            type: 'POST',
            url: '/ServiceProvider/CompletedService',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                if (result == "Success") {
                    alert("Success");
                    var data1 = $('#' + ServiceRequestId).find(".serviceId");
                    var Id = $(data1).text();

                    var data2 = $('#' + ServiceRequestId).find(".serviceDate");
                    var Date = $(data2).text();

                    var data3 = $('#' + ServiceRequestId).find(".serviceTime");
                    var Time = $(data3).text();

                    var data4 = $('#' + ServiceRequestId).find(".custName");
                    var CustomerName = $(data4).text();

                    var data5 = $('#' + ServiceRequestId).find(".serviceAddress");
                    var Address = $(data5).text();

                    var newRow = '<tr data-value="' + Id  + '" id="' + Id + '">' +
                        '<th scope = "row" class="align-middle" data-bs-toggle="modal" data-bs-target="#spServiceDetails" >' +
                            '<p><span class="serviceId">' + Id + '</span></p>' +
                                    '</th>'+
                        '<td class="align-middle" data-bs-toggle="modal" data-bs-target="#spServiceDetails">' +
                            '<p><img src="/images/calendar2.png" style="margin-bottom: 7px">' +
                                '<b><span class="serviceDate">' + Date + '</span></b><br>' +
                                    '<img src="/images/layer-14.png"> <span class="serviceTime">' + Time + '</span></p>'+
                                    '</td>' +
                                '<td class="align-middle" data-bs-toggle="modal" data-bs-target="#spServiceDetails">' +
                                    '<p><span class="custName">' + CustomerName + '</span><br>' +
                                        '<img src="/images/layer-15.png" style="vertical-align: text-bottom;">' +
                                            '<span class="serviceAddress">' + Address + '</span></p>' +
                                    '</td>'+
                        '</tr>';
                    $('#serviceHistoryTable').append(newRow);
                    $('#' + ServiceRequestId).addClass("d-none");

                }
                else if (result == "error") {
                    alert("Failed");
                    BootstrapAlert("divStatusFailedBootstrapAlert", "Update Failed!!", "alert");
                }
            },
            error: function () {
                alert("error");
            }
        });
    });
});

$(document).ready(function () {
    $("#cancelServiceRequest").on("click", function () {
       
        var ServiceRequestId = document.getElementById("cancelRequestId").value;
        var Comments = document.getElementById("cancelReason").value;
        var data = {};
        data.serviceId = ServiceRequestId;
        data.comments = Comments;
        console.log(ServiceRequestId);
        $.ajax({
            type: 'POST',
            url: '/ServiceProvider/CancelServiceRequest',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                if (result.value == "true") {
                    window.location.reload();
                }
                else {
                    alert("fail");
                }
            },
            error: function () {
                alert("error");
            }
        });
    });
});

//$(document).on('click', '#UpcomingServiceTabBtn', function () {
//    getUpcomingServiceTable()
//});

//function getUpcomingServiceTable() {
//    $.ajax({
//        type: "GET",
//        url: '/ServiceProvider/getUpcomingService',
//        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
//        success: function (result) {
//            $('#UpcomingServiceTbody').empty();
//            for (var i = 0; i < result.length; i++) {
//                $('#UpcomingServiceTbody').append('<tr class="text-center" data-value=' + result[i].serviceRequestId +
//                    ' >< td data - label="Service ID" > ' +
//                    ' < p class= "margin" > ' + result[i].serviceRequestId +
//                    '</p ></td > ' + ' < td data - label="Service date" > <div><img src="/image/calendar2.png" alt="calender">' +
//                    result[i].date + ' </div>' +
//                    '<div><img src="/image/layer-14.png" alt="clock">' + result[i].startTime + '-' + result[i].endTime + '</td></div>' +
//                    '<td class="text-start" data-lable="Customer Details"><div class="ms-4">' + result[i].customerName + '</div >' + '<div class="d-flex" ><span><img class="me-0" src="/image/layer-15.png" alt=""></span> <span>' + result[i].address + ' </span></div></td>' +
//                    '<td data-label="Completed"> <p class="margin" > <button class="CompleteService d-none">Complete</button></P></td >' +
//                    '<td data-label="Action"><p class="margin"><button class="upcomingcancel" data-bs-toggle="modal" data-bs-target="#SPdeleteModelServiceRequest">Cancel</button></P>	</td></tr >')
//            } upcomingserviceDatatable();
//        }, error: function (error) { console.log(error); }
//    });
//}

//$("#SPUpcomingServiceTable").click(function (e) {
//    serviceRequestId = e.target.closest("tr").getAttribute("data-value");
//    if (serviceRequestId != null && e.target.classList != "upcomingcancel") {
//        document.getElementById("spserviceReqdetailsbtn").click();
//    }
//});

//document.getElementById("SpCancelRequestBtn").addEventListener("click", function () {
//    var data = {};
//    data.serviceRequestId = serviceRequestId;
//    $.ajax({
//        type: 'POST',
//        url: '/ServiceProvider/cancelRequest',
//        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//        data: data,
//        success: function (result) {
//            if (result == "Suceess") {
//                window.location.reload();
//            }
//            else { alert("fail"); }
//        },
//        error: function () {
//            alert("error");
//        }
//    });
//});

function isValidDate(year, month, day) {
    var d = new Date(year + "-" + AppendZero(month) + "-" + AppendZero(day));
    if (d.getFullYear().toString() == year && (d.getMonth() + 1).toString() == month && d.getDate().toString() == day) {
        return true;
    }
    return false;
}

//append 0 to single digit number for month and date
function AppendZero(input) {
    if (input.length == 1) {
        return '0' + input;
    }
    return input;
}

$(document).ready(function () {
    $("#UpdateSpProfile").on("click", function () {
        //console.log("in update");
        var regularExpressionPhoneNumber = new RegExp("^[0-9]{10}$");
        var regularExpressionPostalCode = new RegExp("^[0-9]{6}$")
        if ($("#FirstName").val().toString().trim() == "") {
            $("#ErrorMessageFirstName").html("Please Enter First Name");
        }
        else {
            $("#ErrorMessageFirstName").html("");
        }
        if ($("#LastName").val().toString().trim() == "") {
            $("#ErrorMessageLastName").html("Please Enter Last Name");
        }
        else {
            $("#ErrorMessageLastName").html("");
        }
        if ($("#MobileNumber").val().toString().trim() == "") {
            $("#ErrorMessageMobileNumber").html("Please Enter Last Name");
        }
        else if (!regularExpressionPhoneNumber.test($('#MobileNumber').val())) {
            $('#ErrorMessageMobileNumber').html("Please Enter Valid Phone number.");
        }
        else {
            $("#ErrorMessageMobileNumber").html("");
        }
        if ($("#streetName").val().toString().trim() == "") {
            $("#ErrorMessageStreetName").html("Please Enter Street Name");
        }
        else {
            $("#ErrorMessageStreetName").html("");
        }
        if ($("#houseNumber").val().toString().trim() == "") {
            $("#ErrorMessageHouseNumber").html("Please Enter House Number");
        }
        else {
            $("#ErrorMessageHouseNumber").html("");
        }
        if ($("#postalCode").val().toString().trim() == "") {
            $("#ErrorMessagePostalCode").html("Please Enter Postal Code");
        }
        else if (!regularExpressionPostalCode.test($('#postalCode').val())) {
            $('#ErrorMessagePostalCode').html("Please Enter Valid Postal Code");
        }
        else {
            $("#ErrorMessagePostalCode").html("");
        }
        var dobDay = $("#DayDOB").val().toString().trim();
        var dobMonth = $("#MonthDOB").val().toString().trim();
        var dobYear = $("#YearDOB").val().toString().trim();
        var dobErrorMessage = "Please enter Valid Birth Date";
        console.log(dobErrorMessage);
        console.log($("#ErrorMessageMobileNumber").text());
        if (dobDay != "" || dobMonth != "" || dobYear != "") {
            if (!isValidDate(dobYear, dobMonth, dobDay)) {
                $("#ErrorMessageDateOfBirth").html("Please enter Valid Birth Date");
            }
            else {
                $("#ErrorMessageDateOfBirth").html("");
            }
        }
        //console.log($("#ErrorMessageDateOfBirth").text());
        //console.log($("#ErrorMessageFirstName").text());
        //console.log($("#ErrorMessageLastName").html());
        if ($("#ErrorMessageFirstName").html() != "" || $("#ErrorMessageLastName").html() != "" || $("#ErrorMessageMobileNumber").html() != "" || $("#ErrorMessageDateOfBirth").html() != "") {
            return;
        }
        
        var profileDetail = {};
        //console.log($("#FirstName").val());
        //console.log($("#LastName").val());
        //console.log($("#MobileNumber").val());
        profileDetail.firstName = $("#FirstName").val().toString().trim();
        profileDetail.lastName = $("#LastName").val().toString().trim();
        profileDetail.Mobile = $("#MobileNumber").val().toString().trim();
       
        if ($("#ErrorMessageDateOfBirth").html() == "") {
            profileDetail.dateOfBirth = new Date($("#YearDOB").val() + "-" + $("#MonthDOB").val() + "-" + $("#DayDOB").val());
        }

        profileDetail.addressLine1 = $("#streetName").val().toString().trim();
        profileDetail.addressLine2 = $("#houseNumber").val().toString().trim();
        profileDetail.zipCode = $("#postalCode").val().toString().trim();
        console.log($("#postalCode").val());
        profileDetail.city = $("#cityName").val().toString().trim();

       
        $.ajax({
            url: '/ServiceProvider/UpdateSpProfileDetail',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(profileDetail),
            success: function (resp) {
                $('#preloader').addClass("d-none");
                if (resp.status == "ok") {
                    alert("updated");
                    LoadSpProfileDetail();
                    BootstrapAlert("divMyDetailTabBootstrapAlert", "Profile Update successfully.", "success");
                }

            },
            error: function (err) {
                alert("error");
                console.log(err);
            }
        });
    });
});

//Bootstrap alert
function BootstrapAlert(id, message, type) {
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    $('#' + id).html(wrapper);
}

$(document).ready(function () {
    LoadSpProfileDetail();
    //LoadCustomerAddresses();
});
function LoadSpProfileDetail() {
    $.ajax({
        url: '/ServiceProvider/GetSpDetail',
        type: 'post',
        dataType: 'json',
        success: function (resp) {
            if (resp.status == "ok") {
                $("#FirstName").val(resp.result.firstName);
                $("#LastName").val(resp.result.lastName);
                $("#Email").val(resp.result.email);
                $("#MobileNumber").val(resp.result.mobile);
                if (resp.result.dateOfBirth != null) {
                    var dob = new Date(resp.result.dateOfBirth);
                    $("#DayDOB").val(dob.getDate());
                    $("#MonthDOB").val((dob.getMonth() + 1).toString());
                    $("#YearDOB").val(dob.getFullYear());
                }
                if (resp.result.languageId != null) {
                    $("#Language").val(resp.result.languageId);
                }
                $("#streetName").val(resp.result.addressLine1);
                $("#houseNumber").val(resp.result.addressLine2);
                $("#postalCode").val(resp.result.zipCode);
                $("#cityName").val(resp.result.city);
            }
        },
        error: function (err) {
            alert("error");
            console.log(err);
        }
    });
}


$(document).ready(function () {
    $("#UpdateSpPassword").on("click", function () {
        console.log("Clicked");
        var RegExpressPassword = new RegExp("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@@$%^&*-]).{6,16}$");
        if ($("#SpCurrentPassword").val().toString().trim() == "") {
            $("#ErrorMessageSpCurrentPassword").html("Please Enter Current Password");
        }
        else {
            $("#ErrorMessageSpCurrentPassword").html("");
        }
        if ($("#SpNewPassword").val().toString().trim() == "") {
            $("#ErrorMessageSpNewPassword").html("Please Enter New Password");
        }
        else if (!RegExpressPassword.test($("#SpNewPassword").val())) {
            $('#ErrorMessageSpNewPassword').html("You must enter At least one upper case, one lower case, one digit and Minimum 6 and Maximum 16 in length");
        }
        else {
            $("#ErrorMessageSpNewPassword").html("");
        }
        if ($("#SpConfirmPassword").val().toString().trim() == "") {
            $("#ErrorMessageSpConfirmPassword").html("Please Enter Confirm Password");
        }
        else if ($("#SpNewPassword").val().toString().trim() != $("#SpConfirmPassword").val().toString().trim()) {
            $("#ErrorMessageSpConfirmPassword").html("New Password and Confirm Password do not match");
        }
        else {
            $("#ErrorMessageSpConfirmPassword").html("");
        }
        //console.log($("#ErrorMessageSpCurrentPassword").text());
        //console.log($("#ErrorMessageSpNewPassword").text());
        //console.log($("#ErrorMessageSpConfirmPassword").html());
        if ($("#ErrorMessageSpCurrentPassword").html() != "" || $("#ErrorMessageSpNewPassword").html() != "" || $("#ErrorMessageSpConfirmPassword").html() != "") {
            return;
        }
        var user = {};
        user.password = $("#SpCurrentPassword").val().toString().trim();
        user.newPassword = $("#SpNewPassword").val().toString().trim();
        $('#preloader').removeClass("d-none");
        //console.log("AJAX");
        $.ajax({
            url: '/ServiceProvider/UpdateSpPassword',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(user),
            success: function (resp) {
                $('#preloader').addClass("d-none");
                if (resp.status == "ok") {
                    BootstrapAlert("divChangePasswordTabBootstrapAlert", "Update password successfully.", "success");
                    $("#SpCurrentPassword").val("");
                    $("#SpNewPassword").val("");
                    $("#SpConfirmPassword").val("");
                }
                else {
                    BootstrapAlert("divChangePasswordTabBootstrapAlert", resp.errorMessage, "danger");
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});



/* rating */
$(document).on('click', '#MyRatingTab', function () {
    $.ajax({
        type: 'GET',
        url: '/ServiceProvider/getRatingData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (result) {
            $('#RatingList').empty();
            for (var i = 0; i < result.length; i++) {
                var star = "";
                for (var j = 1; j < 6; j++) {
                    if (j <= result[i].rating) {
                        star += '<img src="/images/star1.png" alt="">';
                    }
                    else {
                        star += '<img src="/images/star2.png" alt="">'
                    }                                       
                }
                star += '<span> &nbsp;' + result[i].remarks + '</span>'
                $('#RatingList').append('<div class="row  rating-row"><div class="row">' +
                     '<div class= "col-3" > ' +
                     '<p>' + result[i].serviceRequestId + '</p>' +
                     '<p>' + result[i].customerName + '</p></div><div class="col-5">' +
                     '<p> <span><img src="/images/calendar2.png" alt=""></span> <span class="upcoming-date"><b>' + result[i].serviceDate + '</b></span></p>' +
                     ' <p><span><img src="/images/layer-14.png" alt=""></span><span>' + result[i].startTime + ' - ' + result[i].endTime + '</span></p></div>' +
                     '<div class="col-4"><p>Rating</p>' +
                     '<div class="star-ratingmodel text-start">' + star + '</div></div></div><hr />' +
                     '<div class="row"><p><b>Customer Comments</b></p><p>' + result[i].comments + '</p></div></div>'
                );


                                        
            }
        },
        error: function () {
            alert("Error");
        }
    });
});


/* Block customer */
$(document).on('click', '#BlockCustomerTab', function () {
    $.ajax({
        type: "GET",
        url: '/ServiceProvider/getCustomer',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (result) {
            $('#customerGrid').empty();
            for (var i = 0; i < result.length; i++) {
                var unblock = "d-none";
                var block = "";
                if (result[i].favoriteAndBlocked != null) {

                    var status = result[i].favoriteAndBlocked.isBlocked;
                    if (status == true) {
                        block = "d-none";
                        unblock = "";

                    }
                }
                $('#customerGrid').append('<div class="col-sm-4">' + '<div class="favourite-pro">' +
                    '<img class= "cap-icon" src = "/images/cap.png " alt = ".." >' +
                    '<div class="sp-details"> <span class="name"> ' + result[i].user.firstName +' ' + result[i].user.lastName + '  </span>' + '</div>' +
                    '<button id="' + result[i].user.userId + 'B" class="' + block + ' btn btn-danger block-cust-btn">Block</button>' +
                    '<button id="' + result[i].user.userId + 'U" class="' + unblock + ' btn btn-danger block-cust-btn block-cust-btn">Un-Block</button>' +
                    '</div > </div>' );
            }
        }, error: function (error) {
            console.log(error);
        }
    });
});

$(document).on('click', '.block-cust-btn', function () {
    var combine = this.id;
    var req = combine.substring(combine.length - 1, combine.length);
    var Id = combine.substring(0, combine.length - 1);
    var data = {};
    data.Id = parseInt(Id);
    data.Req = req;
    $.ajax({
        type: 'GET',
        url: '/ServiceProvider/BlockUnblockCustomer',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            document.getElementById("BlockCustomerTab").click();
            document.getElementById("acceptAlert").click();
            $('#NewServiceAcceptStatus').text(result).css("color", "Grey");
            window.setTimeout(function () {
                $("#alertPopup").modal("hide");
            },
                7000);
        },
        error: function () {
            alert("error");
        }
    });
});