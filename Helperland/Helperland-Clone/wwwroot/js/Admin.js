/* open tab function for admin and service pages */
function openTab(evt, tabName) {
    var i, tabcontent;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    document.getElementById(tabName).style.display = "block";
}

$(document).ready(function () {
    document.getElementById("usermanagementtab").click();
});

// Add active class to the current button (highlight it)
$(document).ready(function () {
    $(document).on('click', '.nav-item', function () {
        $(this).addClass('active-tab').siblings().removeClass('active-tab');
    });
});

/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
    document.getElementsByClassName("dropbtn").classList.toggle("roundedbtn");
}

// Close the dropdown if the user clicks outside of it
/*window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var dropBtn = document.getElementsByClassName("dropbtn")
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            var roundBtn = dropBtn[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
                roundBtn.classList.remove('roundedbtn');
            }
        }
    }
}*/

function showDropdown(clicked_id) {
    console.log("clicked");
    var id = clicked_id + "_popup";

    $("#" + id).toggleClass("show");
    $("#" + clicked_id).toggleClass("roundedbtn");
}

/*$(document).ready(function ()
{
    $('#filterServiceReqId').on('keyup', function () {
        var datasearch = $(this).val().toLowerCase();
        $("#adminservicereqtable tr").each(function() {
            var serviceId = $(this).text().toLowerCase();
            if (serviceId.indexOf(datasearch) === -1) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });
    });
});*/



$(document).on("click", "#servicereqtab", function () {
    console.log("45 get adminservicereq()");
    if ($.fn.DataTable.isDataTable("#adminservicereqtable")) {
        $('#adminservicereqtable').DataTable().clear().destroy();
    }
    getadminservicereq();
    //adminserviceDatatable();

});


$(document).on("click", "#filterSubmit", function () {
    console.log("83 submit get adminservicereq()");
    if ($.fn.DataTable.isDataTable("#adminservicereqtable")) {
        $('#adminservicereqtable').DataTable().clear().destroy();
    }
    getadminservicereq();

});

$(document).on("click", "#filterclear", function () {
    console.log("83 submit get adminservicereq()");
    if ($.fn.DataTable.isDataTable("#adminservicereqtable")) {
        $('#adminservicereqtable').DataTable().clear().destroy();
    }
    window.setTimeout(function () {
        getadminservicereq();
    }, 500);


});



function getadminservicereq() {

    var data = {};
    data.serviceId = document.getElementById("filterServiceReqId").value;
    data.zipCode = document.getElementById("filterPincode").value;
    data.email = document.getElementById("filterEmail").value;
    data.customerName = document.getElementById("filterCustomer").value;
    data.serviceProviderName = document.getElementById("filterSp").value;
    data.status = document.getElementById("filterStatus").value;
    data.fromDate = document.getElementById("filterFromdate").value;
    data.toDate = document.getElementById("filterTodate").value;
    console.log(data.serviceId + data.zipCode + data.email + data.customerName + data.serviceProviderName + data.status + data.fromDate + data.toDate);
    $.ajax({
        type: 'GET',
        url: '/Admin/GetServiceRequest',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {


            if (result.val == "false") {
                alert("false");
            }
            else {
                $("#adminServicereqTbody").empty();


                console.log("in filtered");
                for (var i = 0; i < result.length; i++) {

                    var varStatus = "";
                    var star = "";
                    var popupfield = "";
                    var display = "";

                    if (result[i].userProfilePicture == null) {
                        result[i].userProfilePicture = "cap.png";
                    }

                    if (result[i].serviceProvider == null) {
                        display = "d-none";
                        result[i].serviceProvider = "";
                    }

                    for (var j = 1; j < 6; j++) {

                        if (j <= result[i].averageRating) {

                            star += '<img src="/images/star1.png"> ';

                        }
                        else {
                            star += '<img src="/images/star2.png"> ';
                        }

                    }
                    star += " " + result[i].averageRating;



                    switch (result[i].status) {

                        case 1: /*new */
                            varStatus = "new";
                            BtnClass = 'new-btn';
                            //popupfield = ' <li>' +
                            //    '       < a class="dropdown-item" title = "Edit & Reschedule" href = "#" >' +
                            //    '            <p><span>Edit & Reschedule </span></p>' +
                            //    '                   </a >' +
                            //    '                </li >' +
                            //    '                <li>' +
                            //    '                    <a class="dropdown-item" title="Cancel" href="#">' +
                            //    '                        <p><span>Cancel</span></p>' +
                            //    '                    </a>' +
                            //    '                </li>';
                            popupfield = ' <p class="AdminEdit" data-value=' + result[i].serviceId + '>Edit & Reschedule </p>   '
                                + '<p class="AdminCancel" data-value=' + result[i].serviceId + '> Cancel </p>  ';
                            break;
                        case 2: /*pending */
                            varStatus = "completed";
                            //popupfield = ' <li>' +
                            //    '       < a class="dropdown-item" title = "Edit & Reschedule" href = "#" >' +
                            //    '            <p><span>Edit & Reschedule </span></p>' +
                            //    '                   </a >' +
                            //    '                </li >' +
                            //    '                <li>' +
                            //    '                    <a class="dropdown-item" title="Cancel" href="#">' +
                            //    '                        <p><span>Cancel</span></p>' +
                            //    '                    </a>' +
                            //    '                </li>';
                            popupfield = ' <p class="AdminEdit" class="AdminEdit" data-value=' + result[i].serviceId + '>Edit & Reschedule </p>   '
                                + '<p  class="AdminCancel" data-value=' + result[i].serviceId + '> Cancel </p>  ';
                            BtnClass = 'completed-btn';
                            break;
                        case 3: /*completed */
                            varStatus = "cancelled";
                            //popupfield = ' <li>' +
                            //    '                    <a class="dropdown-item" style="cursor: pointer;" title="Refund">' +
                            //    '                        <p><span>Refund</span></p>' +
                            //    '                    </a>' +
                            //    '                </li>  ';
                            popupfield = '    <p> Refund</p>  ';
                            BtnClass = 'cancel-btn';
                            break;
                        case 4: /*cancelled*/
                            varStatus = "panding";
                            //popupfield = ' <li>' +
                            //    '                    <a class="dropdown-item" style="cursor: pointer;" title="Refund">' +
                            //    '                        <p><span>Refund</span></p>' +
                            //    '                    </a>' +
                            //    '                </li>  ';
                            popupfield = '    <p> Refund</p>  ';
                            BtnClass = 'pendding-btn';
                            break;
                        default: /*other status */
                            varStatus = "invalid";
                    }

                    var html = '' +
                        '<tr>' +
                        '    <td data-label="Service ID" class="text-center">' +
                        '        ' + result[i].serviceId +
                        '    </td>' +
                        '    <td data-label="Service date">' +
                        '        <p>' +
                        '            <img src="/images/calendar2.png" alt="calender">' +
                        '                ' + result[i].date + ' <br>' +
                        '                    <img src="/images/layer-14.png" alt="clock">' +
                        '                      ' + result[i].startTime + '-' + result[i].endTime + '</p>' +
                        '                                </td>' +
                        '                <td data-label="Customers details">' +
                        '                    <p>' +
                        '                       ' + result[i].customerName + ' <br>' +
                        '                            <img src="/images/layer-15.png"' +
                        '                                alt="home">' + result[i].address + '' +
                        '                                    </p>' +
                        '                                </td>' +
                        '                        <td>' + '<div class="d-flex">' +
                        '                            <div class="cap ' + display + '">' +
                        '                                <img src="/images/' + result[i].userProfilePicture + '"' +
                        '                                    alt="..">' +
                        '                                    </div>' +
                        '                             <div class= d-flex' + display + '>' + '<p>' + result[i].serviceProvider + '<br>' + star + '</p>' +
                        '                                </div>' + '</div>' +
                        '                        </td>' +
                        '                            <td data-label="Price"> ' + result[i].totalCost + ' &euro;  </td>' +
                        '                            <td data-label=" Status">' +
                        '                                <button class= "btn btn-outline-light' + varStatus + " " + BtnClass + '">' + varStatus + '</button>' +
                        '                            </td>' +
                        '                            <td data-label="Actions">' + '<div class="dropdown">' +
                        '                                <button class="btn dropbtn" onclick="showDropdown(this.id)"' +
                        '                                    id="' + result[i].serviceId + '">' +
                        '                                    <img src="/images/group-38.png" alt="...">' + '</button>' +
                        '                                        <div class="dropdown-content" id="' + result[i].serviceId + '_popup">' + popupfield +
                        '                                        </div>' + '</div>' +
                        '                                </td>' +
                        '                            </tr>';





                    $("#adminServicereqTbody").append(html);
                }




                adminserviceDatatable();


            }
        },
        error: function () {
            alert("error");
        }
    });
}





function adminserviceDatatable() {

    console.log("in fun");
    $("#adminservicereqtable").DataTable({

        dom: 't<"admin-pagenumber"<"admin-pagenumber-left"li><"admin-pagenumber-right"p>>',
        responsive: true,
        pagingType: "full_numbers",
        language: {
            paginate: {
                first: "<img src='/images/first-page.png' alt='first'/>",
                previous: "<img src='/images/keyboard-right-arrow-button-copy.png' alt='previous' />",
                next: "<img src='/images/keyboard-right-arrow-button-copy.png' alt='next' style='transform: rotate(180deg)' />",
                last: "<img src='/images/first-page.png' alt='first' style='transform: rotate(180deg) ' />",
            },

            info: "Total Records : _MAX_",

            lengthMenu: "Show  _MENU_  Entries",


        },
        iDisplayLength: 10,
        aLengthMenu: [[5, 10, 15, -1], [5, 10, 15, "All"]],

        columnDefs: [{ orderable: false, targets: 4 }],




    });

}


var serviceReqId;
var state;
$(document).on('click', '.AdminEdit', function () {

    console.log("edit click 241");
    $("#AdminEditModelBtn").click();
    serviceReqId = this.getAttribute("data-value");
    console.log(serviceReqId);
    FillEditModal();
});

function FillEditModal() {

    var data = {};
    data.ServiceId = parseInt(serviceReqId);

    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditModalDetails',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {







            console.log("suceess" + result.startTime);
            console.log("suceess" + result.date);
            console.log("suceess" + result.address.addressLine1);



            document.querySelector('option[value="' + result.startTime + '"]').selected = true;

            var temp = new Date(result.date);
            console.log("suceess" + temp);


            temp.setDate(temp.getDate() + 1);
            console.log("suceessful" + temp);
            document.getElementById('AdminEditPopupDate').valueAsDate = temp;






            document.getElementById('AdminEditPopupStreet').value = result.address.addressLine2;
            document.getElementById('AdminEditPopupHouse').value = result.address.addressLine1;
            document.getElementById('AdminEditPopupPostalCode').value = result.address.postalCode;


            document.getElementById('AdminEditPopupInvoiceStreet').value = result.address.addressLine2;
            document.getElementById('AdminEditPopupInvoiceHouse').value = result.address.addressLine1;
            document.getElementById('AdminEditPopupInvoicePostalCode').value = result.address.postalCode;

            document.getElementById('AdminEditPopupCity').value = result.address.City;
            document.getElementById('AdminEditPopupInvoiceCity').value = result.address.City;

            


        },
        error: function () {
            alert("error");
        }
    });

}

$(document).on('click', '#AdminEditModalUpdateBtn', function () {


    var data = {};
    data.address = {};
    data.ServiceId = parseInt(serviceReqId);
    data.address.addressLine2 = document.getElementById('AdminEditPopupStreet').value;

    data.address.addressLine1 = document.getElementById('AdminEditPopupHouse').value;
    data.address.postalCode = document.getElementById('AdminEditPopupPostalCode').value;
    data.address.city = document.getElementById('AdminEditPopupCity').value;
    data.address.state = state;
    var temp = document.getElementById("AdminEditPopupDate").value;
    data.date = temp + " " + document.getElementById("AdminEditPopupTime").value;







    var testnumber = /^[0-9]{10}$/;
    var testpin = /^[1-9][0-9]{5}$/;
    var popup = document.getElementById("AdminEditModal");

    window.setTimeout(function () {
        $('#AdminEditPopupAlert').addClass('d-none');
    }, 5000);

    if (data.address.addressLine1 == "") {
        $("#AdminEditPopupAlert").removeClass("alert-success d-none").addClass("alert-danger").text("House no. is Required.");
        popup.scrollTop = 0;
        $("#AdminEditPopupHouse").focus();
    }
    else if (data.address.addressLine2 == "") {
        $("#AdminEditPopupAlert").removeClass("alert-success d-none").addClass("alert-danger").text("Street name is Required.");
        popup.scrollTop = 0;
        $("#AdminEditPopupStreet").focus();
    }
    else if (!testpin.test(data.address.postalCode)) {
        $("#AdminEditPopupAlert").removeClass("alert-success d-none").addClass("alert-danger").text("postalcode  is Invalid.");
        popup.scrollTop = 0;
        $("#AdminEditPopupPostalCode").focus();
    }
    else {

        $.ajax({
            type: 'POST',
            url: '/Admin/UpdateServiceReq',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {

                $("#AdminEditPopupAlert").removeClass("alert-danger d-none").addClass("alert-success").text("Service Request Edit Suceessful.");



                popup.scrollTop = 0;


                window.setTimeout(function () {
                    $("#AdminEditModalClose").click();
                    $("#filterSubmit").click();
                }, 3000);

            },
            error: function () {
                alert("error");
            }
        });

    }

});


$(document).on('click', '.AdminCancel', function () {

    console.log("cancel click 241");

    serviceReqId = this.getAttribute("data-value");

    var data = {};
    data.ServiceId = parseInt(serviceReqId);

    $.ajax({
        type: 'POST',
        url: '/Admin/CancelServiceReq',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {

            $("#filterSubmit").click();


            $('#ModalLabel_SID').text("Service Cancled").css("color", "red");
            $("#complete").click();



            //window.setTimeout(function () {


            //}, 3000);

        },
        error: function () {
            alert("error");
        }
    });



});



/*User Management*/

$(document).on("click", "#usermanagementtab", function () {
    console.log("521 ");
    if ($.fn.DataTable.isDataTable("#adminUserTable")) {
        $('#adminUserTable').DataTable().clear().destroy();
    }
    getAdminUserData();

});



$(document).on("click", "#UserFilterSearch", function () {

    if ($.fn.DataTable.isDataTable("#adminUserTable")) {
        $('#adminUserTable').DataTable().clear().destroy();
    }
    getAdminUserData();

});

$(document).on("click", "#UserFilterClear", function () {

    if ($.fn.DataTable.isDataTable("#adminUserTable")) {
        $('#adminUserTable').DataTable().clear().destroy();
    }
    window.setTimeout(function () {
        getAdminUserData();
    }, 500);


});




function getAdminUserData() {



    var data = {};


    data.name = document.getElementById("UserFilterName").value;
    data.userType = document.getElementById("UserFilterRole").value;
    data.postalCode = document.getElementById("UserFilterPostalCode").value;
    data.phone = document.getElementById("UserFilterPhone").value;
    //data.email = document.getElementById("UserFilterEmail").value;
    //data.fromDate = document.getElementById("UserFilterFromDate").value;
    //data.toDate = document.getElementById("UserFilterToDate").value;
    // console.log(data.serviceRequestId + data.zipCode + data.email + data.customerName + data.serviceProviderName + data.status + data.fromDate + data.toDate);
    console.log("in fun");
    $.ajax({
        type: 'GET',
        url: '/Admin/GetUserData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {




            $("#AdminUserTbody").empty();



            for (var i = 0; i < result.length; i++) {


                //for date



                var createdDateTemp = new Date(result[i].createdDate.toString());
                var yyyy = createdDateTemp.getFullYear();
                var mm = createdDateTemp.getMonth() + 1; // Months start at 0!
                var dd = createdDateTemp.getDate();

                if (dd < 10) dd = '0' + dd;
                if (mm < 10) mm = '0' + mm;

                var createdDateTemp = dd + '/' + mm + '/' + yyyy;


                //for user type

                var userTypeTemp = "Customer";

                if (result[i].userTypeId == 1) {
                    userTypeTemp = "ServiceProvider";
                }
                else if (result[i].userTypeId == 2) {
                    userTypeTemp = "Admin";
                }

                //for active disactive

                var statusTemp = "Active";

                if (result[i].isActive == false) {
                    statusTemp = "InActive";
                }

                //popup



                var popup;

                if (result[i].userTypeId != 1) {
                    if (result[i].isActive == true) {
                        popup = '<p>Deactive</p>';
                    }
                    else {

                        popup = '<p>Activate</p>';

                    }
                }
                else if (result[i].userTypeId == 1) {
                    if (result[i].isApproved == false) {
                        popup = '<p>Approve</p>'
                    }
                    else {
                        if (result[i].isActive == true) {
                            popup = '<p>Deactive</p>';
                        }
                        else {

                            popup = '<p>Activate</p>';

                        }
                    }

                }

                var html = ' <tr>' +
                    '                            <td data-label="User Name">' +
                    '                                <p>' + result[i].firstName + '</p>' +
                    '' +
                    '                            </td>' +
                    '                            <td data-label="Date of Registration">' +
                    '                                <p> <img class="me-2" src="/image/calendar2.png" alt="calender">' + createdDateTemp + '</p>' +
                    '                            </td>' +
                    '                            <td data-label="User Type">' +
                    '                                <p>' + userTypeTemp + '</p>' +
                    '                            </td>' +
                    '' +
                    '                            <td data-label="Phone">' +
                    '                                <p>' + result[i].mobile + '</p>' +
                    '                            </td>' +
                    '                            <td data-label="Postal Code">' +
                    '                                <p>' + result[i].zipCode + '</p>' +
                    '                            </td>' +
                    '                            <td data-label="Status">' +
                    '                                <button class="' + statusTemp + '">' + statusTemp + '</button>' +
                    '                                </td>' +
                    '                            <td data-label="Actions">' + '<div class="dropdown">' +
                    '                                <button class="btn dropbtn" onclick="showDropdown(this.id)"' +
                    '                                    id="' + result[i].userId + '">' +
                    '                                    <img src="/images/group-38.png" alt="...">' + '</button>' +
                    '                                        <div class="dropdown-content" id="' + result[i].userId + '_popup">' + popupfield +
                    '                                        </div>' + '</div>' +
                    '                                </td>' +
                    '                        </tr>';





                $("#AdminUserTbody").append(html);
            }




            adminUserDatatable()



        },
        error: function () {
            alert("error");
        }
    });
}






$(document).on("click", ".popuptext.userpopup", function () {

    var id = this.getAttribute("data-value");
    var data = {};
    data.UserId = parseInt(id);

    $.ajax({
        type: 'POST',
        url: '/Admin/UserEdit',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {

            $("#UserFilterSearch").click();


            $('#ModalLabel_SID').text(result).css("color", "Green");
            $("#complete").click();





        },
        error: function () {
            alert("error");
        }
    });



});


function adminUserDatatable() {
    console.log("in dataTable");

    $("#adminUserTable").DataTable({

        dom: 't<"admin-pagenumber"<"admin-pagenumber-left"li><"admin-pagenumber-right"p>>',
        responsive: true,
        pagingType: "full_numbers",
        language: {
            paginate: {
                first: "<img src='/images/first-page.png' alt='first'/>",
                previous: "<img src='/images/keyboard-right-arrow-button-copy.png' alt='previous' />",
                next: "<img src='/images/keyboard-right-arrow-button-copy.png' alt='next' style='transform: rotate(180deg)' />",
                last: "<img src='/images/first-page.png' alt='first' style='transform: rotate(180deg) ' />",
            },

            info: "Total Records : _MAX_",

            lengthMenu: "Show  _MENU_  Entries",


        },
        iDisplayLength: 10,
        aLengthMenu: [[5, 10, 15, -1], [5, 10, 15, "All"]],

        columnDefs: [{ orderable: false, targets: 4 }],
        order: [[0, "desc"]],



    });

}


