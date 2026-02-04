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
    public partial class frmPermissions : Form
    {
        public int _NumPermission { set; get; }
        public int _UserID { set; get; }
        //private enum enMode{AddMode = 0, UpdateMode = 1}
        //private enMode _Mode;
        
        public frmPermissions(int NumberPermission, int UserID)
        {
            InitializeComponent();

            //this._UserID = UserID;
            // NumPermission = this._NumPermission;

            this._NumPermission = NumberPermission ;

            this._UserID = UserID;
                
        }


     
        private int _GetPermission()
        {
            int NumPermission = 0;

            if (ckAllPermissions.Checked)
            {
                return (int)clsUser.enPermissinos.pAll;
            }


            if (ckMembers.Checked)
                NumPermission += (int)clsUser.enPermissinos.pMembers;

         
            if (ckInstuctors.Checked)
                NumPermission += (int)clsUser.enPermissinos.pInstructors;

            if (ckUsers.Checked)
                NumPermission += (int)clsUser.enPermissinos.pUsers;

            if (ckMemberIntructors.Checked)
                NumPermission += (int)clsUser.enPermissinos.pMemberInstructors;

            if (ckBeltRanks.Checked)
                NumPermission += (int)clsUser.enPermissinos.pRanks;

            if (ckBeltTests.Checked)
                NumPermission += (int)clsUser.enPermissinos.pTests;

            if (ckPeriods.Checked)
                NumPermission += (int)clsUser.enPermissinos.pPeriods;

            if (ckPayment.Checked)
                NumPermission += (int)clsUser.enPermissinos.pPayment;
            
          

            return NumPermission;

        }

        private bool IsPermission(int PermissionNo, clsUser.enPermissinos UserPermissinos)
        {
            return ((PermissionNo & (int)UserPermissinos) == (int)UserPermissinos);
        }

        private void _SetPermissionToForm()
        {
            
                clsUser User = clsUser.Find(_UserID);

                if (User == null)
                    return;

                int PermissionNo = User.Permission;

            if (IsPermission(PermissionNo, clsUser.enPermissinos.pAll))
            {
                ckAllPermissions.Checked = true;
                return;
            }

              if (IsPermission(PermissionNo, clsUser.enPermissinos.pUsers))
                  ckUsers.Checked = true;

              if (IsPermission(PermissionNo, clsUser.enPermissinos.pMembers))
                    ckMembers.Checked = true;

              if (IsPermission(PermissionNo, clsUser.enPermissinos.pInstructors))
                  ckInstuctors.Checked = true;
                
              if (IsPermission(PermissionNo, clsUser.enPermissinos.pRanks))
                  ckBeltRanks.Checked = true;
            

              if (IsPermission(PermissionNo, clsUser.enPermissinos.pTests))
                  ckBeltTests.Checked = true;


              if (IsPermission(PermissionNo,clsUser.enPermissinos.pPayment))
                  ckPayment.Checked = true;

              if (IsPermission(PermissionNo, clsUser.enPermissinos.pPeriods))
                  ckPeriods.Checked = true;

              if (IsPermission(PermissionNo, clsUser.enPermissinos.pMemberInstructors))
                  ckMemberIntructors.Checked = true;
                

        }


        private void btnCloes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblShowAddvancesPermission_Click(object sender, EventArgs e)
        {
            _OpenAddvancesPermission();
        }

        private void _OpenAddvancesPermission()
        {
            Form frm = new Users.frmPermissionTo(this._NumPermission);
            pnlContaner.BackColor = Color.FromArgb(0, 38, 33, 37);

            frm.ShowDialog();

            pnlContaner.BackColor = Color.White;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You suer You Want To Save This Setting?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (ckAllPermissions.Checked)
                {
                    this._NumPermission = (int)clsUser.enPermissinos.pAll;
                }
                else
                {

                    _OpenAddvancesPermission();

                    this._NumPermission += _GetPermission();
                   

                    
                }

                var frmAddUser = Application.OpenForms["frmAddEditUser"] as frmAddEditUser;
                frmAddUser.Permission = this._NumPermission;
                MessageBox.Show("The Addvances Setting Svaed Succssfuly!", "Save");
                this.Close();
            }
        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            _SetPermissionToForm();
        }

     
   

      
      

    }
}
