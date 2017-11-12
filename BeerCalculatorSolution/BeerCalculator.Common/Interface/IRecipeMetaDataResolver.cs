using BeerCalculator.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IRecipeMetaDataResolver
    {
        bool ResolveGrainMetaData(List<GrainTypeDTO> grains);

        bool ResolveHopMetaData(List<HopTypeDTO> hops);

        bool ResolveYeastMetaData(YeastTypeDTO yeast);
    }
}
