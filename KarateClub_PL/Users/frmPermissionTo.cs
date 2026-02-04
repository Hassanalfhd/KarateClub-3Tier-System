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
    public partial class frmPermissionTo : Form
    {
        public int _Number { set; get; }
        public frmPermissionTo( int Number)
        {
            InitializeComponent();
            this._Number = Number;
        }


        private int _GetAdvancesPermission()
        { 
            int NumPermission = 0;

            if (ckAddMembers.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdateMembers;

            if(ckDeleteMembers.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeleteMembers;

            if(ckAddInstructors.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdateInstructors;

            if(ckDeleteInstructors.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeleteInstructors;

            if(ckAddUsers.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdateUsers;

            if(ckDeleteUsers.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeleteUsers;

            if(ckAddUpdateMemberIntructors.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdateMemberInstructors;

            if(ckDeleteMembersInstructos.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeleteMemberInstructors;

            if(ckAddUpdateRanks.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdateRanks;

            if (ckDeleteRanks.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeleteRanks;

            if(ckAddUpdateTests.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdateTests;

            if(ckDeleteTests.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeleteTests;

            if(ckAddUpdatePeriods.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdatePeriods;

            if(ckDeletePeriods.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeletePeriods;

            if(ckAddUpdatePayments.Checked)
                NumPermission += (int)clsUser.enPermissinos.pAddUpdatePayments;

            if (ckDeletePayment.Checked)
                NumPermission += (int)clsUser.enPermissinos.pDeletePayments;



            return NumPermission;

        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {

            
            if (MessageBox.Show("Are You suer You Want To Save This Setting?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                this._Number = _GetAdvancesPermission();
               
                MessageBox.Show("The Addvances Setting Svaed Succssfuly!", "Save");
                this.Close();
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPermissionTo_Load(object sender, EventArgs e)
        {
            _SetPermissionToForm();
        }

        private void frmPermissionTo_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            var frmPermission = Application.OpenForms["frmPermissions"] as frmPermissions;

            frmPermission._NumPermission += this._Number;
        }

        private bool IsPermission(int PermissionNo, clsUser.enPermissinos UserPermissinos)
        {
            return ((PermissionNo & (int)UserPermissinos) == (int)UserPermissinos);
        }


        private void _SetPermissionToForm()
        {

            var frmPermission = Application.OpenForms["frmPermissions"] as frmPermissions;

            int PermissionNo = clsUser.Find(frmPermission._UserID).Permission;

            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdateMembers))
                ckAddMembers.Checked = true;


            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdateUsers))
                ckAddUsers.Checked = true;


            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdateInstructors))
                ckAddInstructors.Checked = true;

            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdateMemberInstructors))
                ckAddUpdateMemberIntructors.Checked = true;


            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdatePayments))
                ckAddUpdatePayments.Checked = true;

            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdatePeriods))
                ckAddUpdatePeriods.Checked = true;

            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdateRanks))
                ckAddUpdateRanks.Checked = true;

            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAddUpdateTests))
                ckAddUpdateTests.Checked = true;


            /// Delete


            // Delete Instructor
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeleteInstructors))
                ckDeleteInstructors.Checked = true;

            // Delete MemberInstructor
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeleteMemberInstructors))
                ckDeleteMembersInstructos.Checked = true;

            // Delete Member
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeleteMembers))
                ckDeleteMembers.Checked = true;

            // Delete Payment
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeletePayments))
                ckDeletePayment.Checked = true;

            // Delete Period
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeletePeriods))
                ckDeletePeriods.Checked = true;

            // Delete Belt Rank
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeleteRanks))
                ckDeleteRanks.Checked = true;

            // Delete Belt Test
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeleteTests))
                ckDeleteTests.Checked = true;

            // Delete User
            if (IsPermission(PermissionNo, clsUser.enPermissinos.pDeleteUsers))
                ckDeleteUsers.Checked = true;

           
        }


        private void _CheckedAllPermissiom(bool CkValue)
        {

            ckAddMembers.Checked = CkValue;

            ckAddUsers.Checked = CkValue;

            ckAddInstructors.Checked = CkValue;

            ckAddUpdateMemberIntructors.Checked = CkValue;

            ckAddUpdatePayments.Checked = CkValue;

            ckAddUpdatePeriods.Checked = CkValue;

            ckAddUpdateRanks.Checked = CkValue;

            ckAddUpdateTests.Checked = CkValue;

            ckDeleteInstructors.Checked = CkValue;

            ckDeleteMembersInstructos.Checked = CkValue;

            ckDeleteMembers.Checked = CkValue;

            ckDeletePayment.Checked = CkValue;

            ckDeletePeriods.Checked = CkValue;

            ckDeleteRanks.Checked = CkValue;

            ckDeleteTests.Checked = CkValue;

            ckDeleteUsers.Checked = CkValue;

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSelectAll.Checked)
                _CheckedAllPermissiom(true);
            else
                _CheckedAllPermissiom(false);
        }

    }
}
