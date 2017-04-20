function getHopManagementPage() {
    $.ajax({
        url: "HopType/HopManagement",
        type: "GET",
        success: function (response) {
            $('#body').html(response);
        },
        error: function () {
            alert("There was an error");
        }
    })
}

function getGrainManagementPage()
{
    $.ajax({
        url: "GrainType/GrainManagement",
        type: "GET",
        success: function(response)
        {
            $('#body').html(response);
        },
        error: function()
        {
            alert("There was an error");
        }
    })
}

function getYeastManagementPage() {
    $.ajax({
        url: "YeastType/YeastManagement",
        type: "GET",
        success: function (response) {
            $('#body').html(response);
        },
        error: function () {
            alert("There was an error");
        }
    })
}

function getAddRecipePage()
{
    $.ajax({
        url: "Recipe/CreateRecipe",
        type: "GET",
        success: function (response) {
            $('#body').html(response);
        },
        error: function () {
            alert("There was an error");
        }
    })

}