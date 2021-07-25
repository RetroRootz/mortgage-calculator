using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Models
{
    public class CalcValuesRequestModel
    {
        [JsonProperty("purchasePrice")]
        public double PurchasePrice { get; set; }

        [JsonProperty("deposit")]
        public double Deposit { get; set; }

        [JsonProperty("loanTerm")]
        public int LoanTerm { get; set; }

        [JsonProperty("interestRate")]
        public double InterestRate { get; set; }
    }
}
