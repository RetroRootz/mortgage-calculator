using LinqToDB;
using MortgageCalculator.Entities;
using MortgageCalculator.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MortgageCalculator.DatabaseConnections;

namespace MortgageCalculator.DataAccess
{
    public class UserDataAccess
    {
        public static async Task<int> SaveUserDetails(RegistrationRequestModel details)
        {
            if (details == null)
            {
                Log.Error("Error being thrown in SaveUserDetails method: User details returned null or empty");
                return 0;
            }

            try
            {
                using (var db = new SqlServerConnection())
                {
                    var query = db.GetTable<EntityUserDetails>()
                                .Value(x => x.FirstName, details.FirstName)
                                .Value(x => x.Surname, details.Surname)
                                .Value(x => x.Email, details.Email)
                                .Value(x => x.Password, details.Password);

                    if (query == null)
                    {
                        Log.Error("Error being thrown in SaveUserDetails: Query to register user returned null");
                        return 0;
                    }

                    var row = await query.InsertAsync();

                    if (row < 1)
                    {
                        Log.Error($"Error being thrown in SaveUserDetails: Error inserting user details {query}");
                        return 0;
                    }

                    return row;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error being thrown in SaveUserDetails: Could not insert data for user {ex.Message}");
                return 0;
            }

        }
    }
}
