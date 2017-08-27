﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;

namespace BeerCalculator.Calculators
{
    public class IbuCalculator : IIbuCalculator
    {
        public IHopUtilizationTable HopUtilizationTable { get; set; }

        public decimal TotalAlphaAcidUnits { get; set; }

        public decimal OriginalGravity { get; set; }

        public int ExpectedIbu { get; set; }

        private const decimal volume = 5.0m;

        private const decimal litersToGallons = 75.0m;

        public IbuCalculator(IHopUtilizationTable table)
        {
            HopUtilizationTable = table;
        }

        public int Calculate(List<HopTypeDTO> hops, decimal originalGravity)
        {
            OriginalGravity = originalGravity;
            TotalAlphaAcidUnits = 0;
            int ibu = 0;

            decimal alphaAcidUnits = 0.0m;

            foreach (HopTypeDTO hop in hops)
            {
                alphaAcidUnits = (hop.Amount * hop.AlphaAcid);
                TotalAlphaAcidUnits += alphaAcidUnits;
                decimal utilization = GetUtilization(hop.BoilTime);

                decimal rawValue = (alphaAcidUnits * utilization * litersToGallons) / volume;

                ibu += (int)decimal.Round(rawValue,0);
            }

            ExpectedIbu = ibu;
      
            return ibu;
        }

        private decimal GetUtilization(int timeInBoil)
        {
            decimal utilization = 0.0m;

            if (timeInBoil > 0)
            {
                Dictionary<string, decimal> table = HopUtilizationTable.UtilizationTable[timeInBoil];

                string gravityKey = OriginalGravity.ToString();

                utilization = table[gravityKey];
            }

            return utilization;
        }

 
    }
}