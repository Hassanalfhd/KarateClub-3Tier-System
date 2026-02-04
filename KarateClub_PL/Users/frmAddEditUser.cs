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

namespace KartateClubConApp_PersLayer.Users
{
    public partial class frmAddEditUser : Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private  enMode _Mode;
        private int _UserID;
        public clsUser _User;
        public int Permission { get; set; }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;

            if (UserID == -1)
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

            _User.Name = txtName.Text;
            _User.Address = txtAddress.Text;
            _User.Email = txtEmail.Text;
            _User.Phone = txtPhone.Text;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;

            if(rbMale.Checked)
                _User.Gender = 'M';
            else
                _User.Gender = 'F';

            if (picImage.ImageLocation != null)
                _User.Image = picImage.ImageLocation;
            else
                _User.Image = "";

           _User.Permission = this.Permission;

            

            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
            
            _Mode = enMode.UpdateMode;
            lblModeTitle.Text = "Edit User With ID [" + _User.UserID + "]";
            txtUserID.Text = _User.UserID.ToString();
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

            if (IsTxtBoxEmpty())
            {
                MessageBox.Show("The Feiled Is Empty!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _User = new clsUser();
                lblModeTitle.Text = "Add New User";
                return;
            }


            // Edit Mode
            _User = clsUser.Find(_UserID);


            lblModeTitle.Text = "Edit User With ID ["+ _User.UserID + "]";
            txtUserID.Text = _UserID.ToString();

            txtName.Text = _User.Name;
            txtAddress.Text = _User.Address;
            txtEmail.Text = _User.Email;
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;

            txtPhone.Text = _User.Phone;

            if (_User.Gender == 'M')
                rbMale.Checked = true;
            else
                rbFamle.Checked = true;

            if (_User.Image != "")
            {
                picImage.ImageLocation = _User.Image;
                btnRemoveImage.Visible = true;
            }


        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            Form frmPermission = new Users.frmPermissions(_User.Permission, _User.UserID);
            pnlContaner.BackColor = Color.FromArgb(0, 38, 33, 37);
            
            frmPermission.ShowDialog();
            pnlContaner.BackColor = Color.White;

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
