using System;
using System.Windows.Forms;

namespace GlosarioCorreos
{
    public partial class frmIni : Form
    {
        public frmIni()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmExtractor frm = new frmExtractor();

            frm.Show();
            this.Hide();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();

            frm.Show();
            this.Hide();
        }

        private void frmIni_Load(object sender, EventArgs e)
        {
        }
    }
}