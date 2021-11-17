using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaCafe.Data
{
    public enum SiparisDurum
    {
        Aktif, Odendi, Iptal
    }
    public class SiparisDetay
    {
        public string UrunAd { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal Tutar()
        {
            return Adet * BirimFiyat;
        }
        public string TutarTl { get { return $"{Tutar():n2}₺"; } }


    }
}
