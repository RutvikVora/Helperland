$(document).ready(function () {
    var scroll_start = 0;
    var startchange = $('.header');
    var offset = startchange.offset();
    $(document).scroll(function () {
        scroll_start = $(this).scrollTop();
        if (scroll_start > offset.top) {
            $('#nav').css({ "background-color": "#525252" });
            $('.rounded-link').css('background-color', "#29626D");
            $('#navlogo').css({ "height": "54px", "width": "73px" })
        } else {
            $('#nav').css('background-color', 'transparent');
            $('.rounded-link').css('background-color', 'transparent');
            $('#navlogo').css({ "height": "130px", "width": "175px" });
        }
    });

    $("#btn-privacy-policy").click(function () {
        document.getElementById("privacy-policy").style.setProperty('display', 'none', 'important')
    });

    //$("#homepage-bottom").click(function () {
    //    $("#policy").addClass("d-none");
    //});

    /* adding class to tabs when it is clicked for service and admin pages */
    $(document).on('click', '.nav-item', function () {
        $('.menu-title').removeClass('active-tab');
        $(this).children(".nav-link").children(".menu-title").addClass('active-tab');
        //$(this).addClass('active-tab').siblings().removeClass('active-tab')
    });

    // Add active class to the current button (highlight it)
    $(document).on('click', '.page-btn', function () {
        $(this).addClass('active').siblings().removeClass('active')
    });

    
});

/* When the user clicks on the button, 
     toggle between hiding and showing the dropdown content */
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show-menu");
}

