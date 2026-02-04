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

namespace KartateClubConApp_PersLayer.SubscriptionPeriods
{
    public partial class frmAddEditPeriod : Form
    {
        private enum enMode {AddMode =0, UpdateMode=1 }
        private enMode _Mode;
        private clsPeriod _Period;
        private int _PeriodID;

        public frmAddEditPeriod(int PeriodID)
        {
            InitializeComponent();
            this._PeriodID = PeriodID;

            if (PeriodID == -1)
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;
        }

        private void _FillMembersComBox()
        {
            DataTable MembersTable = clsMember.GetAllMembers();
         
            foreach (DataRow row in MembersTable.Rows)
            {
                cbMembers.Items.Add(row["Name"]);
            }

        }

        private void _FillPaymentsComBox()
        {
            DataTable PaymentsTable = clsPayment.GetAllPaymentRecords();

            foreach (DataRow row in PaymentsTable.Rows)
            {
                cbPayment.Items.Add(row["PaymentID"]);
            }
            
        }


        private void _LoadDataToForm()
        {
            _FillMembersComBox();

            _FillPaymentsComBox();

            cbMembers.SelectedIndex = 0;

            if (_Mode == enMode.AddMode)
            {
                _Period = new clsPeriod();
                lblMode.Text = "Add New Period";
                return;
            }


            _Period = clsPeriod.Find(_PeriodID);

            if (_Period == null)
            {
                MessageBox.Show("This Period is Deleted!");
                return;
            }



            lblMode.Text = "Edit Period With PeriodID ["+ _PeriodID.ToString() + "].";
            txtPeriodID.Text = _PeriodID.ToString();
            dtpStartDate.Value = _Period.StartDate;
            dtpEndDate.Value = _Period.EndDate;

            txtFees.Text = _Period.Fees.ToString();


            if (_Period.Paid)
                rbPaid.Checked = true;
            else
                rbNotPaid.Checked = true;

            cbMembers.SelectedIndex = cbMembers.FindString(clsMember.Find(_Period.MemberID).Name);

            cbPayment.Text = _Period.PaymentID.ToString();

        }

        private void frmAddEditPeriod_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }

        private void _SaveData()
        {
            int MemberID = clsMember.Find(cbMembers.Text).MemberID;

               
            
            int PaymentID = Convert.ToInt32(cbPayment.Text);
                 
            _Period.StartDate = dtpStartDate.Value;
            _Period.EndDate = dtpEndDate.Value;
            _Period.MemberID = MemberID;

            if (rbPaid.Checked)
                _Period.Paid = true;
            else
                _Period.Paid = false;


            try
            {
                _Period.Fees = Convert.ToDecimal(txtFees.Text);
                _Period.PaymentID = PaymentID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Set Number Value in Fees Feild[" + ex + "]" ,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_Period.Save())
            {
                MessageBox.Show("The Data Seved Successfully", "Confierm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else

                MessageBox.Show("The Data Seved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            _Mode = enMode.UpdateMode;

            txtPeriodID.Text = _Period.PeriodID.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                MessageBox.Show("Set Value in Feild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are You Suer You Want To Save This Data?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                _SaveData();
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMembers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
