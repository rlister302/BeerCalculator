function saveGrain() {
    var grain = getGrain();

    $.ajax({
        url: "/GrainType/CreateGrainType",
        type: "POST",
        data: grain,
        success: function (response) {
            console.log(response);
            $('#grain-modal').modal('toggle');
        },
        error: function () {
            alert("There was an error");
        }
    });
}

function getGrain() {

    var grain = {};
    grain.GrainName = $('#grain-name').val();
    grain.MaximumSugarExtraction = $('#max-sugar-ppg').val();
    grain.MaximumExtractionRate = $('#max-extraction-rate').val();
    grain.Lovibond = $('#lovibond').val();

    return grain;
}

function editGrain()
{
    var grain = getEditGrain();
    sendEditGrainToServer(grain);
}

function sendEditGrainToServer(grain)
{
    $.ajax({
        url: "/GrainType/UpdateGrainType",
        type: "PUT",
        data: { update: grain },
        success: function (response) {
            alert("Edit successful!");
            $('#edit-grain-modal').modal('toggle');
        },
        error: function () {
            alert("There was an error");
        }
    })
}

function deleteGrainType(grainTypeId)
{
    $.ajax({
        url: "/GrainType/DeleteGrainType",
        type: "DELETE",
        data: { id : grainTypeId },
        success: function (response) {
            console.log(response);
            alert("Grain Type deleted!");
        },
        error: function () {
            alert("There was an error");
        }
    })
}

function getEditGrain()
{
    var grain = {};
    grain.GrainTypeID = $('#edit-grain-id').val();
    grain.GrainName = $('#edit-grain-name').val();
    grain.MaximumSugarExtraction = $('#edit-max-sugar-ppg').val();
    grain.MaximumSugarExtraction = $('#edit-max-extraction-rate').val();
    grain.Lovibond = $('#edit-lovibond').val();
    return grain;
}

function getEditGrainType(grainTypeId)
{
    $.ajax({
        url: "/GrainType/GetGrainTypeDetails",
        type: "GET",
        data: { id : grainTypeId },
        success: function (response) {
            initializeEditGrainModal(response.Data);
        },
        error: function () {
            alert("There was an error");
        }
    });
}

function initializeEditGrainModal(grainType)
{
    $('#edit-grain-id').val(grainType.GrainTypeID);
    $('#edit-grain-name').val(grainType.GrainName);
    $('#edit-max-sugar-ppg').val(grainType.MaximumSugarExtraction);
    $('#edit-max-extraction-rate').val(grainType.MaximumSugarExtraction);
    $('#edit-lovibond').val(grainType.Lovibond);
}