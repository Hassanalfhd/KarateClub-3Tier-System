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
    public partial class frmMemberInstructorsList : Form
    {
        public frmMemberInstructorsList()
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

        private void _RefrshMemberInstructorList()
        {
            dgvMemberInstructor.DataSource = clsMemberInstructor.GetAllMemberInstructor();
            pnlContnaire.BackColor = Color.White;
        }

        private void frmMemberList_Load(object sender, EventArgs e)
        {
            _RefrshMemberInstructorList();
            cbSearch.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new MemberInstructors.frmAddEditMemberInstructors((int)dgvMemberInstructor.CurrentRow.Cells[0].Value, (int)dgvMemberInstructor.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefrshMemberInstructorList();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;

            if (MessageBox.Show("Are you Sure you want to Delete This MemberInsttuctor?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsMemberInstructor.DeleteMemberInstructor((int)dgvMemberInstructor.CurrentRow.Cells[0].Value, (int)dgvMemberInstructor.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("Thie MemberInsttuctor Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshMemberInstructorList();
                }
            }
        }


        private void _GetMemberInsttuctorInfoByMemberID(string MemberID)
        {
            if(string.IsNullOrEmpty(MemberID))
            {
                return;
            }

            DataTable dt = clsMemberInstructor.GetAllMemberInstructor();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "MemberID = " + MemberID;
                dgvMemberInstructor.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }


        private void _GetMemberInsttuctorInfoByInstructorID(string InsttuctorID)
        {
            if (string.IsNullOrEmpty(InsttuctorID))
            {
                return;
            }

            DataTable dt = clsMemberInstructor.GetAllMemberInstructor();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "InstructorID = " + InsttuctorID;
                dgvMemberInstructor.DataSource = dv;

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
                _RefrshMemberInstructorList();


            switch (cbSearch.Text)
            {
                case "MemberID":
                    _GetMemberInsttuctorInfoByMemberID(txtSearch.Text);
                    break;
                case "InstructorID":
                    _GetMemberInsttuctorInfoByInstructorID(txtSearch.Text);
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




        private void btnAddMemberInstructor_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new MemberInstructors.frmAddEditMemberInstructors(-1, -1);
            pnlContnaire.BackColor = Color.FromArgb(0,38, 33, 37);
            frm.ShowDialog();

            _RefrshMemberInstructorList();
        }


    }
}
