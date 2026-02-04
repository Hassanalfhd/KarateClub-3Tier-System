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

namespace KartateClubConApp_PersLayer.Payments
{
    public partial class frmAddEditPayments : Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private enMode _Mode;
        private int _PaymentID;
        private clsPayment _Payment;

        public frmAddEditPayments(int Payment)
        {
            InitializeComponent();
            this._PaymentID = Payment;

            if (Payment == -1)
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;

        }

        private void _FileMembersComBox()
        {
            DataTable MemberTable = clsMember.GetAllMembers();

            foreach (DataRow row in MemberTable.Rows)
            {
                cbMembers.Items.Add(row["Name"]);
            }
        }

        private string _GetPaymentType()
        {
            if (cbPaymentType.Text == "Cash")
                return "Cash";
            else if (cbPaymentType.Text == "Card")
                return "Card";
            else
                return "No Selected";
        }


        private void frmAddNewMember_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }


        private void SaveData()
        {

            int MemberID = clsMember.Find(cbMembers.Text).MemberID;

            _Payment.MemberID = MemberID;

            _Payment.PaymentType = _GetPaymentType();
            _Payment.Date = dtpDate.Value;

            try
            {
                _Payment.Amount = Convert.ToDecimal(txtAmount.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("The Feild Does not Saport string!!. ,, " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Clear();
                return;
            }
           
            if (_Payment.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }

            _Mode = enMode.UpdateMode;
            lblModeTitle.Text = "Edit Payment With ID [" + _Payment.PaymentID + "]";

            txtPaymentID.Text = _Payment.PaymentID.ToString();

        }



        private void brnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("You Must Enter Value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _FileMembersComBox();

            cbMembers.SelectedIndex = 0;
            cbPaymentType.SelectedIndex = 0;

            // Add Mode
            if (_Mode == enMode.AddMode)
            {
                _Payment = new clsPayment();
                lblModeTitle.Text = "Add New Payment";
                return;
            }


            // Edit Mode

            _Payment = clsPayment.Find(_PaymentID);

            if (_Payment == null)
                return;

            lblModeTitle.Text = "Edit Payment With ID ["+ _Payment.PaymentID + "]";
            txtPaymentID.Text = _PaymentID.ToString();

            txtAmount.Text = _Payment.Amount.ToString();
            dtpDate.Value = _Payment.Date;
            cbPaymentType.Text = _Payment.PaymentType;

            cbMembers.SelectedIndex = cbMembers.FindString(clsMember.Find(_Payment.MemberID).Name);

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