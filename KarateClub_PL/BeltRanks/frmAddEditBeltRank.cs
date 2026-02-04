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

namespace KartateClubConApp_PersLayer.BeltRanks
{
    public partial class frmAddEditBeltRank: Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private  enMode _Mode;
        private int _RankID;
        private clsBeltRank _Rank;

        public frmAddEditBeltRank(int RankID)
        {
            InitializeComponent();
            this._RankID = RankID;

            if (RankID == -1 )
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

            _Rank.RankName = txtRankName.Text;

            try
            {
                _Rank.TestFees = Convert.ToDecimal(txtTestFees.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("The Test Fees Does not Saport string!!. ,, " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Rank.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                
            }

            _Mode = enMode.UpdateMode;
            lblModeTitle.Text = "Edit Belt Rank With ID [" + _Rank.RankID + "]";
            txtRankID.Text = _Rank.RankID.ToString();

        }

      

        private void brnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRankName.Text) || string.IsNullOrWhiteSpace(txtTestFees.Text))
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
                _Rank = new clsBeltRank();
                lblModeTitle.Text = "Add New Belt Rank";

                return;
            }


            // Edit Mode

            _Rank = clsBeltRank.Find(_RankID);

            if (_Rank == null)
                return;
          
            lblModeTitle.Text = "Edit Belt Rank With ID [" + _Rank.RankID + "]";

            txtRankID.Text = _RankID.ToString();
            txtRankName.Text = _Rank.RankName;
            txtTestFees.Text = _Rank.TestFees.ToString();

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
