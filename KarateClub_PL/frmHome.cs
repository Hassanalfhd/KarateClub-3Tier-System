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

namespace KartateClubConApp_PersLayer
{
    public partial class frmHome : Form
    {

        clsUser _User;
        public frmHome(string UserName, string Password)
        {
            InitializeComponent();
            _User = clsUser.Find(UserName, Password);
        }

        private Form ActiveForm = null;
        private void _FilepnlContaner(Form ChildForm)
        {
            if(ActiveForm != null)
                ActiveForm.Close();

            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            pnlContnaire.Controls.Add(ChildForm);
            pnlContnaire.Tag = ChildForm;

            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            
            if (_User == null)
                this.Close();

            if (_User.Image != "")
                picbUserLogin.Load(_User.Image);
            
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pMembers))
            {
                ShowAccessDeniedForm();
                return;
            }
            
            Form frm = new Members.frmMemberList();

            _FilepnlContaner(frm);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
             Application.OpenForms[0].Show();
            this.Close();
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pInstructors))
            {
                ShowAccessDeniedForm();
                return;
            }
            
            Form frm = new Instructors.frmInstructorsList();

            _FilepnlContaner(frm);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pUsers))
            {
                ShowAccessDeniedForm();
                return;
            }
            
            Form frm = new Users.frmUsersList();

            _FilepnlContaner(frm);
        }

        private void btnMemberInstructors_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pMemberInstructors))
            {
                ShowAccessDeniedForm();
                return;
            }
            
            Form frm = new MemberInstructors.frmMemberInstructorsList();

            _FilepnlContaner(frm);
        }

        private void btnBeltRanks_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pRanks))
            {
                ShowAccessDeniedForm();
                return;
            }
            
            Form frm = new BeltRanks.frmBeltRanksList();

            _FilepnlContaner(frm);
        }

        public void ShowAccessDeniedForm()
        {
            Form frm = new Users.frmAccessDenied();
            frm.ShowDialog();
        }


        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pPayment))
            {
                ShowAccessDeniedForm();
                return;
            }

            Form frm = new Payments.frmPaymentsList();

            _FilepnlContaner(frm);
        }

        private void btnSubscriptionPeriods_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pPeriods))
            {
                ShowAccessDeniedForm();
                return;
            }
            Form frm = new SubscriptionPeriods.frmPeriodMain();

            _FilepnlContaner(frm);
        }

        private void btnBeltTests_Click(object sender, EventArgs e)
        {
            if (!IsCheckAcsessPermisionRight(clsUser.enPermissinos.pTests))
            {
                ShowAccessDeniedForm();
                return;
            }
            Form frm = new BeltTests.frmBeltTestsList();

            _FilepnlContaner(frm);
        }


        public bool IsCheckAcsessPermisionRight(clsUser.enPermissinos Permissinos)
        {

            if (_User.ChackAccessPermissinos(Permissinos))
            {
                return true;
            }

            return false;
        }



    }
}
