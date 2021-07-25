using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Models
{
    public class CalcValuesResponseModel
    {
        [JsonProperty("bondRepayment")]
        public double BondRepayment { get; set; }
    }
}
