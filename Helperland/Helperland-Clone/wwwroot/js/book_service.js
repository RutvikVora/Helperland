
var prevBasic = 3;


 function openTab(evt, tabName) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("nav-item");
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

function SelectBeds() {
  var x = document.getElementById("bedSelect").value;
  document.getElementById("numberOfbeds").innerHTML =  x;
}

function SelectBaths() {
  var x = document.getElementById("bathSelect").value;
  document.getElementById("numberOfbaths").innerHTML =  x;
}

function SelectDate() {
  var x = document.getElementById("DateSelect").value;
  document.getElementById("serviceDate").innerHTML =  x;
}

function SelectTime() {
  var x = document.getElementById("TimeSelect").value;
  var [h,m] = x.split(":");
  var time =  h >= 12 ? 'PM' : 'AM';
  document.getElementById("serviceTime").innerHTML = (h%12+12*(h%12==0)) +":"+m + time;
}


function SelectHours() {
  //console.log(prevBasic);
  var x = parseFloat(document.getElementById("hourSelect").value);
  document.getElementById("BasicHours").innerHTML =  x;
  var totalTime = parseFloat(document.getElementById("totalTime").innerHTML);
  document.getElementById("totalTime").innerHTML = totalTime + x - prevBasic;
  var newtotalTime = document.getElementById("totalTime").innerHTML;
  var new_price = newtotalTime * 20;
  document.getElementById("payment").innerHTML = '$' + new_price;
  prevBasic = document.getElementById("BasicHours").innerHTML;
}

function addExtra(ele, row) {
  var x = ele.children[1];
  //console.log(row);
  var y = document.getElementById(row);
  //console.log(y);
    var checkbox = $(ele).children('input[type="checkbox"]');
    checkbox.prop('checked', !checkbox.prop('checked'));

  if (x.classList.contains('active')) {
    x.classList.remove('active')
    if(!y.classList.contains('hidden')) { y.classList.add('hidden') }
    var totalTime = parseFloat(document.getElementById("totalTime").innerHTML);
    document.getElementById("totalTime").innerHTML = totalTime - 0.5;
    var newtotalTime = document.getElementById("totalTime").innerHTML;
    var new_price = newtotalTime * 20;
    document.getElementById("payment").innerHTML = '$' + new_price;
  }
  else{
    x.classList.add("active");
    if(y.classList.contains('hidden')) { y.classList.remove('hidden') }
    var totalTime = parseFloat(document.getElementById("totalTime").innerHTML);
    document.getElementById("totalTime").innerHTML = totalTime + 0.5;
    var newtotalTime = document.getElementById("totalTime").innerHTML;
    var new_price = newtotalTime * 20;
    document.getElementById("payment").innerHTML = '$' + new_price;
  }
}

var address;
function show_form(){
  if(address==1)
  {
    document.getElementById("address_form").style.display="block";
    return address=0;
  }else{
    document.getElementById("address_form").style.display="none";
    return address=1;
  }
  
}
function cancel_form(){
  if(address==1)
  {
    document.getElementById("address_form").style.display="inline";
    return address=0;
  }else{
    document.getElementById("address_form").style.display="none";
    return address=1;
  }
}



/* Script For Booking */

//document.getElementById("defaultOpen").click();

function ClickFunction(id) {
    document.getElementById(id).click();
}

function Disable(id) {
    document.getElementById(id).disabled = true;
}
function Clickable(id) {
    document.getElementById(id).disabled = false;
}

function postalSubmit() {

    var data = $("#form-1").serialize();

    $.ajax({
        type: 'POST',
        url: '/BookService/CheckPostalCode',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                Clickable("tab2btn");
                ClickFunction("tab2btn");
                //alert("zipcode is recieved");

            }
            else if (result.value == "false") {
                $("#CheckMsg").text("We are not providing service in this area. We’ll notify you if any helper would start working near your area.");
            }
            else {
                alert("zipcode is not valid");
            }
        },
        error: function () {
            alert('Failed to receive the Data');

            console.log('Failed ');
        }
    });
}

function scheduleSubmit() {
    var data = $("#form-2").serialize();
    //console.log(data);

    //alert(data.toString());

    $.ajax({
        type: 'POST',
        url: '/BookService/ScheduleService',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                Clickable("tab3btn");
                ClickFunction("tab3btn");
                loadAddress();
            }
            else if (result.value == "ClicklogInBtn") {
                Clickable("loginBtn");
                ClickFunction("loginBtn");
                alert("login");
            }
            else if(result.value == "false"){
                alert("schedule is not valid");
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    });
}

function loadAddress() {
    var data = $("#form-1").serialize();
    //alert("Inside load address")
    $.ajax({
        type: 'get',
        url: '/BookService/CustomerDetails',
        contenttype: 'application/x-www-form-urlencoded; charset=utf-8',
        data: data,
        success: function (result) {
            //alert("Inside load address success")
            var address = $("#address");
            address.empty();
            address.append('<p>Please select your address:</p>');
            if (result.length == 0) {
                ClickFunction("newAddressBtn");
            }
            for (let i = 0; i < result.length; i++) {
                var checked = "";
                if (result[i].isDefault == true) {
                    checked = "checked";
                }


                address.append(' <div class="row radiobutton">' +
                    '<div style="max-width: 10px" class="col-1"><input type="radio" id=" ' + i + ' " ' + checked + ' name="address" value="' + result[i].addressId + '" /></div>' +
                    ' <div class="col-11"><label for="' + i + '"><span>Address:</span><br><span>' + result[i].addressLine1 + '</span>,&nbsp;<span>' + result[i].addressLine2 + '</span><br><span>' + result[i].city + '</span>&nbsp;<span>' + result[i].postalCode + '</span>' +
                    '<br><span>PHONE NUMBER:</span> ' + result[i].mobile + ' <span></span></label></div> </div>');

                checked = "";
            }
            //console.log(result);
        },
        error: function () {
            alert('failed to receive the data');
            console.log('failed ');
        }
    });
}

function saveAddressForm() {
    //alert("in save address 1");
    var data = {};
    data.AddressLine1 = document.getElementById("inputstreet").value;
    data.AddressLine2 = document.getElementById("inputhouse").value;
    data.PostalCode = document.getElementById("inputpostal").value;
    data.City = document.getElementById("inputcity").value;
    data.Mobile = document.getElementById("inputphone").value;
    //alert("in save address 2");


    $.ajax({
        type: 'POST',
        url: '/BookService/AddNewAddress',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                //alert("result is true");
                ClickFunction("cancel");
                loadAddress();

            }
            else {
                $("#detailServiceAlert").removeClass("d-none").text("Sorry! Something went wrong please try again later.");
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    });
}

function cancelAddressForm() {
    document.getElementById("address_form").style.display = "none";
    document.getElementById("newAddressBtn").style.display = "block";
}


function completeBookService() {
    var data = {};
    var extrahour = 0;
    var cabinet = document.getElementById("InsideCabinat");
    var window = document.getElementById("InsideWindow");
    var fridge = document.getElementById("InsideFridge");
    var oven = document.getElementById("InsideOven");
    var laundry = document.getElementById("InsideLaundry");
    if (cabinet.checked == true) {
        extrahour += 0.5;
        data.cabinet = true;
    }
    if (window.checked == true) {
        extrahour += 0.5;
        data.window = true;
    }
    if (fridge.checked == true) {
        extrahour += 0.5;
        data.fridge = true;
    }
    if (oven.checked == true) {
        extrahour += 0.5;
        data.oven = true;
    }
    if (laundry.checked == true) {
        extrahour += 0.5;
        data.laundry = true;
    }
    data.postalCode = document.getElementById("postalcode").value;

    var temp = document.getElementById("DateSelect").value;
    data.serviceStartDate = temp + " " + document.getElementById("TimeSelect").value;



    data.serviceHours = document.getElementById("hourSelect").value;
    data.extraHours = extrahour;
    var duration = parseFloat(document.getElementById("hourSelect").value);
    var extra = parseFloat(extrahour);

    data.subTotal = (extra + duration) * 25;
    data.totalCost = data.subTotal; //Discount 0(out of scope)
    data.comments = document.getElementById("comments").value;

    data.HasPets = document.getElementById("flexCheckDefault").checked;
    //(document.getElementById("flexCheckDefault").checked);


    data.addressId = document.querySelector('input[name="address"]:checked').value;
    //alert(data.addressId);

    $.ajax({
        type: 'post',
        url: '/BookService/GenerateServiceRequest',
        contenttype: 'application/x-www-form-urlencoded; charset=utf-8',
        data: data,
        success: function (result) {
            if (result.value == "false") {

                alert("schedule is not valid");
            }
            else {
                //alert("done");
                document.getElementById("completeBooking").click();
                $('#bookingStatus').text("Booking has been successfully submitted").css("color", "Green");
                window.setTimeout(function () {
                    $("#successPopup").modal("hide");
                    window.location.reload();
                },
                    3000);
            }
        },
        error: function () {
            alert('failed to receive the data');
            console.log('failed ');
        }
    });
}
