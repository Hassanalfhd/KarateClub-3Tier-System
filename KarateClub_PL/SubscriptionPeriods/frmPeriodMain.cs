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

namespace KartateClubConApp_PersLayer.SubscriptionPeriods
{
    public partial class frmPeriodMain : Form
    {
        public frmPeriodMain()
        {
            InitializeComponent();
        }

        private void _RefreshPeriodList()
        {
            dgvPeriods.DataSource = clsPeriod.GetAllPeriods();
            pnlContnaire.BackColor = Color.White;
        }

        private void frmPeriodMain_Load(object sender, EventArgs e)
        {
            _RefreshPeriodList();
            cbSearch.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            if (dgvPeriods == null)
                return;
            Form frm = new SubscriptionPeriods.frmAddEditPeriod((int)dgvPeriods.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshPeriodList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;

            if (dgvPeriods == null)
                return;

            if (MessageBox.Show("Are you Sure you want to Delete This Period?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsPeriod.DeletePeriod((int)dgvPeriods.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Thie Period Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeriodList();
                }
            }
        }



        private void _GetPeriodByMemberID(string MemberID)
        {
            
            if (string.IsNullOrEmpty(MemberID))
            {
                return;
            }

            DataTable dt =clsPeriod.GetAllPeriods();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "MemberID = " + MemberID;
                dgvPeriods.DataSource = dv;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }


        private void _GetPeriodInfoByPeriodID(string PeriodID)
        {
            if (string.IsNullOrEmpty(PeriodID))
            {
                return;
            }

            DataTable dt = clsPeriod.GetAllPeriods();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "PeriodID = " + PeriodID;
                dgvPeriods.DataSource = dv;
                
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
                _RefreshPeriodList();


            switch (cbSearch.Text)
            {
                case "MemberID":
                    _GetPeriodByMemberID(txtSearch.Text);
                    break;
                case "PeriodID":
                    _GetPeriodInfoByPeriodID(txtSearch.Text);
                    break;

            }

        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
           
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeriods == null)
                return;

            if (clsPeriod.Find((int)dgvPeriods.CurrentRow.Cells[0].Value).Paid)
            {
                MessageBox.Show("Thie Period Paid?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            clsPeriod Period =clsPeriod.Find((int)dgvPeriods.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you Sure you want to Pay This Period?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                Period.Paid = true;
                if (Period.Save())
                {
                    MessageBox.Show("Thie Period Paid", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeriodList();
                }
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


        private void btnAddPeriod_Click_1(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;

            Form frm = new SubscriptionPeriods.frmAddEditPeriod(-1);
            pnlContnaire.BackColor = Color.FromArgb(0, 38, 33, 37);
            frm.ShowDialog();
            _RefreshPeriodList();
        }

      


    }
}
