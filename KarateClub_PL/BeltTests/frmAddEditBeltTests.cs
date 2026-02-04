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

namespace KartateClubConApp_PersLayer.BeltTests
{
    public partial class frmAddEditBeltTests: Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private  enMode _Mode;
        private int _TestID;
        private clsBeltTest _Test;

        public frmAddEditBeltTests(int TestID)
        {
            InitializeComponent();
            this._TestID = TestID;

            if (TestID == -1 )
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;

        }


        private void _FillMemberComBox()
        {
            DataTable MembersTable = clsMember.GetAllMembers();

            foreach (DataRow row in MembersTable.Rows)
            {
                cbMembers.Items.Add(row["Name"]);
            }

        }

        private void _FillInstuctorComBox()
        {
            DataTable InstructorTable = clsInstructor.GetAllInstructors();

            foreach (DataRow row in InstructorTable.Rows)
            {
                cbInstructor.Items.Add(row["Name"]);
            }
            
        }

        private void _FillPaymentComBox()
        {
            DataTable PaymentTable = clsPayment.GetAllPaymentRecords();

            foreach (DataRow row in PaymentTable.Rows)
            {
                cbPayment.Items.Add(row["PaymentID"]);
            }
            
        }

        private void _FillBeltRanksComBox()
        {
            DataTable BeltRankTable = clsBeltRank.GetAllBeltRanks();

            foreach (DataRow row in BeltRankTable.Rows)
            {
                cbBeltRanks.Items.Add(row["RankName"]);
            }
            
        }


        private void frmAddNewMember_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }

      
        private void SaveData()
        {

            int MemberID = clsMember.Find(cbMembers.Text).MemberID;
            int InstructorID = clsInstructor.Find(cbInstructor.Text).InstrcutorID;
            int PaymentID;


             if (cbPayment.Text !="")
               {
                    PaymentID = clsPayment.Find(Convert.ToInt32(cbPayment.Text)).PaymentID;
                    _Test.PaymentID = PaymentID;

               }
            

            int RankID = clsBeltRank.Find(cbBeltRanks.Text).RankID;



            _Test.MemberID = MemberID;
            _Test.TestedByInstructorID = InstructorID;
            _Test.RankID = RankID;


            if (rbPass.Checked)
                _Test.Result = true;
            else
                _Test.Result = false;


            _Test.Date = dtpTsetDate.Value;


            
            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                
            }

            _Mode = enMode.UpdateMode;
            lblModeTitle.Text = "Edit Belt Test With ID [" + _Test.TestID + "]";
            txtTestID.Text = _Test.TestID.ToString();

        }

      

        private void brnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMembers.Text) || string.IsNullOrWhiteSpace(cbBeltRanks.Text) || string.IsNullOrWhiteSpace(cbInstructor.Text))
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
            _FillInstuctorComBox();
            _FillMemberComBox();
            _FillPaymentComBox();
            _FillBeltRanksComBox();

            // Add Mode
            if (_Mode == enMode.AddMode)
            {
                _Test = new clsBeltTest();
                lblModeTitle.Text = "Add New Belt Test";

                return;
            }


            // Edit Mode

            _Test = clsBeltTest.Find(_TestID);

            if (_Test == null)
                return;
          
            lblModeTitle.Text = "Edit Belt Test With ID [" + _Test.TestID + "]";

            txtTestID.Text = _TestID.ToString();

            cbMembers.SelectedIndex = cbMembers.FindString(clsMember.Find(_Test.MemberID).Name);
            cbInstructor.SelectedIndex = cbInstructor.FindString(clsInstructor.Find(_Test.TestedByInstructorID).Name);
            cbPayment.Text = _Test.PaymentID.ToString(); 

            cbBeltRanks.SelectedIndex = cbBeltRanks.FindString(clsBeltRank.Find(_Test.RankID).RankName);

            dtpTsetDate.Value = _Test.Date;

            if (_Test.Result)
                rbPass.Checked = true;
            else
                rbFail.Checked = true;

           


        }




        private void cbBeltRanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTestFees.Text = clsBeltRank.Find(cbBeltRanks.Text).TestFees.ToString();
        }


    }
}
