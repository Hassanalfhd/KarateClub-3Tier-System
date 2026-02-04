using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartateClubConApp_PersLayer.Users
{
    public partial class frmAccessDenied : Form
    {
        public frmAccessDenied()
        {
            InitializeComponent();
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
