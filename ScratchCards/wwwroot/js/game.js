var gameViewModel = {};

(function(viewModel) {
    $("#spinBtn").click(() => {
        console.log('Click spin btn');
        spin();
    });

    loadSigns();

    function spin() {
        $.ajax({
            type: "POST",
            url: "api/game",
            beforeSend: function() {
                //$("body").mask("Processing...");
            }
        }).done(function(r) {
            console.log(r);

            $.each(r.signIds, (index, signId) => {
                var sign = getSignById(signId);

                $("#scratch-card").append("<span class='badge badge-primary'>" + sign.name + "</span>");
            });
        });
    }

    function loadSigns() {
        $.ajax({
            type: "GET",
            url: "api/sign",
            beforeSend: function() {
                //$("body").mask("Processing...");
            }
        }).done(function(r) {
            console.log(r);

            viewModel.signs = r.signs;

            $.each(r.signs, (index, sign) => {
                $("#wheel").append("<span class='badge badge-primary'>" + sign.name + "</span>");
            });
        });
    }

    function getSignById(signId) {
        return viewModel.signs.filter(s => s.id == signId);
    }
})(gameViewModel);