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
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
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

        private void _RefrshUsersList()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            pnlContnaire.BackColor = Color.White;
        }

        private void frmMemberList_Load(object sender, EventArgs e)
        {
            _RefrshUsersList();
            cbSearch.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new Users.frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefrshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_DeleteAccessDenied())
                return;
            if (MessageBox.Show("Are you Sure you want to Delete This Instructor?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Thie Instructor Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshUsersList();
                }
            }
        }

        private void _GetUserInfoByInstructorID(string UserID)
        {
            if(string.IsNullOrEmpty(UserID))
            {
                return;
            }

            DataTable dt = clsUser.GetAllUsers();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "UserID = " + UserID;
                dgvUsers.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetUserInfoByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            DataTable dt = clsUser.GetAllUsers();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "Name Like '%' + '" + Name + "' + '%'";
                dgvUsers.DataSource = dv;

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
                _RefrshUsersList();


            switch (cbSearch.Text)
            {
                case "UserID":
                    _GetUserInfoByInstructorID(txtSearch.Text);
                    break;
                case "Name":
                    _GetUserInfoByName(txtSearch.Text);
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            Form frm = new Users.frmAddEditUser(-1);
            pnlContnaire.BackColor = Color.FromArgb(0,38,37,39);
            frm.ShowDialog();
            _RefrshUsersList();
            
        }


    }
}
