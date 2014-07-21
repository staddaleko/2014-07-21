$(document).ready(function () {
    $('#good').click(function () {

        
        var request = new PersonModel();

        $.ajax({
            url: "Person/GoodSave",
            dataType: 'json',
            contentType: 'application/json',
            type: "POST",
            data: JSON.stringify(request),
            success: function (response) {
                $('#result').text(response.result);
            }
        });

    });


    $('#bad').click(function () {
        var request = new PersonModel();

        $.ajax({
            url: "Person/BadSave",
            dataType: 'json',
            //contentType: 'application/json',
            type: "POST",
            data: "&first=" + request.First + "&last=" + request.Last + "&favoriteBands=" + request.FavoriteBands,
            success: function (response) {
                $('#result').text(response.result);
            }
        });
    });
});

function PersonModel() {
    var self = this;
    self.First = $("#First").val();
    self.Last = $("#Last").val();

    self.FavoriteBands = $.map($('#FavoriteBands option:selected'),
        function (e) { return $(e).val(); });
}