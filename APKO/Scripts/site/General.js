$(function () {
    new MainMenu();
});


function MainMenu() {

    var menu = $('#m-menu-wrapper');
    var sMenu = $('#s-menu');
    var controledBy = $('#productsMenu');

    var timer;

    var init = function () {

        controledBy.mouseover(show);
        controledBy.mouseout(hide);

        menu.mouseover(show);
        menu.mouseout(hide);

        menu.delegate('a', 'mouseover', showSub);

        sMenu.mouseover(function () {
            cleraTimer();
            menu.show();
            sMenu.show();
        });

        sMenu.mouseout(hide);
    };

    var cleraTimer = function () {

        if (timer) {
            clearTimeout(timer);
        }
    }

    var show = function (e) {

        cleraTimer();
     
        var top = controledBy.offset().top + 14;
        var left = controledBy.offset().left - 20;

        menu.css({ 'top': top, 'left': left });

        menu.show();
    };

    var hide = function (e) {
       
        cleraTimer();

        timer = setTimeout(function () {
            menu.hide();
            sMenu.hide();
        }, 500);
    };

    var showSub = function () {

        cleraTimer();

        var id = $(this).attr('id');

        var n = sMenu.find('div[parentMenu="' + id + '"]');

        if (n.length != 0) {

            if (!sMenu.is(':visible')) {

                sMenu.css({ 'height': menu.height(),
                    'top': menu.find('#m-menu').offset().top,
                    'left': menu.find('#m-menu').offset().left
                });
            }

            if (sMenu.css('left') > menu.find('#m-menu').offset().left + 220) {
                sMenu.stop();
            }
            else {
                if (!sMenu.is(':visible')) {
                    sMenu.show();
                    sMenu.animate({ "left": menu.find('#m-menu').offset().left + 220 }, "slow");
                }
            }

            n.show();
        }
        else {

            cleraTimer();

            timer = setTimeout(function () {
                sMenu.hide();
            }, 100);
        }

        sMenu.find('.s-menu').not(n).hide();
    };

    var hideSub = function () {
        sMenu.hide();
        sMenu.find('.s-menu').hide();
    };

   
    init();
};

/*Logo engine*/

var c = 0;
var logoEngineTimer;
var state = 0;

$(function () {
    $('#logo').mouseover(function () {

        if (state == 0) {
            state = 1;
            startMovement();
        }
    });

    $('#logo').mouseleave(function () {
        stopMovement();
    });
});

function timedCount() {
   
    $('#m1').css('-moz-transform', 'rotate(' + c + 'deg)');
    $('#m2').css('-moz-transform', 'rotate(-' + c + 'deg)');

    $('#m1').css('-webkit-transform', 'rotate(' + c + 'deg)');
    $('#m2').css('-webkit-transform', 'rotate(-' + c + 'deg)');

    c = c + 3;
    logoEngineTimer = setTimeout("timedCount()", 100);
}

function startMovement() {
    timedCount();
}

function stopMovement() {
    state = 0;
    clearTimeout(logoEngineTimer);
}


