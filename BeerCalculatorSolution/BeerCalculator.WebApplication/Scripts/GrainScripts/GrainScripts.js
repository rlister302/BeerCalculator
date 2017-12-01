function saveGrain()
    {
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

    function getGrain()
    {
        var grainName = $('#grain-name').val();
        var extractionRate = $('#max-sugar-ppg').val();
        var maxExtractionRate = $('#max-extraction-rate').val();
        var lovibond = $('#lovibond').val();

        var grain = {};

        grain.GrainName = grainName;
        grain.MaximumSugarExtraction = extractionRate;
        grain.MaximumExtractionRate = maxExtractionRate;
        grain.Lovibond = lovibond;

        return grain;
    }