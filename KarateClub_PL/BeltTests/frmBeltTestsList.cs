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
    public partial class frmBeltTestsList : Form
    {
        public frmBeltTestsList()
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

        private void _RefrshBeltTestsList()
        {
            dgvBeltTests.DataSource = clsBeltTest.GetAllBeltTestes();
            pnlContnaire.BackColor = Color.White;
        
        }


        private void frmBeltTestsList_Load(object sender, EventArgs e)
        {
            _RefrshBeltTestsList();
            cbSearch.SelectedIndex = 0;
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_AddEditAccessDenied())
                return; 
            
            Form frm = new BeltTests.frmAddEditBeltTests((int)dgvBeltTests.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefrshBeltTestsList();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;

            if (MessageBox.Show("Are you Sure you want to Delete This BeltTest?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsBeltTest.DeleteBeltTest((int)dgvBeltTests.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Thie BeltTest Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshBeltTestsList();
                }
            }
        }

        private void _GetBeltTestInfoByBeltTestID(string BeltTestID)
        {
            if (string.IsNullOrEmpty(BeltTestID))
            {
                return;
            }

            DataTable dt = clsBeltTest.GetAllBeltTestes();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "TestID = " + BeltTestID;
                dgvBeltTests.DataSource = dv;

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
                _RefrshBeltTestsList();


            switch (cbSearch.Text)
            {
                case "TestID":
                    _GetBeltTestInfoByBeltTestID(txtSearch.Text);
                    break;
            
            }

        }

        private bool _AddEditAccessDenied()
        {
            var frmHome = Application.OpenForms["frmHome"] as frmHome;
            if (!frmHome.IsCheckAcsessPermisionRight(clsUser.enPermissinos.pTests))
            {
                frmHome.ShowAccessDeniedForm();
                return true;
            }

            return false;

        }

        private bool _DeleteAccessDenied()
        {
            var frmHome = Application.OpenForms["frmHome"] as frmHome;
            if (!frmHome.IsCheckAcsessPermisionRight(clsUser.enPermissinos.pDeleteTests))
            {
                frmHome.ShowAccessDeniedForm();
                return true;
            }
            return false;
        }


        private void btnAddBeltRank_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new BeltTests.frmAddEditBeltTests(-1);
            pnlContnaire.BackColor = Color.FromArgb(0, 38, 33, 37);
            frm.ShowDialog();
            _RefrshBeltTestsList();
        }


    }
}
