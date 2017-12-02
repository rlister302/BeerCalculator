function saveYeast() {
        var yeast = getYeast();
        sendYeastToServer(yeast);
    }

    function getYeast() {

        var yeast = {};

        yeast.YeastName = $('#yeast-name').val();
        yeast.LowAttenuationRate = $('#low-attenuation-rate').val();
        yeast.HighAttenuationRate = $('#high-attenuation-rate').val();;
        yeast.LowTemperatureRange = $('#low-temperature-range').val();;
        yeast.HighTemperatureRange = $('#high-temperature-range').val();;
        yeast.YeastDescription = $('#yeast-description').val();

        return yeast;
    }

    function sendYeastToServer(yeast)
    {
        $.ajax({
            url: "/YeastType/CreateYeastType",
            type: "POST",
            data: yeast,
            success: function (response) {
                $('#yeast-modal').modal('toggle');
            },
            error: function () {
                alert("There was an error");
            }
        })
    }

    function getYeastInformation(yeastTypeId)
    {
        $.ajax({
            url: "/YeastType/GetYeastTypeDetails",
            type: "GET",
            data: { id : yeastTypeId },
            success: function (response) {
                initializeEditYeastModal(response.Data);
            },
            error: function () {
                alert("There was an error");
            }
        })
    }

    function deleteYeastType(yeastTypeId)
    {
        $.ajax({
            url: "/YeastType/DeleteYeastType",
            type: "DELETE",
            data: { id : yeastTypeId },
            success: function (response) {
                alert("Delete successful!");
            },
            error: function () {
                alert("There was an error");
            }
        })
    }

    function editYeast()
    {
        var yeast = getEditYeast();
        sendEditYeastToServer(yeast);
    }

    function getEditYeast()
    {
        var yeast = {};
        yeast.YeastTypeID = $('#edit-yeast-id').val();
        yeast.YeastName = $('#edit-yeast-name').val();
        yeast.LowAttenuationRate = $('#edit-low-attenuation-rate').val();
        yeast.HighAttenuationRate = $('#edit-high-attenuation-rate').val();
        yeast.LowTemperatureRange = $('#edit-low-temperature-range').val();
        yeast.HighTemperatureRange = $('#edit-high-temperature-range').val();
        yeast.YeastDescription = $('#edit-yeast-description').val();
        console.log('edit yeast has ', yeast)
        return yeast;
    }

    function sendEditYeastToServer(yeast)
    {
        $.ajax({
            url: "/YeastType/UpdateYeastType",
            type: "PUT",
            data: { update : yeast },
            success: function (response) {
                alert("Edit successful!");
                $('#edit-yeast').modal('toggle');
            },
            error: function () {
                alert("There was an error");
            }
        })
    }

    function initializeEditYeastModal(yeast)
    {
        $('#edit-yeast-id').val(yeast.YeastTypeID);
        $('#edit-yeast-name').val(yeast.YeastName);
        $('#edit-low-attenuation-rate').val(yeast.LowAttenuationRate);
        $('#edit-high-attenuation-rate').val(yeast.HighAttenuationRate);
        $('#edit-low-temperature-range').val(yeast.LowTemperatureRange);
        $('#edit-high-temperature-range').val(yeast.HighTemperatureRange);
        $('#edit-yeast-description').val(yeast.YeastDescription);
    }