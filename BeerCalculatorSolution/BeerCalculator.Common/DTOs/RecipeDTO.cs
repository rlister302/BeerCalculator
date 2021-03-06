﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.Interface;
using BeerCalculator.Common.Implementation;

namespace BeerCalculator.Common.DTOs
{
    [Controller("Recipe")]
    [GetAllAction("GetAllRecipes")]
    [GetDetailsAction("GetRecipeDetails")]
    [CreateAction("CreateRecipe")]
    [UpdateAction("UpdateRecipe")]
    [DeleteAction("DeleteRecipe")]
    public class RecipeDTO : ModelBase
    {
        public int RecipeID { get; set; }

        public string RecipeName { get; set; }

        public decimal ExpectedABV { get; set; }

        public decimal? ActualABV { get; set; }

        public decimal ExpectedOriginalGravity { get; set; }

        public decimal? ActualOriginalGravity { get; set; }

        public decimal ExpectedFinalGravity { get; set; }

        public decimal? ActualFinalGravity { get; set; }

        public int IBU { get; set; }

        public int ExpectedMashEfficiency { get; set; }

        public int? AcutalMashEfficiency { get; set; }

        public decimal FinalVolume { get; set; }

        public int ExpectedAttenuation { get; set; }

        public int? ActualAttenuation { get; set; }

        public decimal ExpectedBoilGravityPoints { get; set; }

        public decimal ExpectedSrm { get; set; }

        public WaterMetricsDTO WaterMetrics { get; set; }

        public WaterInputDTO WaterInput { get; set; }

        public DateTime BrewDate { get; set; }

        public List<HopTypeDTO> Hops { get; set; }

        public List<GrainTypeDTO> Grains { get; set; }

        public YeastTypeDTO Yeast { get; set; }
    }
}
