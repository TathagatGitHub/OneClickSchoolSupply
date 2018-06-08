
               $(document).ready(function () {
                   $('.dropdown-submenu > a').submenupicker();
               });


               $(function () {
                   $(".dropdown").hover(
                   function () {
                       $('.dropdown-submenu', this).stop(true, true).fadeIn("fast");
                       $(this).toggleClass('open');
                       $('b', this).toggleClass("caret caret-up");
                   },
                   function () {
                       $('.dropdown-submenu', this).stop(true, true).fadeOut("fast");
                       $(this).toggleClass('open');
                       $('b', this).toggleClass("caret caret-up");
                   });
               });

   
