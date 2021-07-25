using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Models
{
    public class RegistrationRequestModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
