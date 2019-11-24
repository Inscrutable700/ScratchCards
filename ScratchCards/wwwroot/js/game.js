var gameViewModel = {
    gameId: 1
};

(function(viewModel) {
    $("#spinBtn").click(() => {
        console.log('Click spin btn');
        spin();
    });

    loadSigns();

    function spin() {
        var request = {
            bet: $("#bet").val()
        }

        $.ajax({
            type: "POST",
            url: "api/game/" + viewModel.gameId,
            data: request,
            dataType: 'json',
            beforeSend: function() {
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