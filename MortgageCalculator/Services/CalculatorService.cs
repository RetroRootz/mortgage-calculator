using MortgageCalculator.DataAccess;
using MortgageCalculator.Interfaces;
using MortgageCalculator.Models;
using MortgageCalculator.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<decimal> GetMonthlyRepayments(CalcValuesRequestModel values)
        {
            if (values == null)
                return 0;

            var bondRepayments = Calculator.GetBondRepayments(values);

            return bondRepayments;
        }

        public async Task<bool> SaveUserDetails(RegistrationRequestModel details)
        {
            if(details == null)
            {
                Log.Error("Error being thrown in SaveUserDetails: User details returned null or empty");
                return false;
            }

            try
            {
                var saveUserDetails = await UserDataAccess.SaveUserDetails(details);

                if (saveUserDetails > 0)
                    return true;
                else
                    return false;
  
            }
            catch(Exception ex)
            {
                Log.Error($"Error being thrown in SaveUserDetails: Failed to save user details {ex.Message}");
                return false;
            }
        }
    }
}
