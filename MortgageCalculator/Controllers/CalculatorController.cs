using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageCalculator.Interfaces;
using MortgageCalculator.Models;
using Serilog;

namespace MortgageCalculator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _service;

        public CalculatorController(ICalculatorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CalculateMortgage([FromBody] CalcValuesRequestModel values)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var monthlyRepayments = await _service.GetMonthlyRepayments(values);

                return new JsonResult(monthlyRepayments);

            }
            catch(Exception ex)
            {
                Log.Error($"Error being thrown in CalculateMortgage: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to calculate mortgage");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegistrationRequestModel details)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var saveUserDetails = await _service.SaveUserDetails(details);

                if (saveUserDetails == false)
                    return StatusCode(StatusCodes.Status400BadRequest, "Failed to save user details");

                return StatusCode(StatusCodes.Status200OK, "User details have been saved successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"Error being thrown in Register method: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save user details");
            }
        }
    }
}
