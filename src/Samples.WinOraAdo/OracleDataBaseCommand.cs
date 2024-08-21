// -----------------------------------------------------------------------
// <copyright file="OracleDataBaseCommand.cs" company="apifiedsignature">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Samples.WinOraAdo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Oracle.DataAccess.Client;
    using System.Data;

    internal sealed class OracleDataBaseCommand
    {

        internal static int Insert(string commandText, Dictionary<string, object> parameters, System.Data.CommandType cmdtype)
        {

            int resp = 0;
            try
            {
                using (OracleConnection conn = OracleDataBase.GetInstance().GetConnection())
                {
                    using (OracleCommand cmd = new OracleCommand(commandText, conn))
                    {
                        cmd.CommandType = cmdtype;
                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, object> pair in parameters)
                            {
                                cmd.Parameters.Add(new OracleParameter(pair.Key, pair.Value));
                            }
                        }
                        resp = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                Logger.LogWriteError(ex.Message);
                throw ex;
            }
            return resp;
        }
        internal static int Update(string commandText, Dictionary<string, object> parameters, System.Data.CommandType cmdtype)
        {

            try
            {
                return Insert(commandText, parameters, cmdtype);
            }
            catch (OracleException ex)
            {
                Logger.LogWriteError(ex.Message);
                throw ex;
            }
        }
        internal static OracleDataReader GetReader(string commandText, Dictionary<string, object> parameters, System.Data.CommandType cmdtype)
        {
            OracleDataReader reader = null;
            try
            {
                OracleConnection conn = OracleDataBase.GetInstance().GetConnection();
                using (OracleCommand cmd = new OracleCommand(commandText, conn))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> pair in parameters)
                        {
                            cmd.Parameters.Add(new OracleParameter(pair.Key, pair.Value));
                        }
                    }
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                Logger.LogWriteError(ex.Message);
                throw ex;
            }
            return reader;
        }

        internal OracleDataReader GetParameterizedReader(string commandText, OracleParameter[] parameters, System.Data.CommandType cmdtype)
        {
            OracleDataReader reader = null;
            OracleConnection conn = OracleDataBase.GetInstance().GetConnection();
            using (OracleCommand cmd = new OracleCommand(commandText, conn))
            {
                cmd.CommandType = cmdtype;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return reader;
        }
    }
}
