using Microsoft.Extensions.Configuration;

using System.Data;
using System.Data.SqlClient;

namespace PruebaDiego.DataContext
{
    public class DapperContext
    {

        private readonly string secretName ;


        public DapperContext()
        {
           
            secretName = "Data Source=DTDESA130;Initial Catalog=Bar;Persist Security Info=True;User ID=sa;Password=diego011";
        }

        public IDbConnection CreateConnection() =>
            new SqlConnection(secretName);
    }
}