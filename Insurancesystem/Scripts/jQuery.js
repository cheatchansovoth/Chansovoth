$(document).ready(function () {

     $(".claimform").hide();
     $("select").change(function ()
    {
        if (this.value == "0") {
            $(".claimform").hide();
        }
        else if (this.value == "1")
        {
            $(".claimform").show();
        }

        else
        {
            $(".claimform").show();    
        }
    });
});
$(".dropdown").hover(function () {
    //toggle the open class (on/off)
    $(this).toggleClass("open");
});