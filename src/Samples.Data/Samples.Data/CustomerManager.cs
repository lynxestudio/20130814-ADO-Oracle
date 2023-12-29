using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace Samples.Data {
    public sealed class CustomerManager {
        public bool Create(Customer c) {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("INSERT INTO customers(customer_id,customer_name,customer_surname,customer_address,customer_phone,customer_email)");
            commandText.Append("VALUES(:id,:name,:surname,:address,:phone,:email)");
            bool resp = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            //my parameters, if my commandText is a store procedure
            parameters.Add("id", c.Id);
            parameters.Add("name", c.Name);
            parameters.Add("surname", c.Surname);
            parameters.Add("address", c.Address);
            parameters.Add("phone", c.Phone);
            parameters.Add("email", c.Email);
            resp = (OracleDataBaseCommand.Insert(commandText.ToString(), parameters,
                         CommandType.Text) > 0 ? true : false);
            return resp;
        }
        public bool Update(Customer c) {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("UPDATE customers SET customer_name = :name");
            commandText.Append(",customer_surname = :surname");
            commandText.Append(",customer_address = :address");
            commandText.Append(",customer_phone = :phone");
            commandText.Append(",customer_email = :email");
            commandText.Append(" WHERE customer_id = :id ");
            bool resp = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            //my parameters, if my commandText is a store procedure
            parameters.Add("name", c.Name);
            parameters.Add("surname", c.Surname);
            parameters.Add("address", c.Address);
            parameters.Add("phone", c.Phone);
            parameters.Add("email", c.Email);
            parameters.Add("id", c.Id);
            resp = (OracleDataBaseCommand.Update(commandText.ToString(), parameters,
                                CommandType.Text) > 0 ? true : false);
            return resp;
        }
        public Customer Retrieve(int id) {
            Customer resp = null;
            string commandText = "SELECT * FROM customers where customer_id = :id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            //my parameters, if my commandText is a store procedure
            parameters.Add("id", id);
            using (OracleDataReader reader = OracleDataBaseCommand.GetReader(commandText,
              parameters, CommandType.Text)) {
                if (reader.HasRows) {
                    while (reader.Read()) {
                        resp = new Customer();
                        resp.Id = reader.GetInt32(0);
                        resp.Name = reader.GetString(1);
                        resp.Surname = reader.GetString(2);
                        resp.Address = reader.GetString(3);
                        resp.Phone = reader.GetString(4);
                        resp.Email = reader.GetString(5);
                        resp.RegisterDate = reader.GetDateTime(6);
                    }
                }
            }
            return resp;
        }
    }
}