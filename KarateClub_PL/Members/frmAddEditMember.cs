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

namespace KartateClubConApp_PersLayer.Members
{
    public partial class frmAddEditMember : Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private  enMode _Mode;
        private int _MemberID;
        private clsMember _Member;

        public frmAddEditMember(int MemberID)
        {
            InitializeComponent();
            this._MemberID = MemberID;

            if (MemberID == -1)
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;

        }

        private void _FilLastBeltRankCombox()
        { 
            DataTable LastBeltRankTable = clsBeltRank.GetAllBeltRanks();

            foreach(DataRow row in LastBeltRankTable.Rows)
            {
                cbLastBeltRank.Items.Add(row["RankName"]);
            }

            cbLastBeltRank.SelectedIndex = 0;
        }


        private void frmAddNewMember_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }

      
        private void SaveData()
        {
            int LastBeltRank = clsBeltRank.Find(cbLastBeltRank.Text).RankID;

            _Member.Name = txtName.Text;
            _Member.Address = txtAddress.Text;
            _Member.Email = txtEmail.Text;
            _Member.Phone = txtPhone.Text;
            _Member.EmergencyContactInfo = txtEmergencyInfo.Text;

            if(rbMale.Checked)
                _Member.Gender = 'M';
            else
                _Member.Gender = 'F';

            if (rbActive.Checked)
                _Member.IsActive = true;
            else
                _Member.IsActive = false;

            if (picImage.ImageLocation != null)
                _Member.Image = picImage.ImageLocation;
            else
                _Member.Image = "";

            _Member.LastBeltRank = LastBeltRank;

            if (_Member.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }

            _Mode = enMode.UpdateMode;
            lblModeTitle.Text = "Edit Member With ID [" + _Member.MemberID + "]";
            txtMemberID.Text = _Member.MemberID.ToString();
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
            _FilLastBeltRankCombox();


            // Add Mode
            if (_Mode == enMode.AddMode)
            {
                _Member = new clsMember();
                lblModeTitle.Text = "Add New Member";
                return;
            }


            // Edit Mode
            _Member = clsMember.Find(_MemberID);

            lblModeTitle.Text = "Edit Member With ID ["+_Member.MemberID + "]";

            txtMemberID.Text = _MemberID.ToString();

            txtName.Text = _Member.Name;
            txtAddress.Text = _Member.Address;
            txtEmail.Text = _Member.Email;
            txtEmergencyInfo.Text = _Member.EmergencyContactInfo;
            txtPhone.Text = _Member.Phone;

            if (_Member.Gender == 'M')
                rbMale.Checked = true;
            else
                rbFamle.Checked = true;

            if (_Member.IsActive)
                rbActive.Checked = true;
            else
                rbNotActive.Checked = true;


            if (_Member.Image != "")
            {
                picImage.ImageLocation = _Member.Image;
                btnRemoveImage.Visible = true;

            }

            cbLastBeltRank.SelectedIndex = cbLastBeltRank.FindString(clsBeltRank.Find(_Member.LastBeltRank).RankName);

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        

    }
}
