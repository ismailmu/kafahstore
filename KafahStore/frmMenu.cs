using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafahStore
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnBarang_Click(object sender, EventArgs e)
        {
            frmBarang frmB = new frmBarang();
            frmB.ShowDialog(this);
        }

        private void btnPenjualan_Click(object sender, EventArgs e)
        {
            frmPenjualan frmP = new frmPenjualan();
            frmP.ShowDialog(this);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
