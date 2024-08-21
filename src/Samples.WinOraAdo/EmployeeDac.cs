// -----------------------------------------------------------------------
// <copyright file="EmployeeDac.cs" company="apifiedsignature">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Samples.WinOraAdo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EmployeeDac
    {
        public static int Create(Employee c)
        {
            int resp = 0;
            string commandText = CommandsText.InsertCmd;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(":prmEmployeeId", c.EmployeeId);
            parameters.Add(":prmFirstName", c.FirstName);
            parameters.Add(":prmLastName", c.LastName);
            parameters.Add(":prmEmail", c.Email);
            parameters.Add(":prmPhoneNumber", c.PhoneNumber);
            parameters.Add(":prmHireDate", c.HireDate);
            parameters.Add(":prmJobId", c.JobId);
            parameters.Add(":prmSalary", c.Salary);
            parameters.Add(":prmCommission",c.Commission);
            parameters.Add(":prmManagerId",c.ManagerId);
            parameters.Add(":prmDepartmentId",c.DepartmentId);
            //using the helper
            resp = OracleDataBaseCommand.Insert(commandText, parameters, CommandType.Text);
            return resp;
        }

        public static List<Employee> RetrieveAll()
        {
            List<Employee> resp = null;
            string commandText = CommandsText.SelectAll;
            Employee c = null;
            //using the helper
            using (OracleDataReader reader = OracleDataBaseCommand.GetReader(commandText, null, CommandType.Text))
            {
                resp = new List<Employee>();
                while (reader.Read())
                {
                    c = new Employee();
                    c.EmployeeId = reader.GetInt32(0);
                    c.FirstName = reader["FIRST_NAME"].ToString();
                    c.LastName = reader["LAST_NAME"].ToString();
                    c.Email = reader["EMAIL"].ToString();
                    c.PhoneNumber = reader["PHONE_NUMBER"].ToString();
                    c.HireDate = reader["HIRE_DATE"].ToString();
                    c.JobId = reader["JOB_ID"].ToString();
                    c.Salary = reader["SALARY"].ToString();
                    c.Commission = reader["COMMISSION_PCT"].ToString();
                    c.ManagerId = reader["MANAGER_ID"].ToString();
                    c.DepartmentId = reader["DEPARTMENT_ID"].ToString();
                    resp.Add(c);
                }
            }
            return resp;

        }
    }
}
