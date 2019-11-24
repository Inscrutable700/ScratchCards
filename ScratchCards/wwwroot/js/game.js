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
            bet: $("#bet").val(),
            numberOfScratchCards: $("#number-of-scratch-cards").val()
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

            $("#wheel-selected").html('');
            $.each(r.wheelSignIds, (index, signId) => {
                var sign = getSignById(signId);
                $("#wheel-selected").append("<span class='badge badge-primary'>" + sign.name + "</span>");
            });

            $("#scratch-card").html('');
            $.each(r.scratchCards, (index, scratchCard) => {
                var scratchCardNumber = index + 1;

                var $scratchCardDiv = $('<div>', {id: 'scratch-card-' + scratchCardNumber});

                $scratchCardDiv.append('<span>Scratch Card #' + scratchCardNumber + ' (Prize = ' + scratchCard.prize + '): </span>')

                $.each(scratchCard.signIds, (index2, signId) => {

                    var sign = getSignById(signId);
                    $scratchCardDiv.append("<span class='badge badge-primary'>" + sign.name + "</span>");
                });

                $("#scratch-card").append($scratchCardDiv);
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
        return viewModel.signs.filter(s => s.id == signId)[0];
    }
})(gameViewModel);