using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;

namespace BeerCalculator.Calculators
{
    public class IbuCalculator : IIbuCalculator
    {
        private Dictionary<int, Dictionary<string, decimal>> utilizationTable;

        public decimal TotalAlphaAcidUnits { get; set; }

        public decimal OriginalGravity { get; set; }

        private const decimal volume = 5.0m;

        private const decimal litersToGallons = 75.0m;

        public IbuCalculator()
        {
            InitializeHopUtilizationTable();
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

      
            return ibu;
        }

        private decimal GetUtilization(int timeInBoil)
        {
            decimal utilization = 0.0m;

            Dictionary<string, decimal> table = utilizationTable[timeInBoil];

            string gravityKey = GetGravityKey();

            utilization = table[gravityKey];

         
            return utilization;
        }

        private string GetGravityKey()
        {
            int wholeNumberGravity = (int)(OriginalGravity * 1000);
            int remainder = wholeNumberGravity % 10;

            if (remainder > 4)
            {
                int temp = 10 - remainder;
                wholeNumberGravity += temp;
            }
            else
            {
                int temp = remainder - 10;
                temp *= -1;
                wholeNumberGravity -= temp;
            }

            double gravityKey = (double)wholeNumberGravity / 1000; 

            return gravityKey.ToString("N3");
        }

        private void InitializeHopUtilizationTable()
        {
            utilizationTable = new Dictionary<int, Dictionary<string, decimal>>();

            // 60 minute utilization table
            Dictionary<string, decimal> xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.276m);
            xMinuteUtilizationTable.Add("1.040", 0.252m);
            xMinuteUtilizationTable.Add("1.050", 0.231m);
            xMinuteUtilizationTable.Add("1.060", 0.211m);
            xMinuteUtilizationTable.Add("1.070", 0.193m);
            xMinuteUtilizationTable.Add("1.080", 0.176m);
            xMinuteUtilizationTable.Add("1.090", 0.161m);
            xMinuteUtilizationTable.Add("1.100", 0.147m);
            xMinuteUtilizationTable.Add("1.110", 0.135m);
            xMinuteUtilizationTable.Add("1.120", 0.123m);
            
            utilizationTable.Add(60, xMinuteUtilizationTable);

            // 45 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.253m);
            xMinuteUtilizationTable.Add("1.040", 0.232m);
            xMinuteUtilizationTable.Add("1.050", 0.212m);
            xMinuteUtilizationTable.Add("1.060", 0.194m);
            xMinuteUtilizationTable.Add("1.070", 0.177m);
            xMinuteUtilizationTable.Add("1.080", 0.162m);
            xMinuteUtilizationTable.Add("1.090", 0.148m);
            xMinuteUtilizationTable.Add("1.100", 0.135m);
            xMinuteUtilizationTable.Add("1.110", 0.123m);
            xMinuteUtilizationTable.Add("1.120", 0.113m);

            utilizationTable.Add(45, xMinuteUtilizationTable);

            // 30 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.212m);
            xMinuteUtilizationTable.Add("1.040", 0.194m);
            xMinuteUtilizationTable.Add("1.050", 0.177m);
            xMinuteUtilizationTable.Add("1.060", 0.162m);
            xMinuteUtilizationTable.Add("1.070", 0.148m);
            xMinuteUtilizationTable.Add("1.080", 0.135m);
            xMinuteUtilizationTable.Add("1.090", 0.124m);
            xMinuteUtilizationTable.Add("1.100", 0.113m);
            xMinuteUtilizationTable.Add("1.110", 0.103m);
            xMinuteUtilizationTable.Add("1.120", 0.094m);

            utilizationTable.Add(30, xMinuteUtilizationTable);

            // 15 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.137m);
            xMinuteUtilizationTable.Add("1.040", 0.125m);
            xMinuteUtilizationTable.Add("1.050", 0.114m);
            xMinuteUtilizationTable.Add("1.060", 0.105m);
            xMinuteUtilizationTable.Add("1.070", 0.096m);
            xMinuteUtilizationTable.Add("1.080", 0.087m);
            xMinuteUtilizationTable.Add("1.090", 0.080m);
            xMinuteUtilizationTable.Add("1.100", 0.073m);
            xMinuteUtilizationTable.Add("1.110", 0.067m);
            xMinuteUtilizationTable.Add("1.120", 0.061m);

            utilizationTable.Add(15, xMinuteUtilizationTable);

        }
    }
}
