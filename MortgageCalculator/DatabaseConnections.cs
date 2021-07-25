using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    public class DatabaseConnections
    {
        public class SqlServerConnection : DataConnection
        {
            public static string CalculatorConnectionString { get; set; }

            public SqlServerConnection() : base(new SqlServerDataProvider("", SqlServerVersion.v2017), CalculatorConnectionString) { }
        }
    }
}
