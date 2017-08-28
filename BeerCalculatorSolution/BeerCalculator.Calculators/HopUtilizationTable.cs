using BeerCalculator.Common.Interface;
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
            // We never have gravity above 1.090 (at least we never have before) so for now initialize utilization tables up to 1.100
            UtilizationTable = new Dictionary<int, Dictionary<string, decimal>>();

            // 60 minute utilization table
            Dictionary<string, decimal> xMinuteUtilizationTable = new Dictionary<string, decimal>();

            #region 60 minute utilization
            xMinuteUtilizationTable.Add("1.030", 0.276m);
            xMinuteUtilizationTable.Add("1.031", 0.274m);
            xMinuteUtilizationTable.Add("1.032", 0.271m);
            xMinuteUtilizationTable.Add("1.033", 0.269m);
            xMinuteUtilizationTable.Add("1.034", 0.266m);
            xMinuteUtilizationTable.Add("1.035", 0.264m);
            xMinuteUtilizationTable.Add("1.036", 0.262m);
            xMinuteUtilizationTable.Add("1.037", 0.259m);
            xMinuteUtilizationTable.Add("1.038", 0.257m);
            xMinuteUtilizationTable.Add("1.039", 0.254m);

            xMinuteUtilizationTable.Add("1.040", 0.252m);
            xMinuteUtilizationTable.Add("1.041", 0.250m);
            xMinuteUtilizationTable.Add("1.042", 0.248m);
            xMinuteUtilizationTable.Add("1.043", 0.246m);
            xMinuteUtilizationTable.Add("1.044", 0.244m);
            xMinuteUtilizationTable.Add("1.045", 0.242m);
            xMinuteUtilizationTable.Add("1.046", 0.239m);
            xMinuteUtilizationTable.Add("1.047", 0.237m);
            xMinuteUtilizationTable.Add("1.048", 0.235m);
            xMinuteUtilizationTable.Add("1.049", 0.233m);

            xMinuteUtilizationTable.Add("1.050", 0.231m);
            xMinuteUtilizationTable.Add("1.051", 0.229m);
            xMinuteUtilizationTable.Add("1.052", 0.227m);
            xMinuteUtilizationTable.Add("1.053", 0.225m);
            xMinuteUtilizationTable.Add("1.054", 0.223m);
            xMinuteUtilizationTable.Add("1.055", 0.221m);
            xMinuteUtilizationTable.Add("1.056", 0.219m);
            xMinuteUtilizationTable.Add("1.057", 0.217m);
            xMinuteUtilizationTable.Add("1.058", 0.215m);
            xMinuteUtilizationTable.Add("1.059", 0.213m);

            xMinuteUtilizationTable.Add("1.060", 0.211m);
            xMinuteUtilizationTable.Add("1.061", 0.209m);
            xMinuteUtilizationTable.Add("1.062", 0.207m);
            xMinuteUtilizationTable.Add("1.063", 0.206m);
            xMinuteUtilizationTable.Add("1.064", 0.204m);
            xMinuteUtilizationTable.Add("1.065", 0.202m);
            xMinuteUtilizationTable.Add("1.066", 0.200m);
            xMinuteUtilizationTable.Add("1.067", 0.198m);
            xMinuteUtilizationTable.Add("1.068", 0.197m);
            xMinuteUtilizationTable.Add("1.069", 0.195m);

            xMinuteUtilizationTable.Add("1.070", 0.193m);
            xMinuteUtilizationTable.Add("1.071", 0.191m);
            xMinuteUtilizationTable.Add("1.072", 0.190m);
            xMinuteUtilizationTable.Add("1.073", 0.188m);
            xMinuteUtilizationTable.Add("1.074", 0.186m);
            xMinuteUtilizationTable.Add("1.075", 0.185m);
            xMinuteUtilizationTable.Add("1.076", 0.183m);
            xMinuteUtilizationTable.Add("1.077", 0.181m);
            xMinuteUtilizationTable.Add("1.078", 0.179m);
            xMinuteUtilizationTable.Add("1.079", 0.178m);

            xMinuteUtilizationTable.Add("1.080", 0.176m);
            xMinuteUtilizationTable.Add("1.081", 0.175m);
            xMinuteUtilizationTable.Add("1.082", 0.173m);
            xMinuteUtilizationTable.Add("1.083", 0.172m);
            xMinuteUtilizationTable.Add("1.084", 0.170m);
            xMinuteUtilizationTable.Add("1.085", 0.169m);
            xMinuteUtilizationTable.Add("1.086", 0.167m);
            xMinuteUtilizationTable.Add("1.087", 0.166m);
            xMinuteUtilizationTable.Add("1.088", 0.164m);
            xMinuteUtilizationTable.Add("1.089", 0.163m);

            xMinuteUtilizationTable.Add("1.090", 0.161m);
            xMinuteUtilizationTable.Add("1.091", 0.160m);
            xMinuteUtilizationTable.Add("1.092", 0.158m);
            xMinuteUtilizationTable.Add("1.093", 0.157m);
            xMinuteUtilizationTable.Add("1.094", 0.155m);
            xMinuteUtilizationTable.Add("1.095", 0.154m);
            xMinuteUtilizationTable.Add("1.096", 0.153m);
            xMinuteUtilizationTable.Add("1.097", 0.151m);
            xMinuteUtilizationTable.Add("1.098", 0.150m);
            xMinuteUtilizationTable.Add("1.099", 0.148m);

            xMinuteUtilizationTable.Add("1.100", 0.147m);
            xMinuteUtilizationTable.Add("1.110", 0.135m);
            xMinuteUtilizationTable.Add("1.120", 0.123m);
            #endregion

            UtilizationTable.Add(60, xMinuteUtilizationTable);

            // 45 minute utilization table
            #region 45 minute utilization
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.253m);
            xMinuteUtilizationTable.Add("1.031", 0.251m);
            xMinuteUtilizationTable.Add("1.032", 0.249m);
            xMinuteUtilizationTable.Add("1.033", 0.247m);
            xMinuteUtilizationTable.Add("1.034", 0.245m);
            xMinuteUtilizationTable.Add("1.035", 0.243m);
            xMinuteUtilizationTable.Add("1.036", 0.240m);
            xMinuteUtilizationTable.Add("1.037", 0.238m);
            xMinuteUtilizationTable.Add("1.038", 0.236m);
            xMinuteUtilizationTable.Add("1.039", 0.234m);

            xMinuteUtilizationTable.Add("1.040", 0.232m);
            xMinuteUtilizationTable.Add("1.041", 0.230m);
            xMinuteUtilizationTable.Add("1.042", 0.228m);
            xMinuteUtilizationTable.Add("1.043", 0.226m);
            xMinuteUtilizationTable.Add("1.044", 0.224m);
            xMinuteUtilizationTable.Add("1.045", 0.222m);
            xMinuteUtilizationTable.Add("1.046", 0.220m);
            xMinuteUtilizationTable.Add("1.047", 0.218m);
            xMinuteUtilizationTable.Add("1.048", 0.216m);
            xMinuteUtilizationTable.Add("1.049", 0.214m);

            xMinuteUtilizationTable.Add("1.050", 0.212m);
            xMinuteUtilizationTable.Add("1.051", 0.210m);
            xMinuteUtilizationTable.Add("1.052", 0.208m);
            xMinuteUtilizationTable.Add("1.053", 0.207m);
            xMinuteUtilizationTable.Add("1.054", 0.205m);
            xMinuteUtilizationTable.Add("1.055", 0.203m);
            xMinuteUtilizationTable.Add("1.056", 0.201m);
            xMinuteUtilizationTable.Add("1.057", 0.199m);
            xMinuteUtilizationTable.Add("1.058", 0.198m);
            xMinuteUtilizationTable.Add("1.059", 0.196m);

            xMinuteUtilizationTable.Add("1.060", 0.194m);
            xMinuteUtilizationTable.Add("1.061", 0.192m);
            xMinuteUtilizationTable.Add("1.062", 0.191m);
            xMinuteUtilizationTable.Add("1.063", 0.189m);
            xMinuteUtilizationTable.Add("1.064", 0.187m);
            xMinuteUtilizationTable.Add("1.065", 0.186m);
            xMinuteUtilizationTable.Add("1.066", 0.184m);
            xMinuteUtilizationTable.Add("1.067", 0.182m);
            xMinuteUtilizationTable.Add("1.068", 0.180m);
            xMinuteUtilizationTable.Add("1.069", 0.179m);

            xMinuteUtilizationTable.Add("1.070", 0.177m);
            xMinuteUtilizationTable.Add("1.071", 0.176m);
            xMinuteUtilizationTable.Add("1.072", 0.174m);
            xMinuteUtilizationTable.Add("1.073", 0.173m);
            xMinuteUtilizationTable.Add("1.074", 0.171m);
            xMinuteUtilizationTable.Add("1.075", 0.170m);
            xMinuteUtilizationTable.Add("1.076", 0.168m);
            xMinuteUtilizationTable.Add("1.077", 0.167m);
            xMinuteUtilizationTable.Add("1.078", 0.165m);
            xMinuteUtilizationTable.Add("1.079", 0.164m);

            xMinuteUtilizationTable.Add("1.080", 0.162m);
            xMinuteUtilizationTable.Add("1.081", 0.161m);
            xMinuteUtilizationTable.Add("1.082", 0.159m);
            xMinuteUtilizationTable.Add("1.083", 0.158m);
            xMinuteUtilizationTable.Add("1.084", 0.156m);
            xMinuteUtilizationTable.Add("1.085", 0.155m);
            xMinuteUtilizationTable.Add("1.086", 0.154m);
            xMinuteUtilizationTable.Add("1.087", 0.152m);
            xMinuteUtilizationTable.Add("1.088", 0.151m);
            xMinuteUtilizationTable.Add("1.089", 0.149m);

            xMinuteUtilizationTable.Add("1.090", 0.148m);
            xMinuteUtilizationTable.Add("1.091", 0.147m);
            xMinuteUtilizationTable.Add("1.092", 0.145m);
            xMinuteUtilizationTable.Add("1.093", 0.144m);
            xMinuteUtilizationTable.Add("1.094", 0.143m);
            xMinuteUtilizationTable.Add("1.095", 0.142m);
            xMinuteUtilizationTable.Add("1.096", 0.140m);
            xMinuteUtilizationTable.Add("1.097", 0.139m);
            xMinuteUtilizationTable.Add("1.098", 0.138m);
            xMinuteUtilizationTable.Add("1.099", 0.136m);

            xMinuteUtilizationTable.Add("1.100", 0.135m);
            xMinuteUtilizationTable.Add("1.110", 0.123m);
            xMinuteUtilizationTable.Add("1.120", 0.113m);
            #endregion

            UtilizationTable.Add(45, xMinuteUtilizationTable);

            // 30 minute utilization table
            #region 30 minute utilization
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.212m);
            xMinuteUtilizationTable.Add("1.031", 0.210m);
            xMinuteUtilizationTable.Add("1.032", 0.208m);
            xMinuteUtilizationTable.Add("1.033", 0.207m);
            xMinuteUtilizationTable.Add("1.034", 0.205m);
            xMinuteUtilizationTable.Add("1.035", 0.203m);
            xMinuteUtilizationTable.Add("1.036", 0.201m);
            xMinuteUtilizationTable.Add("1.037", 0.199m);
            xMinuteUtilizationTable.Add("1.038", 0.198m);
            xMinuteUtilizationTable.Add("1.039", 0.196m);

            xMinuteUtilizationTable.Add("1.040", 0.194m);
            xMinuteUtilizationTable.Add("1.041", 0.192m);
            xMinuteUtilizationTable.Add("1.042", 0.191m);
            xMinuteUtilizationTable.Add("1.043", 0.189m);
            xMinuteUtilizationTable.Add("1.044", 0.187m);
            xMinuteUtilizationTable.Add("1.045", 0.186m);
            xMinuteUtilizationTable.Add("1.046", 0.184m);
            xMinuteUtilizationTable.Add("1.047", 0.182m);
            xMinuteUtilizationTable.Add("1.048", 0.180m);
            xMinuteUtilizationTable.Add("1.049", 0.179m);

            xMinuteUtilizationTable.Add("1.050", 0.177m);
            xMinuteUtilizationTable.Add("1.051", 0.176m);
            xMinuteUtilizationTable.Add("1.052", 0.174m);
            xMinuteUtilizationTable.Add("1.053", 0.173m);
            xMinuteUtilizationTable.Add("1.054", 0.171m);
            xMinuteUtilizationTable.Add("1.055", 0.170m);
            xMinuteUtilizationTable.Add("1.056", 0.168m);
            xMinuteUtilizationTable.Add("1.057", 0.167m);
            xMinuteUtilizationTable.Add("1.058", 0.165m);
            xMinuteUtilizationTable.Add("1.059", 0.164m);

            xMinuteUtilizationTable.Add("1.060", 0.162m);
            xMinuteUtilizationTable.Add("1.061", 0.161m);
            xMinuteUtilizationTable.Add("1.062", 0.159m);
            xMinuteUtilizationTable.Add("1.063", 0.158m);
            xMinuteUtilizationTable.Add("1.064", 0.156m);
            xMinuteUtilizationTable.Add("1.065", 0.155m);
            xMinuteUtilizationTable.Add("1.066", 0.154m);
            xMinuteUtilizationTable.Add("1.067", 0.152m);
            xMinuteUtilizationTable.Add("1.068", 0.151m);
            xMinuteUtilizationTable.Add("1.069", 0.149m);

            xMinuteUtilizationTable.Add("1.070", 0.148m);
            xMinuteUtilizationTable.Add("1.071", 0.147m);
            xMinuteUtilizationTable.Add("1.072", 0.145m);
            xMinuteUtilizationTable.Add("1.073", 0.144m);
            xMinuteUtilizationTable.Add("1.074", 0.143m);
            xMinuteUtilizationTable.Add("1.075", 0.142m);
            xMinuteUtilizationTable.Add("1.076", 0.140m);
            xMinuteUtilizationTable.Add("1.077", 0.139m);
            xMinuteUtilizationTable.Add("1.078", 0.138m);
            xMinuteUtilizationTable.Add("1.079", 0.136m);

            xMinuteUtilizationTable.Add("1.080", 0.135m);
            xMinuteUtilizationTable.Add("1.081", 0.134m);
            xMinuteUtilizationTable.Add("1.082", 0.133m);
            xMinuteUtilizationTable.Add("1.083", 0.132m);
            xMinuteUtilizationTable.Add("1.084", 0.131m);
            xMinuteUtilizationTable.Add("1.085", 0.130m);
            xMinuteUtilizationTable.Add("1.086", 0.128m);
            xMinuteUtilizationTable.Add("1.087", 0.127m);
            xMinuteUtilizationTable.Add("1.088", 0.126m);
            xMinuteUtilizationTable.Add("1.089", 0.125m);

            xMinuteUtilizationTable.Add("1.090", 0.124m);
            xMinuteUtilizationTable.Add("1.091", 0.123m);
            xMinuteUtilizationTable.Add("1.092", 0.122m);
            xMinuteUtilizationTable.Add("1.093", 0.121m);
            xMinuteUtilizationTable.Add("1.094", 0.120m);
            xMinuteUtilizationTable.Add("1.095", 0.119m);
            xMinuteUtilizationTable.Add("1.096", 0.117m);
            xMinuteUtilizationTable.Add("1.097", 0.116m);
            xMinuteUtilizationTable.Add("1.098", 0.115m);
            xMinuteUtilizationTable.Add("1.099", 0.114m);

            xMinuteUtilizationTable.Add("1.100", 0.113m);
            xMinuteUtilizationTable.Add("1.110", 0.103m);
            xMinuteUtilizationTable.Add("1.120", 0.094m);
            #endregion

            UtilizationTable.Add(30, xMinuteUtilizationTable);

            // 20 minute utilization table
            #region 20 minute utilization 
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            //xMinuteUtilizationTable.Add("1.030", 0.167m);
            //xMinuteUtilizationTable.Add("1.040", 0.153m);
            //xMinuteUtilizationTable.Add("1.050", 0.140m);
            //xMinuteUtilizationTable.Add("1.060", 0.128m);
            //xMinuteUtilizationTable.Add("1.070", 0.117m);
            //xMinuteUtilizationTable.Add("1.080", 0.107m);
            //xMinuteUtilizationTable.Add("1.090", 0.098m);
            xMinuteUtilizationTable.Add("1.030", 0.167m);
            xMinuteUtilizationTable.Add("1.031", 0.166m);
            xMinuteUtilizationTable.Add("1.032", 0.164m);
            xMinuteUtilizationTable.Add("1.033", 0.163m);
            xMinuteUtilizationTable.Add("1.034", 0.161m);
            xMinuteUtilizationTable.Add("1.035", 0.160m);
            xMinuteUtilizationTable.Add("1.036", 0.159m);
            xMinuteUtilizationTable.Add("1.037", 0.157m);
            xMinuteUtilizationTable.Add("1.038", 0.156m);
            xMinuteUtilizationTable.Add("1.039", 0.154m);

            xMinuteUtilizationTable.Add("1.040", 0.153m);
            xMinuteUtilizationTable.Add("1.041", 0.152m);
            xMinuteUtilizationTable.Add("1.042", 0.150m);
            xMinuteUtilizationTable.Add("1.043", 0.149m);
            xMinuteUtilizationTable.Add("1.044", 0.148m);
            xMinuteUtilizationTable.Add("1.045", 0.147m);
            xMinuteUtilizationTable.Add("1.046", 0.145m);
            xMinuteUtilizationTable.Add("1.047", 0.144m);
            xMinuteUtilizationTable.Add("1.048", 0.143m);
            xMinuteUtilizationTable.Add("1.049", 0.141m);

            xMinuteUtilizationTable.Add("1.050", 0.140m);
            xMinuteUtilizationTable.Add("1.051", 0.139m);
            xMinuteUtilizationTable.Add("1.052", 0.138m);
            xMinuteUtilizationTable.Add("1.053", 0.136m);
            xMinuteUtilizationTable.Add("1.054", 0.135m);
            xMinuteUtilizationTable.Add("1.055", 0.134m);
            xMinuteUtilizationTable.Add("1.056", 0.133m);
            xMinuteUtilizationTable.Add("1.057", 0.132m);
            xMinuteUtilizationTable.Add("1.058", 0.130m);
            xMinuteUtilizationTable.Add("1.059", 0.129m);

            xMinuteUtilizationTable.Add("1.060", 0.128m);
            xMinuteUtilizationTable.Add("1.061", 0.127m);
            xMinuteUtilizationTable.Add("1.062", 0.126m);
            xMinuteUtilizationTable.Add("1.063", 0.125m);
            xMinuteUtilizationTable.Add("1.064", 0.124m);
            xMinuteUtilizationTable.Add("1.065", 0.123m);
            xMinuteUtilizationTable.Add("1.066", 0.121m);
            xMinuteUtilizationTable.Add("1.067", 0.120m);
            xMinuteUtilizationTable.Add("1.068", 0.119m);
            xMinuteUtilizationTable.Add("1.069", 0.118m);

            xMinuteUtilizationTable.Add("1.070", 0.117m);
            xMinuteUtilizationTable.Add("1.071", 0.116m);
            xMinuteUtilizationTable.Add("1.072", 0.115m);
            xMinuteUtilizationTable.Add("1.073", 0.114m);
            xMinuteUtilizationTable.Add("1.074", 0.113m);
            xMinuteUtilizationTable.Add("1.075", 0.112m);
            xMinuteUtilizationTable.Add("1.076", 0.111m);
            xMinuteUtilizationTable.Add("1.077", 0.110m);
            xMinuteUtilizationTable.Add("1.078", 0.109m);
            xMinuteUtilizationTable.Add("1.079", 0.108m);

            xMinuteUtilizationTable.Add("1.080", 0.107m);
            xMinuteUtilizationTable.Add("1.081", 0.106m);
            xMinuteUtilizationTable.Add("1.082", 0.105m);
            xMinuteUtilizationTable.Add("1.083", 0.104m);
            xMinuteUtilizationTable.Add("1.084", 0.103m);
            xMinuteUtilizationTable.Add("1.085", 0.103m);
            xMinuteUtilizationTable.Add("1.086", 0.102m);
            xMinuteUtilizationTable.Add("1.087", 0.101m);
            xMinuteUtilizationTable.Add("1.088", 0.100m);
            xMinuteUtilizationTable.Add("1.089", 0.099m);

            xMinuteUtilizationTable.Add("1.090", 0.098m);
            xMinuteUtilizationTable.Add("1.091", 0.097m);
            xMinuteUtilizationTable.Add("1.092", 0.096m);
            xMinuteUtilizationTable.Add("1.093", 0.095m);
            xMinuteUtilizationTable.Add("1.094", 0.094m);
            xMinuteUtilizationTable.Add("1.095", 0.094m);
            xMinuteUtilizationTable.Add("1.096", 0.093m);
            xMinuteUtilizationTable.Add("1.097", 0.092m);
            xMinuteUtilizationTable.Add("1.098", 0.091m);
            xMinuteUtilizationTable.Add("1.099", 0.090m);

            xMinuteUtilizationTable.Add("1.100", 0.098m);
            xMinuteUtilizationTable.Add("1.110", 0.098m);
            xMinuteUtilizationTable.Add("1.120", 0.098m);
            #endregion

            UtilizationTable.Add(20, xMinuteUtilizationTable);

            // 15 minute utilization table
            #region 15 minute utilization
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
            xMinuteUtilizationTable.Add("1.030", 0.137m);
            xMinuteUtilizationTable.Add("1.031", 0.136m);
            xMinuteUtilizationTable.Add("1.032", 0.135m);
            xMinuteUtilizationTable.Add("1.033", 0.133m);
            xMinuteUtilizationTable.Add("1.034", 0.132m);
            xMinuteUtilizationTable.Add("1.035", 0.131m);
            xMinuteUtilizationTable.Add("1.036", 0.130m);
            xMinuteUtilizationTable.Add("1.037", 0.129m);
            xMinuteUtilizationTable.Add("1.038", 0.127m);
            xMinuteUtilizationTable.Add("1.039", 0.126m);

            xMinuteUtilizationTable.Add("1.040", 0.125m);
            xMinuteUtilizationTable.Add("1.041", 0.124m);
            xMinuteUtilizationTable.Add("1.042", 0.123m);
            xMinuteUtilizationTable.Add("1.043", 0.122m);
            xMinuteUtilizationTable.Add("1.044", 0.121m);
            xMinuteUtilizationTable.Add("1.045", 0.120m);
            xMinuteUtilizationTable.Add("1.046", 0.118m);
            xMinuteUtilizationTable.Add("1.047", 0.117m);
            xMinuteUtilizationTable.Add("1.048", 0.116m);
            xMinuteUtilizationTable.Add("1.049", 0.115m);

            xMinuteUtilizationTable.Add("1.050", 0.114m);
            xMinuteUtilizationTable.Add("1.051", 0.113m);
            xMinuteUtilizationTable.Add("1.052", 0.112m);
            xMinuteUtilizationTable.Add("1.053", 0.111m);
            xMinuteUtilizationTable.Add("1.054", 0.110m);
            xMinuteUtilizationTable.Add("1.055", 0.110m);
            xMinuteUtilizationTable.Add("1.056", 0.109m);
            xMinuteUtilizationTable.Add("1.057", 0.108m);
            xMinuteUtilizationTable.Add("1.058", 0.107m);
            xMinuteUtilizationTable.Add("1.059", 0.106m);

            xMinuteUtilizationTable.Add("1.060", 0.105m);
            xMinuteUtilizationTable.Add("1.061", 0.104m);
            xMinuteUtilizationTable.Add("1.062", 0.103m);
            xMinuteUtilizationTable.Add("1.063", 0.102m);
            xMinuteUtilizationTable.Add("1.064", 0.101m);
            xMinuteUtilizationTable.Add("1.065", 0.101m);
            xMinuteUtilizationTable.Add("1.066", 0.100m);
            xMinuteUtilizationTable.Add("1.067", 0.099m);
            xMinuteUtilizationTable.Add("1.068", 0.098m);
            xMinuteUtilizationTable.Add("1.069", 0.097m);

            xMinuteUtilizationTable.Add("1.070", 0.096m);
            xMinuteUtilizationTable.Add("1.071", 0.095m);
            xMinuteUtilizationTable.Add("1.072", 0.094m);
            xMinuteUtilizationTable.Add("1.073", 0.093m);
            xMinuteUtilizationTable.Add("1.074", 0.092m);
            xMinuteUtilizationTable.Add("1.075", 0.092m);
            xMinuteUtilizationTable.Add("1.076", 0.091m);
            xMinuteUtilizationTable.Add("1.077", 0.090m);
            xMinuteUtilizationTable.Add("1.078", 0.089m);
            xMinuteUtilizationTable.Add("1.079", 0.088m);

            xMinuteUtilizationTable.Add("1.080", 0.087m);
            xMinuteUtilizationTable.Add("1.081", 0.086m);
            xMinuteUtilizationTable.Add("1.082", 0.086m);
            xMinuteUtilizationTable.Add("1.083", 0.085m);
            xMinuteUtilizationTable.Add("1.084", 0.084m);
            xMinuteUtilizationTable.Add("1.085", 0.084m);
            xMinuteUtilizationTable.Add("1.086", 0.083m);
            xMinuteUtilizationTable.Add("1.087", 0.082m);
            xMinuteUtilizationTable.Add("1.088", 0.081m);
            xMinuteUtilizationTable.Add("1.089", 0.081m);

            xMinuteUtilizationTable.Add("1.090", 0.080m);
            xMinuteUtilizationTable.Add("1.091", 0.079m);
            xMinuteUtilizationTable.Add("1.092", 0.079m);
            xMinuteUtilizationTable.Add("1.093", 0.078m);
            xMinuteUtilizationTable.Add("1.094", 0.077m);
            xMinuteUtilizationTable.Add("1.095", 0.077m);
            xMinuteUtilizationTable.Add("1.096", 0.076m);
            xMinuteUtilizationTable.Add("1.097", 0.075m);
            xMinuteUtilizationTable.Add("1.098", 0.074m);
            xMinuteUtilizationTable.Add("1.099", 0.074m);

            xMinuteUtilizationTable.Add("1.100", 0.073m);
            xMinuteUtilizationTable.Add("1.110", 0.067m);
            xMinuteUtilizationTable.Add("1.120", 0.061m);
            #endregion

            UtilizationTable.Add(15, xMinuteUtilizationTable);

            #region 10 minute utilization
            // 10 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();
  
            xMinuteUtilizationTable.Add("1.030", 0.100m);
            xMinuteUtilizationTable.Add("1.031", 0.099m);
            xMinuteUtilizationTable.Add("1.032", 0.098m);
            xMinuteUtilizationTable.Add("1.033", 0.097m);
            xMinuteUtilizationTable.Add("1.034", 0.096m);
            xMinuteUtilizationTable.Add("1.035", 0.096m);
            xMinuteUtilizationTable.Add("1.036", 0.095m);
            xMinuteUtilizationTable.Add("1.037", 0.094m);
            xMinuteUtilizationTable.Add("1.038", 0.093m);
            xMinuteUtilizationTable.Add("1.039", 0.092m);

            xMinuteUtilizationTable.Add("1.040", 0.091m);
            xMinuteUtilizationTable.Add("1.041", 0.090m);
            xMinuteUtilizationTable.Add("1.042", 0.090m);
            xMinuteUtilizationTable.Add("1.043", 0.089m);
            xMinuteUtilizationTable.Add("1.044", 0.088m);
            xMinuteUtilizationTable.Add("1.045", 0.088m);
            xMinuteUtilizationTable.Add("1.046", 0.087m);
            xMinuteUtilizationTable.Add("1.047", 0.086m);
            xMinuteUtilizationTable.Add("1.048", 0.085m);
            xMinuteUtilizationTable.Add("1.049", 0.085m);

            xMinuteUtilizationTable.Add("1.050", 0.084m);
            xMinuteUtilizationTable.Add("1.051", 0.083m);
            xMinuteUtilizationTable.Add("1.052", 0.082m);
            xMinuteUtilizationTable.Add("1.053", 0.082m);
            xMinuteUtilizationTable.Add("1.054", 0.081m);
            xMinuteUtilizationTable.Add("1.055", 0.080m);
            xMinuteUtilizationTable.Add("1.056", 0.079m);
            xMinuteUtilizationTable.Add("1.057", 0.078m);
            xMinuteUtilizationTable.Add("1.058", 0.078m);
            xMinuteUtilizationTable.Add("1.059", 0.077m);

            xMinuteUtilizationTable.Add("1.060", 0.076m);
            xMinuteUtilizationTable.Add("1.061", 0.075m);
            xMinuteUtilizationTable.Add("1.062", 0.075m);
            xMinuteUtilizationTable.Add("1.063", 0.074m);
            xMinuteUtilizationTable.Add("1.064", 0.074m);
            xMinuteUtilizationTable.Add("1.065", 0.073m);
            xMinuteUtilizationTable.Add("1.066", 0.072m);
            xMinuteUtilizationTable.Add("1.067", 0.072m);
            xMinuteUtilizationTable.Add("1.068", 0.071m);
            xMinuteUtilizationTable.Add("1.069", 0.071m);

            xMinuteUtilizationTable.Add("1.070", 0.070m);
            xMinuteUtilizationTable.Add("1.071", 0.069m);
            xMinuteUtilizationTable.Add("1.072", 0.069m);
            xMinuteUtilizationTable.Add("1.073", 0.068m);
            xMinuteUtilizationTable.Add("1.074", 0.068m);
            xMinuteUtilizationTable.Add("1.075", 0.067m);
            xMinuteUtilizationTable.Add("1.076", 0.066m);
            xMinuteUtilizationTable.Add("1.077", 0.066m);
            xMinuteUtilizationTable.Add("1.078", 0.065m);
            xMinuteUtilizationTable.Add("1.079", 0.065m);

            xMinuteUtilizationTable.Add("1.080", 0.064m);
            xMinuteUtilizationTable.Add("1.081", 0.063m);
            xMinuteUtilizationTable.Add("1.082", 0.063m);
            xMinuteUtilizationTable.Add("1.083", 0.062m);
            xMinuteUtilizationTable.Add("1.084", 0.062m);
            xMinuteUtilizationTable.Add("1.085", 0.061m);
            xMinuteUtilizationTable.Add("1.086", 0.060m);
            xMinuteUtilizationTable.Add("1.087", 0.060m);
            xMinuteUtilizationTable.Add("1.088", 0.059m);
            xMinuteUtilizationTable.Add("1.089", 0.058m);

            xMinuteUtilizationTable.Add("1.090", 0.058m);
            xMinuteUtilizationTable.Add("1.091", 0.058m);
            xMinuteUtilizationTable.Add("1.092", 0.057m);
            xMinuteUtilizationTable.Add("1.093", 0.057m);
            xMinuteUtilizationTable.Add("1.094", 0.056m);
            xMinuteUtilizationTable.Add("1.095", 0.056m);
            xMinuteUtilizationTable.Add("1.096", 0.055m);
            xMinuteUtilizationTable.Add("1.097", 0.055m);
            xMinuteUtilizationTable.Add("1.098", 0.054m);
            xMinuteUtilizationTable.Add("1.099", 0.054m);

            xMinuteUtilizationTable.Add("1.100", 0.053m);
            xMinuteUtilizationTable.Add("1.110", 0.049m);
            xMinuteUtilizationTable.Add("1.120", 0.045m);
            #endregion

            UtilizationTable.Add(10, xMinuteUtilizationTable);

            // 5 minute utilization table
            xMinuteUtilizationTable = new Dictionary<string, decimal>();

            #region 5 minute utilization
            xMinuteUtilizationTable.Add("1.030", 0.055m);
            xMinuteUtilizationTable.Add("1.031", 0.055m);
            xMinuteUtilizationTable.Add("1.032", 0.054m);
            xMinuteUtilizationTable.Add("1.033", 0.054m);
            xMinuteUtilizationTable.Add("1.034", 0.053m);
            xMinuteUtilizationTable.Add("1.035", 0.053m);
            xMinuteUtilizationTable.Add("1.036", 0.052m);
            xMinuteUtilizationTable.Add("1.037", 0.052m);
            xMinuteUtilizationTable.Add("1.038", 0.051m);
            xMinuteUtilizationTable.Add("1.039", 0.051m);

            xMinuteUtilizationTable.Add("1.040", 0.050m);
            xMinuteUtilizationTable.Add("1.041", 0.050m);
            xMinuteUtilizationTable.Add("1.042", 0.049m);
            xMinuteUtilizationTable.Add("1.043", 0.049m);
            xMinuteUtilizationTable.Add("1.044", 0.048m);
            xMinuteUtilizationTable.Add("1.045", 0.048m);
            xMinuteUtilizationTable.Add("1.046", 0.048m);
            xMinuteUtilizationTable.Add("1.047", 0.047m);
            xMinuteUtilizationTable.Add("1.048", 0.047m);
            xMinuteUtilizationTable.Add("1.049", 0.046m);

            xMinuteUtilizationTable.Add("1.050", 0.046m);
            xMinuteUtilizationTable.Add("1.051", 0.046m);
            xMinuteUtilizationTable.Add("1.052", 0.045m);
            xMinuteUtilizationTable.Add("1.053", 0.045m);
            xMinuteUtilizationTable.Add("1.054", 0.044m);
            xMinuteUtilizationTable.Add("1.055", 0.044m);
            xMinuteUtilizationTable.Add("1.056", 0.044m);
            xMinuteUtilizationTable.Add("1.057", 0.043m);
            xMinuteUtilizationTable.Add("1.058", 0.043m);
            xMinuteUtilizationTable.Add("1.059", 0.042m);

            xMinuteUtilizationTable.Add("1.060", 0.042m);
            xMinuteUtilizationTable.Add("1.061", 0.042m);
            xMinuteUtilizationTable.Add("1.062", 0.041m);
            xMinuteUtilizationTable.Add("1.063", 0.041m);
            xMinuteUtilizationTable.Add("1.064", 0.040m);
            xMinuteUtilizationTable.Add("1.065", 0.040m);
            xMinuteUtilizationTable.Add("1.066", 0.040m);
            xMinuteUtilizationTable.Add("1.067", 0.039m);
            xMinuteUtilizationTable.Add("1.068", 0.039m);
            xMinuteUtilizationTable.Add("1.069", 0.038m);

            xMinuteUtilizationTable.Add("1.070", 0.038m);
            xMinuteUtilizationTable.Add("1.071", 0.038m);
            xMinuteUtilizationTable.Add("1.072", 0.037m);
            xMinuteUtilizationTable.Add("1.073", 0.037m);
            xMinuteUtilizationTable.Add("1.074", 0.037m);
            xMinuteUtilizationTable.Add("1.075", 0.037m);
            xMinuteUtilizationTable.Add("1.076", 0.036m);
            xMinuteUtilizationTable.Add("1.077", 0.036m);
            xMinuteUtilizationTable.Add("1.078", 0.036m);
            xMinuteUtilizationTable.Add("1.079", 0.035m);

            xMinuteUtilizationTable.Add("1.080", 0.035m);
            xMinuteUtilizationTable.Add("1.081", 0.035m);
            xMinuteUtilizationTable.Add("1.082", 0.034m);
            xMinuteUtilizationTable.Add("1.083", 0.034m);
            xMinuteUtilizationTable.Add("1.084", 0.034m);
            xMinuteUtilizationTable.Add("1.085", 0.034m);
            xMinuteUtilizationTable.Add("1.086", 0.033m);
            xMinuteUtilizationTable.Add("1.087", 0.033m);
            xMinuteUtilizationTable.Add("1.088", 0.033m);
            xMinuteUtilizationTable.Add("1.089", 0.032m);

            xMinuteUtilizationTable.Add("1.090", 0.032m);
            xMinuteUtilizationTable.Add("1.091", 0.032m);
            xMinuteUtilizationTable.Add("1.092", 0.031m);
            xMinuteUtilizationTable.Add("1.093", 0.031m);
            xMinuteUtilizationTable.Add("1.094", 0.031m);
            xMinuteUtilizationTable.Add("1.095", 0.031m);
            xMinuteUtilizationTable.Add("1.096", 0.030m);
            xMinuteUtilizationTable.Add("1.097", 0.030m);
            xMinuteUtilizationTable.Add("1.098", 0.030m);
            xMinuteUtilizationTable.Add("1.099", 0.029m);

            xMinuteUtilizationTable.Add("1.100", 0.000m);
            xMinuteUtilizationTable.Add("1.110", 0.027m);
            xMinuteUtilizationTable.Add("1.120", 0.025m);
            #endregion

            UtilizationTable.Add(5, xMinuteUtilizationTable);
        }
    }
}
