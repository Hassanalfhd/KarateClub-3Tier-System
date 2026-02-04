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

namespace KartateClubConApp_PersLayer.MemberInstructors
{
    public partial class frmAddEditMemberInstructors : Form
    {
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private  enMode _Mode;
        private int _MemberID;
        private int _InstructorID;
        private clsMemberInstructor _MemberInstrucotr;

        public frmAddEditMemberInstructors(int MemberID , int InstructorID)
        {
            InitializeComponent();
            this._MemberID = MemberID;
            this._InstructorID = InstructorID;

            if (MemberID == -1 && InstructorID == -1)
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;

        }

        private void _FilMembersCombox()
        { 
            DataTable Memberstable = clsMember.GetAllMembers();

            foreach(DataRow row in Memberstable.Rows)
            {
                cbMembers.Items.Add(row["Name"]);
            }

        }

        private void _FilInstructorsCombox()
        {
            DataTable InstructorTable = clsInstructor.GetAllInstructors();

            foreach (DataRow row in InstructorTable.Rows)
            {
                cbInstructor.Items.Add(row["Name"]);
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

            _MemberInstrucotr.MemberID = MemberID;
            _MemberInstrucotr.InstructorID = InstructorID;
            _MemberInstrucotr.AssignDate = dtpAssignDate.Value;


            if (_MemberInstrucotr.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }

            _Mode = enMode.UpdateMode;

            lblModeTitle.Text = "Edit MemberInstructor ";

        }

      

       
         


        private void brnSave_Click(object sender, EventArgs e)
        {

         

            if (string.IsNullOrWhiteSpace(cbInstructor.Text) || string.IsNullOrWhiteSpace(cbMembers.Text))
            {
                MessageBox.Show("You Moust Set Value To The Lsit!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            _FilInstructorsCombox();
            _FilMembersCombox();



            // Add Mode
            if (_Mode == enMode.AddMode)
            {
                _MemberInstrucotr = new clsMemberInstructor();
                lblModeTitle.Text = "Add New  MemberInstructor ";

                return;
            }


            // Edit Mode
            _MemberInstrucotr = clsMemberInstructor.Find(this._InstructorID,this._MemberID);
            lblModeTitle.Text = "Edit MemberInstructor ";

            if (_MemberInstrucotr == null)
                MessageBox.Show("This Was Deleted!!");
            cbMembers.SelectedIndex = cbMembers.FindString(clsMember.Find(this._MemberID).Name);

            cbInstructor.SelectedIndex = cbInstructor.FindString(clsInstructor.Find(this._InstructorID).Name);

            dtpAssignDate.Value = _MemberInstrucotr.AssignDate.Date;

        }




    }
}
