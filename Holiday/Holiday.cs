using Model;
using Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Holiday
{
    public partial class Holiday : Form
    {
        private int _employeeId;
        public Holiday()
        {
           
        }

        public Holiday(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHolidayData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void LoadHolidayData()
        {

            EmployeeProxy holidayproxy = new EmployeeProxy();
            List<EmployeeHoliday> holidays = holidayproxy.GetHolidaysByEmployeeId(_employeeId);

            dataGridViewHolidays.DataSource = holidays;
        }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeHoliday employeeHoliday = new EmployeeHoliday();
                employeeHoliday.EmployeeID = _employeeId;
                employeeHoliday.StartDate = dtpStartDate.Value;
                employeeHoliday.EndDate = dtpEndDate.Value;
                employeeHoliday.Reason = rtbReason.Text;

                EmployeeProxy employeeMng = new EmployeeProxy();
                bool? result = employeeMng.AddHoliday(employeeHoliday);

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

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            rtbReason.Text = "";
        }
        private void LoadEmployeeData()
        {
            EmployeeProxy HolidayMng = new EmployeeProxy();
            List<EmployeeHoliday> HolidayList = HolidayMng.GetHolidaysByEmployeeId(_employeeId);
            dataGridViewHolidays.DataSource = HolidayList;
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewHolidays.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridViewHolidays.SelectedCells[0].RowIndex;
                int HolidayId = Convert.ToInt32(dataGridViewHolidays.Rows[rowIndex].Cells["HolidayID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this row?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    EmployeeProxy HolidayManager = new EmployeeProxy();
                    HolidayManager.DeleteHoliday(HolidayId);

                    if (HolidayManager.DeleteHoliday(HolidayId) == true)
                    {
                        /* dataGridView1.Rows.RemoveAt(rowIndex);*/ // Remove the row from DataGridView
                        MessageBox.Show("Employee deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData();
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
