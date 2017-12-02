function addGrain() {
        var grainRow = $('.grain-prototype').clone();
        $(grainRow).removeClass('grain-prototype').addClass('recipe-grain');
        $('.grain-table').append(grainRow);
    }

    function addHop() {
        var hopRow = $('.hop-prototype').clone();
        $(hopRow).removeClass('hop-prototype').addClass('recipe-hop');
        $('.hop-table').append(hopRow);
    }

    function createRecipe() {
        var recipe = getRecipeInformation();
        sendRecipeToServer(recipe);
    }

    function sendRecipeToServer(recipe) {

        $.ajax({
            url: '/Recipe/CreateRecipe',
            type: 'POST',
            data: recipe,
            success: function (response) {
                alert("Success");
            },
            error: function (response) {
                alert("Error");
            }
        })
    }

    function getRecipeInformation() {
        var recipe = {};
        recipe.RecipeName = $('.recipe-name').val();
        recipe.Grains = getGrains();
        recipe.Hops = getHops();
        recipe.Yeast = getYeast();
        recipe.ExpectedAttenuation = $('#expected-attenuation').val();
        recipe.ExpectedMashEfficiency = $('#expected-efficiency').val();
        getRecipeMetrics(recipe);
        recipe.WaterInput = getWaterInput();
        recipe.FinalVolume = $('#batch-size').val();

        return recipe;
    }



    function getYeast() {
        var yeast = {};
        yeast.YeastTypeID = $('.yeast-selection').val();
        return yeast;
    }

    function getHops() {
        var hops = $('.recipe-hop');
        var recipeHops = [];

        for (var i = 0; i < hops.length; i++) {
            recipeHops.push(parseHop(hops[i]));
        }

        return recipeHops;
    }

    function parseHop(hopToParse) {
        var hop = {};

        hop.HopTypeID = $(hopToParse).find('.hop-selection').val();
        hop.Amount = $(hopToParse).find('.hop-amount').val();
        hop.BoilTime = $(hopToParse).find('.boil-time').val();
        hop.AlphaAcid = $(hopToParse).find('.hop-alpha-acid').val();

        return hop;
    }

    function getGrains() {
        var grains = $('.recipe-grain');

        var recipeGrains = [];

        for (var i = 0; i < grains.length; i++) {
            recipeGrains.push(parseGrain(grains[i]));
        }

        return recipeGrains;
    }

    function parseGrain(grainToParse) {
        var grain = {};

        grain.GrainTypeID = $(grainToParse).find('.grain-selection').val();
        grain.Amount = $(grainToParse).find('.grain-amount').val();

        return grain;
    }

    function getRecipeInput() {
        var recipeInput = {};

        recipeInput.Grains = getGrains();
        recipeInput.Hops = getHops();
        recipeInput.Yeast = getYeast();
        recipeInput.ExpectedAttenuation = $('#expected-attenuation').val();
        recipeInput.MashEfficiency = $('#expected-efficiency').val();

        recipeInput.WaterInput = getWaterInput();

        return recipeInput;
    }

    function getWaterInput() {
        var waterInput = {};
        waterInput.DesiredBatchSize = $('#batch-size').val();
        waterInput.MashEfficiency = $('#mash-efficiency').val();
        waterInput.MashTemperature = $('#mash-temperature').val();
        waterInput.BoilRate = $('#boil-off-rate').val();
        waterInput.GrainAbsorbtion = $('#grain-absorbtion').val();
        waterInput.EquipmentDeadSpace = $('#equipment-dead-space').val();
        waterInput.TrubLoss = $('#trub-loss').val();
        waterInput.MashThickness = $('#mash-thickness').val();
        waterInput.InitialGrainTemperature = $('#initial-grain-temperature').val();

        return waterInput
    }

    function calculateMetrics() {
        var recipeInput = getRecipeInput();
        sendMetricsToServer(recipeInput);
    }

    function sendMetricsToServer(recipeInput) {
        var data = JSON.stringify(recipeInput);

        $.ajax({
            url: "/Calculator/Calculate",
            type: "POST",
            data: recipeInput,
            success: function (response) {
                console.log(response);
                initializeRecipeMetricsModal(response.Data);
                $('#recipe-metrics').modal();
            },
            error: function () {
                alert("There was an error");
            }
        })
    }

    function clearRecipeMetricsModal() {
        $('#expected-abv').val('');
        $('#expected-original-gravity').val('');
        $('#expected-final-gravity').val('');
        $('#expected-ibu').val('');
        $('#expected-boil-gravity-points').val('');
        $('#expected-srm').val('');
        $('#sparge-volume').val('');
        $('#strike-temperature').val('');
        $('#strike-volume').val('');
        $('#water-required').val('');
        $('#boil-volume').val('');
    }

    function setRecipeMetrics(recipeMetrics) {
        $('#expected-abv').val(parseFloat(recipeMetrics.ExpectedAbv).toFixed(2));
        $('#expected-original-gravity').val(parseFloat(recipeMetrics.ExpectedOriginalGravity).toFixed(3));
        $('#expected-final-gravity').val(parseFloat(recipeMetrics.ExpectedFinalGravity).toFixed(3));
        $('#expected-ibu').val(recipeMetrics.ExpectedIbu);
        $('#expected-boil-gravity-points').val(recipeMetrics.ExpectedBoilGravityPoints);
        $('#expected-srm').val(recipeMetrics.ExpectedSrm);
        $('#sparge-volume').val(recipeMetrics.WaterMetrics.SpargeVolume);
        $('#strike-temperature').val(recipeMetrics.WaterMetrics.StrikeTemperature);
        $('#strike-volume').val(recipeMetrics.WaterMetrics.StrikeVolume);
        $('#water-required').val(recipeMetrics.WaterMetrics.WaterRequired);
        $('#boil-volume').val(recipeMetrics.WaterMetrics.BoilVolume);
    }

    function getRecipeMetrics(recipeDto) {
        recipeDto.ExpectedABV = $('#expected-abv').val();
        recipeDto.ExpectedOriginalGravity = $('#expected-original-gravity').val();
        recipeDto.ExpectedFinalGravity = $('#expected-final-gravity').val();
        recipeDto.IBU = $('#expected-ibu').val();
        recipeDto.ExpectedBoilGravityPoints = $('#expected-boil-gravity-points').val();
        recipeDto.ExpectedSrm = $('#expected-srm').val();
        recipeDto.WaterMetrics = {};
        recipeDto.WaterMetrics.SpargeVolume = $('#sparge-volume').val();
        recipeDto.WaterMetrics.StrikeTemperature = $('#strike-temperature').val();
        recipeDto.WaterMetrics.StrikeVolume = $('#strike-volume').val();
        recipeDto.WaterMetrics.WaterRequired = $('#water-required').val();
        recipeDto.WaterMetrics.BoilVolume = $('#boil-volume').val();
    }

    function initializeRecipeMetricsModal(recipeMetrics) {
        clearRecipeMetricsModal();
        setRecipeMetrics(recipeMetrics);
    }