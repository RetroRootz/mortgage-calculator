using MortgageCalculator.Interfaces;
using MortgageCalculator.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestCalclulator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CanGetRepaymentNoDeposit()
        {
            ICalculatorService _service = new CalculatorService();
            var monthlyRepayments = await _service.GetMonthlyRepayments(new MortgageCalculator.Models.CalcValuesRequestModel
            {
                Deposit = 0,
                InterestRate = 12,
                LoanTerm = 20,
                PurchasePrice = 2_000_000
            });
            Assert.AreEqual(22_021.72, monthlyRepayments);
        }
        [Test]
        public async Task CanGetRepaymentWithDeposit()
        {
            ICalculatorService _service = new CalculatorService();
            var monthlyRepayments = await _service.GetMonthlyRepayments(new MortgageCalculator.Models.CalcValuesRequestModel
            {
                Deposit = 100_000,
                InterestRate = 12,
                LoanTerm = 20,
                PurchasePrice = 2_000_000
            });
            Assert.AreEqual(20_920.64, monthlyRepayments);
        }
    }
}