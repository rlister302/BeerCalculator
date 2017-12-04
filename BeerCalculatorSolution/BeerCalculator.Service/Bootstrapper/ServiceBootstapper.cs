using BeerCalculator.Calculators.Implementation;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Interface;
using BeerCalculator.DataAccessLayer;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.DataAccessLayer.DataAccess.Implementation;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using BeerCalculator.Service.Converter;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerCalculator.Service.Bootstrapper
{
    public class ServiceBootstapper : BootStrapper
    {
        public ServiceBootstapper(IUnityContainer container, IServiceLocator locator) : base(container, locator)
        {

        }

        public override void RegisterServices()
        {
            Container.RegisterType<IIbuCalculator, LaymanIbuCalculator>();
            Container.RegisterType<IGravityCalculator, GravityCalculator>();
            Container.RegisterType<IHopUtilizationTable, HopUtilizationTable>();
            Container.RegisterType<IAttenuationCalculator, AttenuationCalculator>();
            Container.RegisterType<IAbvCalculator, AbvCalculator>();
            Container.RegisterType<ISrmCalculator, SrmCalculator>();
            Container.RegisterType<IWaterCalculator, WaterCalculator>();
            Container.RegisterType<IRecipeMetaDataResolver, RecipeMetaDataResolver>();
            Container.RegisterType<IBeerMetricsCalculator, BeerMetricsCalculator>();
            Container.RegisterType<IConverter, RecipeInputConverter>();
            Container.RegisterType<IDataAccess<RecipeDTO, Recipe>, RecipeDataAccess>();
            Container.RegisterType<IDataAccess<IngredientDTO, Recipe>, IngredientDataAccess>();
            Container.RegisterType<IDataAccess<GrainTypeDTO, GrainType>, GrainTypeDataAccess>();
            Container.RegisterType<IDataAccess<YeastTypeDTO, YeastType>, YeastTypeDataAccess>();
            Container.RegisterType<IDataAccess<HopTypeDTO, HopType>, HopTypeDataAccess>();
        }
    }
}