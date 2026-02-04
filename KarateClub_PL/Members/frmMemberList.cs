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
    public partial class frmMemberList : Form
    {
        public frmMemberList()
        {
            InitializeComponent();
            _RefrshMemberList();
        }

        private Form ActiveForm = null;
        private void _FilepnlContaner(Form ChildForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();

            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            pnlContnaire.Controls.Add(ChildForm);
            pnlContnaire.Tag = ChildForm;

            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void _RefrshMemberList()
        {
            dgvMembers.DataSource = clsMember.GetAllMembers();
            pnlContnaire.BackColor = Color.White;
        
        }

        private void frmMemberList_Load(object sender, EventArgs e)
        {
            _RefrshMemberList();
            cbSearch.SelectedIndex = 0;
        }

   

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            Form frm = new Members.frmAddEditMember((int)dgvMembers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefrshMemberList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;
            if (MessageBox.Show("Are you Sure you want to Delete This Member?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsMember.DeleteMember((int)dgvMembers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Thie Member Deleted","Confirem", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _RefrshMemberList();
                }
            }
        }

        private void _GetMemberInfoByMemberID(string MemberID)
        {
            if(string.IsNullOrEmpty(MemberID))
            {
                return;
            }

            DataTable dt = clsMember.GetAllMembers();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "MemberID = " + MemberID;
                dgvMembers.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetMemberInfoByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            DataTable dt = clsMember.GetAllMembers();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "Name Like '%'+'" + Name + "'+'%'";
                dgvMembers.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetMemberInfoByLastBeltRanke(string LastBeltRanke)
        {
            if (string.IsNullOrEmpty(LastBeltRanke))
            {
                return;
            }

            DataTable dt = clsMember.GetAllMembers();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "LastBeltRank = " + LastBeltRanke ;
                dgvMembers.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetMemberInfoByIsActive(string IsActive)
        {
            if (string.IsNullOrEmpty(IsActive))
            {
                return;
            }

            DataTable dt = clsMember.GetAllMembers();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "IsActive = " + IsActive;
                dgvMembers.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                _RefrshMemberList();


            switch (cbSearch.Text)
            {
                case "MemberID":
                    _GetMemberInfoByMemberID(txtSearch.Text);
                    break;
                case "Name":
                    _GetMemberInfoByName(txtSearch.Text);
                    break;
                case "Last Belt Rank":
                    _GetMemberInfoByLastBeltRanke(txtSearch.Text);
                    break;
                case "IsActive":
                    _GetMemberInfoByIsActive(txtSearch.Text);
                    break;
            }

        }


        private bool _AddEditAccessDenied()
        {
            var frmHome = Application.OpenForms["frmHome"] as frmHome;
            if (!frmHome.IsCheckAcsessPermisionRight(clsUser.enPermissinos.pAddUpdateRanks))
            {
                frmHome.ShowAccessDeniedForm();
                return true;
            }

            return false;

        }

        private bool _DeleteAccessDenied()
        {
            var frmHome = Application.OpenForms["frmHome"] as frmHome;
            if (!frmHome.IsCheckAcsessPermisionRight(clsUser.enPermissinos.pDeleteRanks))
            {
                frmHome.ShowAccessDeniedForm();
                return true;
            }
            return false;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new Members.frmAddEditMember(-1);
            pnlContnaire.BackColor = Color.FromArgb(0, 38, 33, 37);
            frm.ShowDialog();
            _RefrshMemberList();
        }


    }
}
