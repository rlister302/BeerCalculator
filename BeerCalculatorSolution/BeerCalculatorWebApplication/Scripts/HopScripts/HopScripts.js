function saveHop() {
    var newHop = {};
    newHop.HopTypeID = 0;
    newHop.HopName = $('#hop-name').val();
    newHop.FlavorNotes = $('#flavor-notes').val();
    console.log(newHop);

    $.ajax({
        url: "/HopType/CreateHopType",
        type: "POST",
        data: newHop,
        success: function (response) {
            console.log(response);
            $('#hop-modal').modal('toggle');
        },
        error: function () {
            alert("There was an error");
        }
    })
}