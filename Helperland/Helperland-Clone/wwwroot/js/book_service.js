
// const tabs = document.querySelectorAll('[data-tab-target]')
// const tabContents = document.querySelectorAll('[data-tab-content]')


// tabs.forEach(tab => {
//   tab.addEventListener('click', () => {
//     const target = document.querySelector(tab.dataset.tabTarget)
//     tabContents.forEach(tabContent => {
//       tabContent.classList.remove('active')
      
//     })
//     tabs.forEach(tab => {
//       // tab.classList.remove('active')
//     })
//     tab.classList.add('active')
//     target.classList.add('active')
//   })
// })

var prevBasic = 3;

// Get the element with id="defaultOpen" and click on it
document.getElementById("defaultOpen").click();

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
  console.log(prevBasic);
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
  console.log(row);
  var y = document.getElementById(row);
  console.log(y);
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
