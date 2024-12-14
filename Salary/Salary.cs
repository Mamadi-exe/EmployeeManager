using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Proxy;

namespace Salary
{
    public partial class Salary : Form
    {
        private int _employeeId;
        public Salary()
        {

        }
        public Salary(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSalaryData();
        }
        private void LoadSalaryData()
        {

            EmployeeProxy salaryProxy = new EmployeeProxy();
            List<EmployeeSalary> salaries = salaryProxy.GetSalariesByEmployeeId(_employeeId);

            dataGridViewSalary.DataSource = salaries;
        }

        private void btnAddSalary_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeSalary employeeSalary = new EmployeeSalary();
                employeeSalary.EmployeeID = _employeeId;

                if (!decimal.TryParse(txtBonus.Text, out decimal bonus))
                {
                    MessageBox.Show("Please enter a valid basic salary.");
                    return; // Exit early if the conversion fails
                }
                employeeSalary.Bonus = bonus;
                if (!decimal.TryParse(txtSalaryTaken.Text, out decimal salaryTaken))
                {
                    MessageBox.Show("Please enter a valid basic salary.");
                    return; // Exit early if the conversion fails
                }
                employeeSalary.SalaryTaken = salaryTaken;
                employeeSalary.ReasonSalaryTaken = rtbReason.Text;
                employeeSalary.DateSalaryAdded = dtpDateSalaryAdded.Value;

                EmployeeProxy employeeMng = new EmployeeProxy();
                bool? result = employeeMng.AddSalary(employeeSalary);

                if (result == null)
                {
                    MessageBox.Show("security Error");
                }
                else if (result.Value)
                {
                    MessageBox.Show("Insert is Done");
                    Form1_Load(this, new EventArgs());
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            txtSalaryTaken.Text = "";
            txtBonus.Text = "";
            rtbReason.Text = "";
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalary.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridViewSalary.SelectedCells[0].RowIndex;
                int salaryId = Convert.ToInt32(dataGridViewSalary.Rows[rowIndex].Cells["SalaryID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this row?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    EmployeeProxy salaryManager = new EmployeeProxy();
                    salaryManager.DeleteSalary(salaryId);

                    if (salaryManager.DeleteHoliday(salaryId) == true)
                    {
                        /* dataGridView1.Rows.RemoveAt(rowIndex);*/ // Remove the row from DataGridView
                        MessageBox.Show("Employee deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSalaryData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
