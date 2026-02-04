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

namespace KartateClubConApp_PersLayer.Login
{
    public partial class frmLogin : Form
    {
        public int FailedTiesNumber = 3;
       

        public frmLogin()
        {
            InitializeComponent();
        }

        private void OpenfrmHome(string UserName, string Password)
        {
            this.Hide();
            Form frm = new frmHome(UserName, Password);
            //frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

        }

        private void CleartxtBox()
        {
            txtPassword.Clear();
            txtUserName.Clear();
        }

        private bool IsRightUserNameAndPassword(string UserName, string Password)
        {
            return clsUser.IsUserExiste(UserName, Password);
        }


        private void CheckedLogin()
        {
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;

            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please, Enter Value to Filed!");
                return;
            }



            if (!IsRightUserNameAndPassword(UserName, Password))
            {
                FailedTiesNumber--;
                lblFailedTries.Text = "The Email Or Password Is Failed.\nYou have [" + (FailedTiesNumber) + "] Try(ies).";
                CleartxtBox();
                if (FailedTiesNumber <= 0)
                {
                    MessageBox.Show("You Tried a Lot, Then  For Secrety We Close The System ", "Confier", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                txtUserName.Focus();
                return;
            }


            OpenfrmHome(UserName, Password);
            CleartxtBox();

            
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (ckShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckedLogin();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
