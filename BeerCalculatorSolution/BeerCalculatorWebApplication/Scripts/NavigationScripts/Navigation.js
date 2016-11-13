function getHopManagementPage() {
    $.ajax({
        url: "/HopType/HopManagement",
        type: "GET",
        success: function (response) {
            $('#body').html(response);
        },
        error: function () {
            alert("There was an error");
        }
    })
}