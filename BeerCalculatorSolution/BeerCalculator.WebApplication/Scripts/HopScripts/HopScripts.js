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

function deleteHopType(id)
{
    $.ajax({
        url: "/HopType/CreateHopType",
        type: "DELETE",
        data: id,
        success: function (response) {
            console.log(response);
            alert("Hop Type deleted!");
        },
        error: function () {
            alert("There was an error");
        }
    })
}

function getEditHopType(hopTypeId)
{
    $.ajax({
        url: "/HopType/GetHopTypeDetails",
        type: "GET",
        data: { id: hopTypeId },
        success: function (response) {
            initializeEditHopModal(response.Data);
        },
        error: function () {
            alert("There was an error");
        }
    })
}

function initializeEditHopModal(hopType)
{
    $('#edit-hop-type-id').val(hopType.HopTypeID);
    $('#edit-hop-name').val(hopType.HopName);
    $('#edit-flavor-notes').val(hopType.FlavorNotes);
}

function editHop()
{
    var hopType = getEditHopInformation();
    sendEditHopToServer(hopType);
}

function getEditHopInformation()
{
    var hopType = {};
    hopType.HopTypeID = $('#edit-hop-type-id').val();
    hopType.HopName = $('#edit-hop-name').val();
    hopType.FlavorNotes = $('#edit-flavor-notes').val();
    return hopType;
}

function sendEditHopToServer(hopType)
{
    $.ajax({
        url: "/HopType/UpdateHopType",
        type: "PUT",
        data: { update: hopType },
        success: function (response) {
            alert("Edit successful!");
            $('#edit-yeast').modal('toggle');
        },
        error: function () {
            alert("There was an error");
        }
    })
}