
// toggle wheel of fate rotation
$("#btnPlay").click(function () {
    $(".play").addClass("shake");
    setTimeout(
        function () {
            // Remove the class again to stop the hover event
            $(".play").removeClass("shake");
        }, 1000);
});


// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
    $('a.page-scroll').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });

    $(window).scroll(function () {
        // update scroll to top icon visibility
        go_to_top_visibility();
    });
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function () {
    $('.navbar-toggle:visible').click();
});
function viewport() {
    var e = window, a = 'inner';
    if (!('innerWidth' in window)) {
        a = 'client';
        e = document.documentElement || document.body;
    }
    return { width: e[a + 'Width'], height: e[a + 'Height'] };
}
//Check to see if the window is top if not then display button
function go_to_top_visibility() {
    var go_to_top_icon = $("#scrollToTop");

    // if icon exists
    if (go_to_top_icon.length > 0) {
        var scroll_from_top = $(document).scrollTop();
        // if at the top section of the page, hide icon
        if (scroll_from_top < viewport().height) {
            go_to_top_icon.removeClass("active");
        }

        // if further down the page, show icon
        else {
            go_to_top_icon.addClass("active");
        }
    }
}

// Scroll to top
function scroll_to_top() {
    $('html, body').stop().animate({
        scrollTop: 0
    }, 1500, 'easeInOutCubic', function () {
        $("#scrollToTop").removeClass("active"); // deactive scroll to top icin     
    });
}