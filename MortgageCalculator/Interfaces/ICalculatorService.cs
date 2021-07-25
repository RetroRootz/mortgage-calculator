using MortgageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Interfaces
{
    public interface ICalculatorService
    {
        Task<decimal> GetMonthlyRepayments(CalcValuesRequestModel values);
        Task<bool> SaveUserDetails(RegistrationRequestModel details);
    }
}
