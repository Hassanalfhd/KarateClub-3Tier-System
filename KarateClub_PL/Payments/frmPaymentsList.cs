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

namespace KartateClubConApp_PersLayer.Payments
{
    public partial class frmPaymentsList : Form
    {
        public frmPaymentsList()
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

        private void _RefrshPaymensList()
        {
            dgvPayment.DataSource =clsPayment.GetAllPaymentRecords();
            pnlContnaire.BackColor = Color.White;
        
        }

        private void frmPaymentList_Load(object sender, EventArgs e)
        {
            _RefrshPaymensList();
            cbSearch.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new Payments.frmAddEditPayments((int)dgvPayment.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefrshPaymensList();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteAccessDenied())
                return;
            if (MessageBox.Show("Are you Sure you want to Delete This Payment?", "Confierm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                if (clsPayment.DeletePaymentRecord((int)dgvPayment.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Payment Deleted", "Confirem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshPaymensList();
                }
            }
        }

        private void _GetPaymentfoByPaymentID(string PaymentID)
        {
            if (string.IsNullOrEmpty(PaymentID))
            {
                return;
            }

            DataTable dt = clsPayment.GetAllPaymentRecords();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "PaymentID = " + PaymentID;
                dgvPayment.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetPaymentfoByMemberID(string MemberID)
        {
            if (string.IsNullOrEmpty(MemberID))
            {
                return;
            }

            DataTable dt = clsPayment.GetAllPaymentRecords();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "MemberID = " + MemberID;
                dgvPayment.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }

        }

        private void _GetBeltRankInfoByPaymentType(string PaymentType)
        {
            if (string.IsNullOrEmpty(PaymentType))
            {
                return;
            }

            DataTable dt = clsPayment.GetAllPaymentRecords();
            DataView dv = dt.DefaultView;


            try
            {
                dv.RowFilter = "PaymentType = " + PaymentType;
                dgvPayment.DataSource = dv;

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
                _RefrshPaymensList();


            switch (cbSearch.Text)
            {
                case "PaymentID":
                    _GetPaymentfoByPaymentID(txtSearch.Text);
                    break;
                case "MemberID":
                    _GetPaymentfoByMemberID(txtSearch.Text);
                    break;
                case "Payment Type":
                    _GetBeltRankInfoByPaymentType(txtSearch.Text);
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


        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (_AddEditAccessDenied())
                return;
            Form frm = new Payments.frmAddEditPayments(-1);
            pnlContnaire.BackColor = Color.FromArgb(0, 38, 33, 37);
            frm.ShowDialog();
            _RefrshPaymensList();
        }


    }
}
