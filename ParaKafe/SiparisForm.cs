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
    public partial class SiparisForm : Form
    {
        private readonly Siparis siparis;
        private readonly KafeVeri db;
        private readonly BindingList<SiparisDetay> blDetaylar;

        public SiparisForm(Siparis siparis, KafeVeri db)
        {
            this.siparis = siparis;
            this.db = db;
            blDetaylar = new BindingList<SiparisDetay>(siparis.SiparisDetaylar);
            blDetaylar.ListChanged += BlDetaylar_ListChanged;
            InitializeComponent();
            dgvSiparisDetaylar.AutoGenerateColumns = false;
            dgvSiparisDetaylar.DataSource = blDetaylar;
            UruleriListele();
            MasaNoyuGuncelle();
            OdemeTutariGuncelle();
        }

        private void BlDetaylar_ListChanged(object sender, ListChangedEventArgs e)
        {
            OdemeTutariGuncelle();
        }

        private void OdemeTutariGuncelle()
        {
            lblOdemeTutari.Text = siparis.ToplamTutarTl;
        }

        private void MasaNoyuGuncelle()
        {
            Text = $"Masa {siparis.MasaNo}";
            lblMasaNo.Text = siparis.MasaNo.ToString();
        }

        private void UruleriListele()
        {
            cboUrun.DataSource = db.Urunler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var sd = new SiparisDetay() ;
            Urun urun = (Urun)cboUrun.SelectedItem;
            sd.UrunAd = urun.UrunAd;
            sd.BirimFiyat = urun.BirimFiyat;
            sd.Adet = (int)nudAdet.Value;
            blDetaylar.Add(sd);
            
        }

        private void btnAnasayfayaDon_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSiparisIptal_Click(object sender, EventArgs e)
        {
            SiparisiKapat(SiparisDurum.Iptal, 0);           
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            SiparisiKapat(SiparisDurum.Odendi, siparis.OdenenTutar);
        }
        private void SiparisiKapat(SiparisDurum durum, decimal odenentutar)
        {
            siparis.KapanisZamani = DateTime.Now;
            siparis.Durum = durum;
            siparis.OdenenTutar = odenentutar;
            db.AktifSiparisler.Remove(siparis);
            db.GecmisSiparisler.Add(siparis);
            Close();
        }
    }
}
