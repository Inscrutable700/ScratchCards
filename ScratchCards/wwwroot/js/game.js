(function() {
    $("#spinBtn").click(() => {
        console.log('Click spin btn');

    });

    loadSigns();

    function loadSigns() {
        $.ajax({
            type: "GET",
            url: "api/sign",
            beforeSend: function() {
                //$("body").mask("Processing...");
            }
        }).done(function(r) {
            console.log(r);

            $.each(r.signs, (sign, value) => {
                $("#wheel").append("<span class='badge badge-primary'>" + value.name + "</span>");
            });
        });
    }
})();