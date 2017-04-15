function saveHop() {
    var newHop = {};
    newHop.HopTypeID = 0;
    newHop.HopName = $('#hop-name').val();
    newHop.FlavorNotes = $('#flavor-notes').val();
    console.log(newHop);

    $.ajax({
        url: "/BeerCalculator/HopType/CreateHopType",
        type: "POST",
        data: newHop,
        success: function (response) {
            console.log(response);
            alert("Success");
        },
        error: function () {
            alert("There was an error");
        }
    })
}