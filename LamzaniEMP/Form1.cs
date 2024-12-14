using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using EditForm;
using Model;
using Proxy;
using Holiday;
using System.Data.SqlClient;
using System.Configuration;
using Salary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LamzaniEMP
{
    public partial class Form1 : Form
    {
        private ContextMenuStrip contextMenuStrip2;
        
        public Form1()
        {
            InitializeComponent();
            InitializeContextMenuStrip(); 
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown; 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    pbPersonalImage.Image = Image.FromFile(imagePath);
                    string selectedImagePath = openFileDialog.FileName;
                    pbPersonalImage.SizeMode = PictureBoxSizeMode.StretchImage; 

                }

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    string imagePath = openFileDialog.FileName;

                    pbPassportImage.Image = Image.FromFile(imagePath);
                    string selectedImagePath = openFileDialog.FileName;
                    pbPassportImage.SizeMode = PictureBoxSizeMode.StretchImage; 
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    string imagePath = openFileDialog.FileName;

                    
                    pbQIDImage.Image = Image.FromFile(imagePath);
                    string selectedImagePath = openFileDialog.FileName;
                    pbQIDImage.SizeMode = PictureBoxSizeMode.StretchImage; 
                }
            }
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); 
                return ms.ToArray();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int expiringSoonThreshold = 30; 
            DateTime expiryDate = dtpQIDExp.Value;
            int daysRemaining = (expiryDate - DateTime.Now).Days;

            if (daysRemaining <= 0)
            {
                txtQIDExpiryOverlay.BackColor = Color.Red; 
            }
            else if (daysRemaining <= expiringSoonThreshold)
            {
                txtQIDExpiryOverlay.BackColor = Color.Yellow; 
            }
            else
            {
                txtQIDExpiryOverlay.BackColor = Color.White; 
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            LoadEmployeeData();
            InitializeContextMenuStrip();
        }
        private void InitializeContextMenuStrip()
        {
            contextMenuStrip2 = new ContextMenuStrip();

            ToolStripMenuItem showPersonalImage = new ToolStripMenuItem("Show Personal Image");
            showPersonalImage.Click += ShowPersonalImage_Click;

            ToolStripMenuItem showQIDImage = new ToolStripMenuItem("Show QID Image");
            showQIDImage.Click += ShowQIDImage_Click;

            ToolStripMenuItem showPassportImage = new ToolStripMenuItem("Show Passport Image");
            showPassportImage.Click += ShowPassportImage_Click;

            ToolStripMenuItem deleteRowItem = new ToolStripMenuItem("Delete Row");
            deleteRowItem.Click += DeleteRow_Click;

            ToolStripMenuItem editRowItem = new ToolStripMenuItem("Edit Row");
            editRowItem.Click += EditRow_Click;

            ToolStripMenuItem holidayItem = new ToolStripMenuItem("Holiday");
            holidayItem.Click += Holiday_Click;

            ToolStripMenuItem salaryItem = new ToolStripMenuItem("Salary");
            salaryItem.Click += Salary_Click;

            ToolStripMenuItem EndOfService = new ToolStripMenuItem("End of service");
            EndOfService.Click += EndOfService_Click;

            contextMenuStrip2.Items.Add(EndOfService);
            contextMenuStrip2.Items.Add(salaryItem);
            contextMenuStrip2.Items.Add(new ToolStripSeparator());
            contextMenuStrip2.Items.Add(holidayItem);
            contextMenuStrip2.Items.Add(new ToolStripSeparator());
            contextMenuStrip2.Items.Add(showPersonalImage);
            contextMenuStrip2.Items.Add(showQIDImage);
            contextMenuStrip2.Items.Add(showPassportImage);
            contextMenuStrip2.Items.Add(new ToolStripSeparator());
            contextMenuStrip2.Items.Add(editRowItem);
            contextMenuStrip2.Items.Add(deleteRowItem); 


            
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
        }
        private void EndOfService_Click(object sender, EventArgs e)
        {
            
            int employeeId = GetSelectedEmployeeId(); 
            EmployeeProxy employeeProxy = new EmployeeProxy();
            EmployeeInfo employee = employeeProxy.GetOneEmployee(employeeId);

            if (employee != null)
            {
                DateTime dateJoined = employee.DateJoinedLamazani;
                decimal basicSalary = employee.BasicSalary;

                int monthsSinceJoined = DateTime.Now.Year - dateJoined.Year;

                // Calculate total salary since joining
                decimal totalSalarySinceJoining = monthsSinceJoined * basicSalary;

                // Display result
                MessageBox.Show($"Total salary since joining: {totalSalarySinceJoining:C}", "Salary Calculation");
            }
            else
            {
                MessageBox.Show("Unable to retrieve employee data.", "Error");
            }
        }
        private void Holiday_Click(object sender, EventArgs e)
        {
            int employeeId = GetSelectedEmployeeId();
            if (employeeId != -1)
            {
                Holiday.Holiday holidayForm = new Holiday.Holiday(employeeId); 
                holidayForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an employee first.");
            }

        }
        private void Salary_Click(object sender, EventArgs e)
        {
            int employeeId = GetSelectedEmployeeId();
            var viewSalaryForm = new Salary.Salary(employeeId);
            viewSalaryForm.Show();
        }
        private int GetSelectedEmployeeId()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
            }
            return -1; 
        }
        private void ShowPersonalImage_Click(object sender, EventArgs e)
        {
            ShowImage("PersonalImage");
        }

        private void ShowQIDImage_Click(object sender, EventArgs e)
        {
            ShowImage("QIDImage");
        }

        private void ShowPassportImage_Click(object sender, EventArgs e)
        {
            ShowImage("PassportImage");
        }
        private void DeleteRow_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int employeeId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["EmployeeID"].Value);


                EmployeeProxy employeeProxy = new EmployeeProxy();
                List<EmployeeHoliday> holidays = employeeProxy.GetHolidaysByEmployeeId(employeeId);

                if (holidays.Count > 0)
                {
                    var result = MessageBox.Show(
                        "This employee has holiday records. Please delete these records first. Would you like to delete them now?",
                        "Holiday Records Found",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Step 2: Delete each holiday record
                        foreach (var holiday in holidays)
                        {
                            bool? deleteResult = employeeProxy.DeleteHoliday(holiday.HolidayID);
                            if (deleteResult == null || !deleteResult.Value)
                            {
                                MessageBox.Show("Failed to delete holiday record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Step 3: Delete Employee if no holiday records are left
                var employeeDeleteResult = employeeProxy.Delete(employeeId);
                if (employeeDeleteResult.HasValue && employeeDeleteResult.Value)
                {
                    MessageBox.Show("Employee deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployeeData(); // Reload to update the DataGridView
                }
                else
                {
                    MessageBox.Show("Failed to delete the employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ShowImage(string columnName)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

            // Get the image from the selected cell
            var imageCell = dataGridView1.Rows[selectedRowIndex].Cells[columnName].Value;

            if (imageCell is byte[] byteArray && byteArray.Length > 0)
            {
                Image image = ByteArrayToImage(byteArray); 

                
                Form imageForm = new Form();
                PictureBox pictureBox = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom 
                };

                imageForm.Controls.Add(pictureBox);
                imageForm.Text = columnName + " - Image";
                imageForm.StartPosition = FormStartPosition.CenterParent;
                imageForm.Size = new Size(800, 600); 
                imageForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No image found or the image is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                
                int employeeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
                string firstName = dataGridView1.Rows[rowIndex].Cells["FirstName"].Value.ToString();
                string lastName = dataGridView1.Rows[rowIndex].Cells["LastName"].Value.ToString();
                string nationality = dataGridView1.Rows[rowIndex].Cells["Nationality"].Value.ToString();
                DateTime DOB = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["DateOfBirth"].Value);
                string gender = dataGridView1.Rows[rowIndex].Cells["Gender"].Value.ToString();
                string contactNumber = dataGridView1.Rows[rowIndex].Cells["ContactNumber"].Value.ToString();
                string homeCountryContactNumber = dataGridView1.Rows[rowIndex].Cells["HomeCountryContactNumber"].Value.ToString();
                string homeCountryAddress = dataGridView1.Rows[rowIndex].Cells["HomeCountryAddress"].Value.ToString();
                DateTime dateJoinedLamazani = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["DateJoinedLamazani"].Value);
                decimal basicSalary = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["BasicSalary"].Value);
                string position = dataGridView1.Rows[rowIndex].Cells["Position"].Value.ToString();
                string branch = dataGridView1.Rows[rowIndex].Cells["Branch"].Value.ToString();
                string employeeDescription = dataGridView1.Rows[rowIndex].Cells["EmployeeDescription"].Value.ToString();
                Image personalImage = ByteArrayToImage((byte[])dataGridView1.Rows[rowIndex].Cells["PersonalImage"].Value);
                Image qidImage = ByteArrayToImage((byte[])dataGridView1.Rows[rowIndex].Cells["QIDImage"].Value);
                Image passportImage = ByteArrayToImage((byte[])dataGridView1.Rows[rowIndex].Cells["PassportImage"].Value);
                string qidNumber = dataGridView1.Rows[rowIndex].Cells["QIDNumber"].Value.ToString();
                DateTime qidExpiry = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["QIDExpiry"].Value);
                DateTime medicalCertificateExpiry = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["MedicalCertificateExpiry"].Value);
                string passportNumber = dataGridView1.Rows[rowIndex].Cells["passportNumber"].Value.ToString();


                var editForm = new EditForm.EditForm(employeeID, firstName, lastName, nationality, DOB, gender, contactNumber, homeCountryContactNumber, homeCountryAddress, dateJoinedLamazani, basicSalary, position, branch, employeeDescription, personalImage, qidImage, passportImage, qidNumber, qidExpiry, medicalCertificateExpiry, passportNumber);
                editForm.ShowDialog();

                LoadEmployeeData();
            }
        }

        private void dtpQIDExp_ValueChanged(object sender, EventArgs e)
        {
            txtQIDExpiryOverlay.Text = dtpQIDExp.Value.ToShortDateString();
        }

        private void dtpMCExp_ValueChanged(object sender, EventArgs e)
        {
            txtMedicalExpiryOverlay.Text = dtpMCExp.Value.ToShortDateString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int expiringSoonThreshold = 30; 
            DateTime expiryDate = dtpMCExp.Value;
            int daysRemaining = (expiryDate - DateTime.Now).Days;

            if (daysRemaining <= 0)
            {
                txtMedicalExpiryOverlay.BackColor = Color.Red; 
            }
            else if (daysRemaining <= expiringSoonThreshold)
            {
                txtMedicalExpiryOverlay.BackColor = Color.Yellow; 
            }
            else
            {
                txtMedicalExpiryOverlay.BackColor = Color.White; 
            }
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeInfo employeeInfo = new EmployeeInfo();
                employeeInfo.FirstName = txtFirstName.Text;
                employeeInfo.LastName = txtLastName.Text;
                employeeInfo.Nationality = txtNationality.Text;
                employeeInfo.DateOfBirth = dtpDOB.Value;
                if (rbMale.Checked)
                {
                    employeeInfo.Gender = "Male";
                }
                else if (rbFemale.Checked)
                {
                    employeeInfo.Gender = "Female";
                }
                else
                {
                    MessageBox.Show("Please select a gender.");
                    return;
                }
                employeeInfo.ContactNumber = txtContactNumber.Text;
                employeeInfo.HomeCountryContactNumber = txtHomeCountryContactNumber.Text;
                employeeInfo.HomeCountryAddress = txtHomeCountryAddress.Text;
                employeeInfo.DateJoinedLamazani = dtpJoinedLamazani.Value;
                if (!decimal.TryParse(txtBasicSalary.Text, out decimal basicSalary))
                {
                    MessageBox.Show("Please enter a valid basic salary.");
                    return; 
                }
                employeeInfo.BasicSalary = basicSalary;
                employeeInfo.Position = txtPosition.Text;
                employeeInfo.Branch = cbBranch.Text;
                employeeInfo.EmployeeDescription = rtbEmployeeDescription.Text;
                if (pbPersonalImage.Image != null)
                {
                    employeeInfo.PersonalImage = ConvertImageToByteArray(pbPersonalImage.Image);
                }
                else
                {
                    employeeInfo.PersonalImage = null; 
                }

                
                if (pbQIDImage.Image != null)
                {
                    employeeInfo.QIDImage = ConvertImageToByteArray(pbQIDImage.Image);
                }
                else
                {
                    employeeInfo.QIDImage = null; 
                }

                // Image handling for Passport Image
                if (pbPassportImage.Image != null)
                {
                    employeeInfo.PassportImage = ConvertImageToByteArray(pbPassportImage.Image);
                }
                else
                {
                    employeeInfo.PassportImage = null; 
                }
                employeeInfo.QIDNumber = txtQIDNumber.Text;
                employeeInfo.QIDExpiry = dtpQIDExp.Value;
                employeeInfo.MedicalCertificateExpiry = dtpMCExp.Value;
                employeeInfo.PassportNumber = txtPassportNumber.Text;



                EmployeeProxy employeeMng = new EmployeeProxy();
                bool? result = employeeMng.Insert(employeeInfo);

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

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationality.Text = "";
            dtpDOB.Value = DateTime.Now;
            if (rbMale.Checked)
            {
                rbMale.Checked = false;
            }
            else if (rbFemale.Checked)
            {
                rbFemale.Checked = false;
            }
            txtContactNumber.Text = "";
            txtHomeCountryContactNumber.Text = "";
            txtHomeCountryAddress.Text = "";
            dtpJoinedLamazani.Value = DateTime.Now;
            txtBasicSalary.Text = "";
            txtPosition.Text = "";
            cbBranch.SelectedIndex = 0;
            rtbEmployeeDescription.Text = "";
            pbPersonalImage.Image = null;
            pbQIDImage.Image = null;
            pbPassportImage.Image = null;
            txtQIDNumber.Text = null;
            dtpQIDExp.Value = DateTime.Now;
            dtpMCExp.Value = DateTime.Now;
            txtPassportNumber.Text = "";
        }
        private void LoadEmployeeData()
        {
            EmployeeProxy employeeMng = new EmployeeProxy();
            List<EmployeeInfo> employeeList = employeeMng.GetEmployees();
            dataGridView1.DataSource = employeeList;

            dataGridView1.Columns["PersonalImage"].Width = 100;  
            dataGridView1.Columns["QIDImage"].Width = 100;
            dataGridView1.Columns["PassportImage"].Width = 100;
            
            ((DataGridViewImageColumn)dataGridView1.Columns["PersonalImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            ((DataGridViewImageColumn)dataGridView1.Columns["QIDImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            ((DataGridViewImageColumn)dataGridView1.Columns["PassportImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            //foreach (DataGridViewColumn col in dataGridView1.Columns &&)
            //{
            //    MessageBox.Show(col.Name);
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //MessageBox.Show($"Value: {e.Value}, Type: {e.Value?.GetType().Name}");
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.ClearSelection(); 
                dataGridView1.Rows[e.RowIndex].Selected = true; 
                contextMenuStrip2.Show(dataGridView1, e.Location);
            }
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) 
            {
                dataGridView1.ClearSelection(); 
                dataGridView1.Rows[e.RowIndex].Selected = true; 
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0]; 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                EmployeeProxy employeeProxy = new EmployeeProxy();
                List<EmployeeInfo> employees = employeeProxy.SearchEmployeesByName(searchName);

                if (employees.Count > 0)
                {
                    dataGridView1.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("No employees found with that name.");
                    dataGridView1.DataSource = null; 
                }
            }
            else
            {
                MessageBox.Show("Please enter a name to search.");
            }
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadEmployeeData();
            button5.Visible = false;
        }
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int employeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["EmployeeID"].Value);
                EmployeeProxy employeeProxy = new EmployeeProxy();

                // Call your method to check if the employee is on holiday
                bool? isOnHoliday = employeeProxy.IsEmployeeOnHoliday(employeeId);

                string holidayStatus = (bool)isOnHoliday ? "This employee is currently on holiday." : "This employee is not on holiday.";


                toolTip1.Show(holidayStatus, dataGridView1, dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location, duration: 2000);
            }
        }
        
    }
}
