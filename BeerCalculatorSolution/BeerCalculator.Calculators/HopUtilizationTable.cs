using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public class HopUtilizationTable : IHopUtilizationTable
    {
        public Dictionary<int, Dictionary<string, decimal>> UtilizationTable { get; set; }

        public HopUtilizationTable()
        {
            Initialize();
        }

        public void Initialize()
        {
            UtilizationTable = new Dictionary<int, Dictionary<string, decimal>>();

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

            UtilizationTable.Add(60, xMinuteUtilizationTable);

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

            UtilizationTable.Add(45, xMinuteUtilizationTable);

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

            UtilizationTable.Add(30, xMinuteUtilizationTable);

            // 20 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.167m);
            xMinuteUtilizationTable.Add("1.040", 0.153m);
            xMinuteUtilizationTable.Add("1.050", 0.140m);
            xMinuteUtilizationTable.Add("1.060", 0.128m);
            xMinuteUtilizationTable.Add("1.070", 0.117m);
            xMinuteUtilizationTable.Add("1.080", 0.107m);
            xMinuteUtilizationTable.Add("1.090", 0.098m);
            xMinuteUtilizationTable.Add("1.100", 0.089m);
            xMinuteUtilizationTable.Add("1.110", 0.081m);
            xMinuteUtilizationTable.Add("1.120", 0.074m);

            UtilizationTable.Add(20, xMinuteUtilizationTable);

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

            UtilizationTable.Add(15, xMinuteUtilizationTable);

            // 10 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.100m);
            xMinuteUtilizationTable.Add("1.040", 0.091m);
            xMinuteUtilizationTable.Add("1.050", 0.084m);
            xMinuteUtilizationTable.Add("1.060", 0.076m);
            xMinuteUtilizationTable.Add("1.070", 0.070m);
            xMinuteUtilizationTable.Add("1.080", 0.064m);
            xMinuteUtilizationTable.Add("1.090", 0.058m);
            xMinuteUtilizationTable.Add("1.100", 0.053m);
            xMinuteUtilizationTable.Add("1.110", 0.049m);
            xMinuteUtilizationTable.Add("1.120", 0.045m);

            UtilizationTable.Add(10, xMinuteUtilizationTable);

            // 5 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.055m);
            xMinuteUtilizationTable.Add("1.040", 0.050m);
            xMinuteUtilizationTable.Add("1.050", 0.046m);
            xMinuteUtilizationTable.Add("1.060", 0.042m);
            xMinuteUtilizationTable.Add("1.070", 0.038m);
            xMinuteUtilizationTable.Add("1.080", 0.035m);
            xMinuteUtilizationTable.Add("1.090", 0.032m);
            xMinuteUtilizationTable.Add("1.100", 0.029m);
            xMinuteUtilizationTable.Add("1.110", 0.027m);
            xMinuteUtilizationTable.Add("1.120", 0.025m);

            UtilizationTable.Add(5, xMinuteUtilizationTable);
        }
    }
}
