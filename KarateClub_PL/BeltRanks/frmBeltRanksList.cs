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

namespace KartateClubConApp_PersLayer.BeltRanks
{
    public partial class frmBeltRanksList : Form
    {
        public frmBeltRanksList()
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

        private void _RefrshBeltRankList()
        {
            dgvBeltRanks.DataSource = clsBeltRank.GetAllBeltRanks();
            pnlContnaire.BackColor = Color.White;
        
        }


        private void frmMemberList_Load(object sender, EventArgs e)
        {
            _RefrshBeltRankList();
            cbSearch.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            
            Form frm = new BeltRanks.frmAddEditBeltRank((int)dgvBeltRanks.CurrentRow.Cells[0].Value);
               frm.ShowDialog();
            _RefrshBeltRankList();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;

            if (MessageBox.Show("Are you Sure you want to Delete This BeltRank?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsBeltRank.DeleteRank((int)dgvBeltRanks.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Thie BeltRank Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshBeltRankList();
                }
            }
        }

        private void _GetBeltRankInfoByBeltRankID(string BeltRankID)
        {
            if (string.IsNullOrEmpty(BeltRankID))
            {
                return;
            }

            DataTable dt = clsBeltRank.GetAllBeltRanks();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "RankID = " + BeltRankID;
                dgvBeltRanks.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }


        private void _GetBeltRankInfoByBeltRankName(string RankName)
        {
            if (string.IsNullOrEmpty(RankName))
            {
                return;
            }

            DataTable dt = clsBeltRank.GetAllBeltRanks();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "RankName Like '%'+'" + RankName + "' + '%'";
                dgvBeltRanks.DataSource = dv;

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
                _RefrshBeltRankList();


            switch (cbSearch.Text)
            {
                case "RankID":
                    _GetBeltRankInfoByBeltRankID(txtSearch.Text);
                    break;
                case "RankName":
                    _GetBeltRankInfoByBeltRankName(txtSearch.Text);
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


        private void btnAddBeltRank_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            Form frm = new BeltRanks.frmAddEditBeltRank(-1);
            pnlContnaire.BackColor = Color.FromArgb(0, 38, 33, 37);
            frm.ShowDialog();
            _RefrshBeltRankList();
        }


    }
}
