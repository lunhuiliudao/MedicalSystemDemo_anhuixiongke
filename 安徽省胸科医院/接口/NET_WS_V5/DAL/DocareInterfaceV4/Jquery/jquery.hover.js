;(function($) {
    $.fn.extend({
        "hovers": function (color, color2)
        {
            if ($(this).mouseout(function () {
                $(this).css("color", color);
            }));
            if ($(this).mouseenter(function () {
               $(this).css("color", color2);
            }));
        }
    });

    $.fn.ccav = function (color,color2)
    {
        $(this).mouseout(function () {
              $(this).css("color", color);
        }).mouseenter(function () {
           $(this).css("color", color2);
        });
    }
    $.fn.Add = function (a, b)
    {
        return a + b;
    }
    $.fn.Dev = function (a, b)
    {
        return a - b;
    }
})(jQuery)