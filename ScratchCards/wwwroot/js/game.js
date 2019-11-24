var gameViewModel = {
    gameId: 1
};

(function(viewModel) {
    $("#spinBtn").click(() => {
        console.log('Click spin btn');
        spin();
    });

    loadGameConfiguration();

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

            $("#win").text(r.prize);

            $("#wheel-selected").html('');
            $.each(r.wheelSignIds, (index, signId) => {
                var sign = getSignById(signId);
                $("#wheel-selected").append("<span class='badge badge-primary'>" + sign.name + "</span>");
            });

            $("#scratch-card").html('');
            $.each(r.scratchCards, (index, scratchCard) => {
                var scratchCardNumber = index + 1;

                var $scratchCardDiv = $('<div>', {id: 'scratch-card-' + scratchCardNumber});

                $scratchCardDiv.append('<span>Scratch Card #' + scratchCardNumber + ' (Prize = bet * ' + scratchCard.factor + ' = ' + scratchCard.prize + '): </span>')

                $.each(scratchCard.signIds, (index2, signId) => {

                    var sign = getSignById(signId);
                    $scratchCardDiv.append("<span class='badge badge-primary'>" + sign.name + "</span>");
                });

                $("#scratch-card").append($scratchCardDiv);
            });
        }).fail(function(r){
            alert(r.responseText);
        });
    }

    function loadGameConfiguration() {
        $.ajax({
            type: "GET",
            url: "api/game/" + gameViewModel.gameId + "/config",
            beforeSend: function() {
            }
        }).done(function(r) {
            console.log(r);

            viewModel.gameConfig = r;
            
            var wheelSigns = r.signs.filter(s => !s.special);

            $.each(wheelSigns, (index, sign) => {
                $("#wheel").append("<span class='badge badge-primary'>" + sign.name + "</span>");
            });
        });
    }

    function getSignById(signId) {
        return viewModel.gameConfig.signs.filter(s => s.id == signId)[0];
    }
})(gameViewModel);