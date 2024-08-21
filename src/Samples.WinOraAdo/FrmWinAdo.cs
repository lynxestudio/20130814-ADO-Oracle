using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Samples.WinOraAdo
{
    public partial class FrmWinAdo : Form
    {
        
        public FrmWinAdo()
        {
            InitializeComponent();
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
                MessageBox.Show("Id empty", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (string.IsNullOrEmpty(txtLastName.Text))
                    MessageBox.Show("Last Name Empty", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if(string.IsNullOrEmpty(txtEmail.Text))
                        MessageBox.Show("Email", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if(string.IsNullOrEmpty(txtHireDate.Text))
                            MessageBox.Show("Hire Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            if(string.IsNullOrEmpty(txtJobId.Text))
                                MessageBox.Show("Job Id", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(txtId.Text);
                    employee.FirstName = txtFirstName.Text;
                    employee.LastName = txtLastName.Text;
                    employee.Email = txtEmail.Text;
                    employee.PhoneNumber = txtPhone.Text;
                    employee.HireDate = txtHireDate.Text;
                    employee.JobId = txtJobId.Text;
                    employee.Salary = txtSalary.Text;
                    employee.Commission = txtCommission.Text;
                    employee.ManagerId = txtManagerId.Text;
                    employee.DepartmentId = txtDepartmentId.Text;
                    int recordAffected = EmployeeDac.Create(employee);
                    MessageBox.Show(recordAffected + " record added","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
        }

        private void BtnShowClick(object sender, EventArgs e)
        {
            StringBuilder buf = new StringBuilder();
            foreach (var item in EmployeeDac.RetrieveAll())
            {
                buf.Append (item.EmployeeId + " " +
                    item.FirstName + " " +
                    item.LastName + " " +
                    item.Email + " " +
                    item.PhoneNumber + " " +
                    item.HireDate + " " +
                    item.JobId + " " +
                    item.Salary + " " +
                    item.Commission + " " +
                    item.ManagerId + " " +
                    item.DepartmentId);
                buf.AppendLine();
            }
            txtOuput.Text = buf.ToString();
        }

    }
}
