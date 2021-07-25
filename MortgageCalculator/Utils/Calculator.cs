using MortgageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Utils
{
    public class Calculator
    {
        public static decimal GetBondRepayments(CalcValuesRequestModel values)
        {
            if (values == null)
                return 0;

            var deposit = values.Deposit;
            var loanAmount = values.PurchasePrice - deposit;
            var interest = values.InterestRate;
            var numberOfYears = values.LoanTerm;

            var rateOfInterest = interest / 1200;
            var numberOfPayments = numberOfYears * 12;

            var paymentAmount = (rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, numberOfPayments * -1));

            return decimal.Round(Convert.ToDecimal(paymentAmount), 2);
        }
    }
}
