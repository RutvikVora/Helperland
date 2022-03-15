﻿    function openTab(evt, tabName) {
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


$("#defaultOpen").on("click", function () {
    console.log("something");
});

$(document).on('click', '.page-btn', function () {
    $(this).addClass('active').siblings().removeClass('active');
});

$(document).ready(function () {
    $("#myTab li:eq(0) a").tab("show"); // show second tab (0-indexed, like an array)

});




//var vTabId = "dashboardTabBtn";
//var url1 = new URLSearchParams(window.location.search);
//var urlcust = url1.toString(); if (urlcust.includes("=")) {
//    var indexofequl = urlcust.lastIndexOf("=");
//    vTabId = urlcust.substring(indexofequl + 1, urlcust.length);
//}
//document.getElementById(vTabId).click();
$(document).ready(function () {
    $("#dashbordTable").click(function (e) {
        serviceRequestId = e.target.closest("tr").getAttribute("data-value");
        //alert(serviceRequestId);
        if (e.target.classList.contains("rescheduleService")) {
            document.getElementById("updateRequestId").value = serviceRequestId;
            //alert("In if");
            //alert(document.getElementById("updateRequestId").value);
        }
        if (e.target.classList.contains("cancelService")) {
            document.getElementById("cancelRequestId").value = serviceRequestId;
            alert("In if");
        }
        //if (serviceRequestId != null && (e.target.classList != "cancelService" && e.target.classList != "rescheduleService")) {
        //    document.getElementById("serviceReqdetailsbtn").click();
        //}
        //console.log(e);
    });
});

$(document).ready(function () {
    $("#Dashboard tr").click(function () {
        console.log("in fun");
        var data1 = $(this).find(".serviceId");
        var serviceId = $(data1).text();
        $("#sId").text(serviceId);

        var data2 = $(this).find(".serviceDate");
        var serviceDate = $(data2).text();
        $("#sDate").text(serviceDate);

        var data3 = $(this).find(".serviceTime");
        var serviceTime = $(data3).text();
        $("#sTime").text(serviceTime);

        var data4 = $(this).find(".netAmt");
        var netAmt = $(data4).text();
        //console.log(netAmt);
        $("#netAmount").text(netAmt);

        //var data5 = $(this).closest("tr").find(".PhoneNumber");
        //var phone = $(data5).text();
        //$("#PhoneNum").val(phone);
        //var addressLine2 = arr[]
        
    });
});

$(document).ready(function () {
    $("#rescheduleServiceRequest").on("click", function () {
        var serviceStartDate = document.getElementById("rescheduleDate").value;
        var serviceTime = document.getElementById("rescheduleTime").value;
        var serviceRequestId = document.getElementById("updateRequestId").value;
        console.log(serviceRequestId);
        var data = {};
        data.Date = serviceStartDate;
        data.startTime = serviceTime;
        data.serviceId = serviceRequestId;
        $.ajax({
            type: 'POST',
            url: '/Customer/RescheduleServiceRequest',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                if (result.length != 0) {
                    //window.location.reload();
                    //rowId = result.serviceId.toString();
                    rowId = serviceRequestId.toString();
                    alert(rowId);
                    serviceDate = result.date;
                    StartTime = result.startTime;
                    EndTime = result.endTime;
                    //alert(result.addressId);
                    //alert(addressLine1);

                    data1 = $('#' + rowId).find(".serviceDate");
                    $(data1).text(serviceDate);

                    data2 = $('#' + rowId).find(".serviceTime");
                    $(data2).text(StartTime + "-" + EndTime);

                    //data3 = $('#' + rowId).find(".PostalCode");
                    //$(data3).text(postal);

                    //data4 = $('#' + rowId).find(".City");
                    //$(data4).text(city);

                    //data5 = $('#' + rowId).find(".PhoneNumber");
                    //$(data5).text(phone);
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
            url: '/Customer/CancelServiceRequest',
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

function DetailsSubmit() {
    
    var data = $("#myDetailsForm").serialize();
    alert(data);

    $.ajax({
        type: 'POST',
        url: '/Customer/ChangeDetails',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                
                alert("Changes Done!");

            }
            else if (result.value == "false") {
                alert("false");
            }           
        },
        error: function () {
            alert('Failed to receive the Data');

            console.log('Failed ');
        }
    });
}

//function loadAddress() {
//    var data = $("#form-1").serialize();
//    alert("Inside load address")
//    $.ajax({
//        type: 'get',
//        url: '/Customer/GetAddresses',
//        contenttype: 'application/x-www-form-urlencoded; charset=utf-8',
//        data: data,
//        success: function (result) {
//            alert("Inside load address success")
//            var address = $("#address");
//            address.empty();
//            address.append('<p>Please select your address:</p>');
//            if (result.length == 0) {
//                ClickFunction("newAddressBtn");
//            }
//            for (let i = 0; i < result.length; i++) {
//                var checked = "";
//                if (result[i].isDefault == true) {
//                    checked = "checked";
//                }


//                address.append(' <div class="row radiobutton">' +
//                    '<div style="max-width: 10px" class="col-1"><input type="radio" id=" ' + i + ' " ' + checked + ' name="address" value="' + result[i].addressId + '" /></div>' +
//                    ' <div class="col-11"><label for="' + i + '"><span>Address:</span><br><span>' + result[i].addressLine1 + '</span>,&nbsp;<span>' + result[i].addressLine2 + '</span><br><span>' + result[i].city + '</span>&nbsp;<span>' + result[i].postalCode + '</span>' +
//                    '<br><span>PHONE NUMBER:</span> ' + result[i].mobile + ' <span></span></label></div> </div>');

//                checked = "";
//            }
//            console.log(result);
//        },
//        error: function () {
//            alert('failed to receive the data');
//            console.log('failed ');
//        }
//    });
//}

function CloseMsg() {
    if ($('#changePswSuccess').hasClass("d-none") == false) {
        $('#changePswSuccess').addClass("d-none");
    }
    if ($('#oldPswIncorrect').hasClass("d-none") == false) {
        $('#oldPswIncorrect').addClass("d-none");
    }
}

function changePsw() {
    var data = $("#changePswForm").serialize();
    alert(data);

    $.ajax({
        type: 'POST',
        url: '/Customer/ChangePassword',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                alert("Changes Done!");
                $('#changePswSuccess').toggleClass("d-none");
                document.getElementById("successMsg").innerHTML = "Your password is successfully changed.";
            }
            else if (result.value == "Incorrect") {
                alert("Incorrect Psw");
                $('#oldPswIncorrect').toggleClass("d-none");
                document.getElementById("errorMsg").innerHTML = "Old Password is Incorrect.";
            }
            else if (result.value == "false") {
                alert("false");
            }
        },
        error: function () {
            alert('Failed to receive the Data');

            console.log('Failed ');
        }
    });
}

$(document).ready(function () {
    $(".editAddBtn").click(function () {
        //debugger;
        //var currentTds = $(this).closest("tr").find("td"); // find all td of selected row
        //var cell2 = $(currentTds).eq(1).text();
        //var arr = cell2.split(":");
        //var addressLine1 = arr[1];
        var data1 = $(this).closest("tr").find(".AddressLine1");
        var addressLine1 = $(data1).text();
        $("#streetName").val(addressLine1);

        var data2 = $(this).closest("tr").find(".AddressLine2");
        var addressLine2 = $(data2).text();
        $("#houseNum").val(addressLine2);

        var data3 = $(this).closest("tr").find(".PostalCode");
        var postalCode = $(data3).text();
        $("#postCode").val(postalCode);

        var data4 = $(this).closest("tr").find(".City");
        var city = $(data4).text();
        $("#myCity").val(city);

        var data5 = $(this).closest("tr").find(".PhoneNumber");
        var phone = $(data5).text();
        $("#PhoneNum").val(phone);
        //var addressLine2 = arr[]
        //alert(addressLine1);
        //alert(addressLine2);
        //alert(postalCode);
    });
});

//$(function () {
//    $('#editAddress').modal({
//        keyboard: true,
//        backdrop: "static",
//        show: false,

//    }).on('show', function () {
//        var getIdFromRow = $(this).data('orderid');
//        //make your ajax call populate items or what even you need
//        $(this).find('#orderDetails').html($('<b> Order Id selected: ' + getIdFromRow + '</b>'))
//    });

//    $(".table-striped").find('tr[data-target]').on('click', function () {
//        //or do your operations here instead of on show of modal to populate values to modal.
//        $('#orderModal').data('orderid', $(this).data('id'));
//    });

//});

$(document).ready(function () {
    $("#MyAddressTable").click(function (e) {
        AddressId = e.target.closest("tr").getAttribute("data-value");
        radioBtn = e.target.closest("input");
        IsDefault = $(radioBtn).is(':checked');
        //alert(IsDefault);

        document.getElementById("addressID").value = AddressId;
        document.getElementById("IsDefault").value = IsDefault;
        //alert(document.getElementById("addressID").value);

    });
});

function editAddress() {
    var data = $("#editAddForm").serialize();
    //alert(data);

    $.ajax({
        type: 'POST',
        url: '/Customer/EditAddress',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value != false) {
                rowId = result.addressId.toString();
                //alert(rowId);
                addressLine1 = result.addressLine1;
                addressLine2 = result.addressLine2;
                postal = result.postalCode;
                city = result.city;
                phone = result.mobile;
                //alert(result.addressId);
                //alert(addressLine1);

                data1 = $('#' + rowId).find(".AddressLine1");
                $(data1).text(addressLine1);

                data2 = $('#' + rowId).find(".AddressLine2");
                $(data2).text(addressLine2);

                data3 = $('#' + rowId).find(".PostalCode");
                $(data3).text(postal);

                data4 = $('#' + rowId).find(".City");
                $(data4).text(city);

                data5 = $('#' + rowId).find(".PhoneNumber");
                $(data5).text(phone);

                //console.log($("#rowId"));
            }
            else if (result.value == "false") {
                alert("false");
            }
       },
        error: function () {
            alert('Failed to receive the Data');

            console.log('Failed ');
        }
    });
}