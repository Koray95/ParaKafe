using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaCafe.Data
{
    public class Siparis
    {
        public int MasaNo { get; set; }
        public SiparisDurum Durum { get; set; }
        public decimal OdenenTutar { get; set; }
        public DateTime? AcilisZamani { get; set; } = DateTime.Now;//default değer 
        public DateTime? KapanisZamani { get; set; }
        public List<SiparisDetay> SiparisDetaylar { get; set; } = new List<SiparisDetay>(); // default değer
        public string ToplamTutarTl { get { return $"{ToplamTutar():n2}₺"; } }
        public decimal ToplamTutar()
        {
            return SiparisDetaylar.Sum(x=>x.Tutar());
        }
      
    }
}
