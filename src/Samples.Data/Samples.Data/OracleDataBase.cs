using System.Data.OracleClient;
using System.Configuration;
using System.Data;

namespace Samples.Data {
    internal  sealed class OracleDataBase {
        static OracleConnection connection = null;
        internal static OracleConnection GetConnection() {
            string connectionString = ConfigurationManager.ConnectionStrings["test_oracle"].ConnectionString;
            connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }
        internal static void CloseConnection() {
            if (connection != null) {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}