using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Entities
{
    [Table(Name = "user_details", Schema = "dbo")]
    public class EntityUserDetails
    {
        [Column(Name = "first_name"), NotNull]
        public string FirstName { get; set; }

        [Column(Name = "surname"), NotNull]
        public string Surname { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "password"), NotNull]
        public string Password { get; set; }
    }
}
