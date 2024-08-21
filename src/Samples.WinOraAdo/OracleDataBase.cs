// -----------------------------------------------------------------------
// <copyright file="OracleDataBase.cs" company="apifiedsignature">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Samples.WinOraAdo
{
    using System;
    using System.Linq;
    using Oracle.DataAccess.Client;
    using System.Configuration;

    internal sealed class OracleDataBase
    {
        static OracleConnection _conn = null;
        static OracleDataBase Instance = null;
        string connectionString = null;

        OracleDataBase()
        {

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["xe"].ConnectionString;
            }
            catch (Exception e)
            {
                Logger.LogWriteError(e.Message);
            }
        }
        static void CreateInstance()
        {
            if (Instance == null)
                Instance = new OracleDataBase();
        }
        internal static OracleDataBase GetInstance()
        {
            if (Instance == null)
                CreateInstance();
            return Instance;
        }

        internal OracleConnection GetConnection()
        {
            try
            {
                _conn = new OracleConnection(connectionString);
                _conn.Open();
            }
            catch (OracleException ex)
            {
                Logger.LogWriteError(ex.Message);
                throw ex;
            }
            return _conn;
        }
    }
}
