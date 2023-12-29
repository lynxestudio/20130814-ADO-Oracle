using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.Data
{
    public sealed class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public override string ToString()
        {
            StringBuilder buf = new StringBuilder();
            buf.AppendLine("\tName:    " + Name);
            buf.AppendLine("\tSurname: " + Surname);
            buf.AppendLine("\tAddress: " + Address);
            buf.AppendLine("\tPhone:   " + Phone);
            buf.AppendLine("\tEmail:    " + Email);
            buf.AppendLine("\tRegister date: " + RegisterDate.ToShortDateString());
            return buf.ToString();
        }
    }
}
