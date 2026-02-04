using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KartateClubBussnessLayer;

namespace KartateClubConApp_PersLayer.Instructors
{
    public partial class frmAddEditInstructor : Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private  enMode _Mode;
        private int _InstructorID;
        private clsInstructor _Instructor;

        public frmAddEditInstructor(int InstructorID)
        {
            InitializeComponent();
            this._InstructorID = InstructorID;

            if (InstructorID == -1)
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;

        }

      

        private void frmAddNewMember_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }

      
        private void SaveData()
        {

            _Instructor.Name = txtName.Text;
            _Instructor.Address = txtAddress.Text;
            _Instructor.Email = txtEmail.Text;
            _Instructor.Phone = txtPhone.Text;
            _Instructor.Qualification = txtQualification.Text;

            if(rbMale.Checked)
                _Instructor.Gender = 'M';
            else
                _Instructor.Gender = 'F';

            if (picImage.ImageLocation != null)
                _Instructor.Image = picImage.ImageLocation;
            else
                _Instructor.Image = "";


            if (_Instructor.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }

            _Mode = enMode.UpdateMode;
            lblModeTitle.Text = "Edit Instructor With ID [" + _Instructor.InstrcutorID + "]";
            txtInstructorID.Text = _Instructor.InstrcutorID.ToString();
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {

            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Iamge Files | *.jpg;*.png;*.jpeg;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string FileName = openFileDialog1.FileName;
                btnRemoveImage.Visible = true;

                picImage.Load(FileName);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            picImage.ImageLocation  = null;
            btnRemoveImage.Visible = false;

        }


        private bool IsTxtBoxEmpty()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                return true;
            

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                return true;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return true;



            return false;

        }


        private void brnSave_Click(object sender, EventArgs e)
        {

            if(IsTxtBoxEmpty())
            {   
                MessageBox.Show("The Feiled Is Empty!!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sur you want to save this Data", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                SaveData();
                
            }
            
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadDataToForm()
        {


            // Add Mode
            if (_Mode == enMode.AddMode)
            {
                _Instructor = new clsInstructor();
                lblModeTitle.Text = "Add New Instructor";
                return;
            }


            // Edit Mode
            _Instructor = clsInstructor.Find(_InstructorID);

            lblModeTitle.Text = "Edit Instructor With ID [" + _Instructor.InstrcutorID + "]";
            txtInstructorID.Text = _InstructorID.ToString();

            txtName.Text = _Instructor.Name;
            txtAddress.Text = _Instructor.Address;
            txtEmail.Text = _Instructor.Email;
            txtQualification.Text = _Instructor.Qualification;
            txtPhone.Text = _Instructor.Phone;

            if (_Instructor.Gender == 'M')
                rbMale.Checked = true;
            else
                rbFamle.Checked = true;

            if (_Instructor.Image != "")
            {
                picImage.ImageLocation = _Instructor.Image;
                btnRemoveImage.Visible = true;

            }
            

        }


        private void txtValidation_Validating(object sender, CancelEventArgs e)
        {
            TextBox TextToValdtion = sender as TextBox;

            if (TextToValdtion == null)
                return;

            if (string.IsNullOrWhiteSpace(TextToValdtion.Text))
            {
                e.Cancel = true;
                TextToValdtion.Focus();
                errorProvider1.SetError(TextToValdtion, "Palse, Set Value?");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TextToValdtion, "");

            }
        }



    }
}
