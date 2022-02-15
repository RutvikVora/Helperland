$(document).ready(function () {
    var scroll_start = 0;
    var startchange = $('.header');
    var offset = startchange.offset();
    $(document).scroll(function () {
        scroll_start = $(this).scrollTop();
        if (scroll_start > offset.top) {
            $('#nav').css({ "background-color": "#525252" });
            $('#navlogo').css({ "height": "54px", "width": "73px" })
        } else {
            $('#nav').css('background-color', 'transparent');
            $('#navlogo').css({ "height": "130px", "width": "175px" });
        }
    });

    $("#homepage-bottom").click(function () {
        $("#policy").addClass("d-none");
    });

    /* adding class to tabs when it is clicked for service and admin pages */
    $(document).on('click', '.nav-item', function () {
        $('.menu-title').removeClass('active-tab');
        $(this).children(".nav-link").children(".menu-title").addClass('active-tab');
        //$(this).addClass('active-tab').siblings().removeClass('active-tab')
    })

    // Add active class to the current button (highlight it)
    $(document).on('click', '.page-btn', function () {
        $(this).addClass('active').siblings().removeClass('active')
    })

    /*$(document).on('click','.nav-item',function(){
      $('.tabcontent').addClass('active-tabcontent');
      // Get class list string
      var classList = $("#myDiv").attr("class");
 
      // Creating class array by splitting class list string
      var classArr = classList.split(/\s+/);
      $.each(classList, function(index, value){ 
          $("body").append("<p>" + index + ": " + value + "</p>");
      });

    })*/
});

/* When the user clicks on the button, 
     toggle between hiding and showing the dropdown content */
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show-menu");
}

