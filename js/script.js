$(document).ready(function () {
    var scroll_start = 0;
    var startchange = $('#header');
    var offset = startchange.offset();
    $(document).scroll(function () {
        scroll_start = $(this).scrollTop();
        if (scroll_start > offset.top) {
            $('#nav').css({ "background-color": "#73706C" });
            $('#navlogo').css({ "height": "96px", "width": "130px" })
        } else {
            $('#nav').css('background-color', 'transparent');
            $('#navlogo').css({ "height": "130px", "width": "175px" });
        }
    });

    $("#homepage-bottom").click(function () {
        $("#policy").addClass("d-none");
    });
});




