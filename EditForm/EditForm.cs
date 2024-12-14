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
using Model;
using Proxy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace EditForm
{
    public partial class EditForm : Form
    {
        
        public EditForm()
        {
            InitializeComponent();
        }
        private int EmployeeID;
        public EditForm(int employeeId, string firstName, string lastName, string nationality, DateTime DOB, string gender, string contactNumber, string homeCountryContactNumber, string homeCountryAddress, DateTime dateJoinedLamazani, decimal basicSalary, string position, string branch, string employeeDescription, Image personalImage, Image qidImage, Image passportImage, string qidNumber, DateTime qidExpiry, DateTime medicalCertificateExpiry, string passportNumber)
        {
            InitializeComponent();

            EmployeeID = employeeId;
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtNationality.Text = nationality;
            dtpDOB.Value = DOB;
            if (gender == "Male")
            {
                rbMale.Checked = true;
            }
            else if (gender == "Female")
            {
                rbFemale.Checked = true;
            }
            txtContactNumber.Text = contactNumber;
            txtHomeCountryContactNumber.Text = homeCountryContactNumber;
            txtHomeCountryAddress.Text = homeCountryAddress;
            dtpJoinedLamazani.Value = dateJoinedLamazani;
            txtBasicSalary.Text = basicSalary.ToString();
            txtPosition.Text = position;
            cbBranch.Text = branch;
            rtbEmployeeDescription.Text = employeeDescription;
            pbPersonalImage.Image = personalImage;
            pbQIDImage.Image = qidImage;
            pbPassportImage.Image = passportImage;
            txtQIDNumber.Text = qidNumber;
            dtpQIDExp.Value = qidExpiry;
            dtpMCExp.Value = medicalCertificateExpiry;
            txtPassportNumber.Text = passportNumber;

            pbPersonalImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQIDImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPassportImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            try
            {
                if (image == null)
                {
                    // If no new image is selected, return the existing image bytes from the database
                    return null;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap clonedImage = new Bitmap(image)) // Cloning as Bitmap
                    {
                        clonedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while converting the image: {ex.Message}");
                return null;
            }
        }

        private void EditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                
                EmployeeInfo employeeInfo = new EmployeeInfo();
                employeeInfo.EmployeeID = EmployeeID;
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
                    return; // Exit early if the conversion fails
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
                    employeeInfo.PersonalImage = null; // Handle accordingly if no image is selected
                }

                // Image handling for QID Image
                if (pbQIDImage.Image != null)
                {
                    employeeInfo.QIDImage = ConvertImageToByteArray(pbQIDImage.Image);
                }
                else
                {
                    employeeInfo.QIDImage = null; // Handle accordingly if no image is selected
                }

                // Image handling for Passport Image
                if (pbPassportImage.Image != null)
                {
                    employeeInfo.PassportImage = ConvertImageToByteArray(pbPassportImage.Image);
                }
                else
                {
                    employeeInfo.PassportImage = null; // Handle accordingly if no image is selected
                }
                employeeInfo.QIDNumber = txtQIDNumber.Text;
                employeeInfo.QIDExpiry = dtpQIDExp.Value;
                employeeInfo.MedicalCertificateExpiry = dtpMCExp.Value;
                employeeInfo.PassportNumber = txtPassportNumber.Text;

                EmployeeProxy employeeUpdate = new EmployeeProxy();
                bool? result = employeeUpdate.Update(employeeInfo);

                if (result == null)
                {
                    MessageBox.Show("Security Error");
                }
                else if (result.Value)
                {
                    MessageBox.Show("Update is Done!");
                    EditForm_Load(this, new EventArgs());
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set filter for file extension and default file extension
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                // Display OpenFileDialog by calling ShowDialog method
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    string imagePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    pbPersonalImage.Image = Image.FromFile(imagePath);
                    string selectedImagePath = openFileDialog.FileName;
                    pbPersonalImage.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image size to fit PictureBox

                }

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    string imagePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    pbQIDImage.Image = Image.FromFile(imagePath);
                    string selectedImagePath = openFileDialog.FileName;
                    pbQIDImage.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image size to fit PictureBox
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set filter for file extension and default file extension
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                // Display OpenFileDialog by calling ShowDialog method
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    string imagePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    pbPassportImage.Image = Image.FromFile(imagePath);
                    string selectedImagePath = openFileDialog.FileName;
                    pbPassportImage.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image size to fit PictureBox
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
