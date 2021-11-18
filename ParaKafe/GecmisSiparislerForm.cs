using ParaCafe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParaKafe
{
    public partial class GecmisSiparislerForm : Form
    {
        private readonly KafeVeri db;
        public GecmisSiparislerForm(KafeVeri db )
        {
            this.db = db;
            InitializeComponent();
            dgvSiprarisler.DataSource = db.GecmisSiparisler;
        }

        private void dgvSiprarisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiprarisler.SelectedRows.Count==0)
            {
                dgvSiparisDetaylar.DataSource = null;
                return;
            }
            Siparis siparis = (Siparis)dgvSiprarisler.SelectedRows[0].DataBoundItem;
            dgvSiparisDetaylar.DataSource = siparis.SiparisDetaylar;
        }
    }
}
