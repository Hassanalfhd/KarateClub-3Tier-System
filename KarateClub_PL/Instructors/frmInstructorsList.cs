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

namespace KartateClubConApp_PersLayer.Instructors
{
    public partial class frmInstructorsList : Form
    {
        public frmInstructorsList()
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

        private void _RefrshInstructorList()
        {
            dgvInstructors.DataSource = clsInstructor.GetAllInstructors();
            pnlContnaire.BackColor = Color.White;
        
        }

        private void frmMemberList_Load(object sender, EventArgs e)
        {
            _RefrshInstructorList();
            cbSearch.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            Form frm = new Instructors.frmAddEditInstructor((int)dgvInstructors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefrshInstructorList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;

            if (MessageBox.Show("Are you Sure you want to Delete This Instructor?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsInstructor.DeleteInstructor((int)dgvInstructors.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Thie Instructor Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshInstructorList();
                }
            }
        }

        private void _GetInstructorInfoByInstructorID(string InstructorID)
        {
            if(string.IsNullOrEmpty(InstructorID))
            {
                return;
            }

            DataTable dt = clsInstructor.GetAllInstructors();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "InstructorID = " + InstructorID;
                dgvInstructors.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetInstructorInfoByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            DataTable dt = clsInstructor.GetAllInstructors();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "Name Like '%' + '" + Name + "' +  '%'";
                dgvInstructors.DataSource = dv;

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
                _RefrshInstructorList();


            switch (cbSearch.Text)
            {
                case "InstructorID":
                    _GetInstructorInfoByInstructorID(txtSearch.Text);
                    break;
                case "Name":
                    _GetInstructorInfoByName(txtSearch.Text);
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

  
        private void btnAddInstructor_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            Form frm = new Instructors.frmAddEditInstructor(-1);

            pnlContnaire.BackColor = Color.FromArgb(0, 38, 33, 37);
            frm.ShowDialog();

            _RefrshInstructorList();
        }

      

    }
}
