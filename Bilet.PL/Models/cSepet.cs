using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bilet.PL.Models
{
    public class cSepet
    {
        public int KoltukNo { get; set; }
        public decimal fiyat { get; set; }
        public string KoltukTuru { get; set; }

        public static List<cSepet> SepetAl()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["sepet"] == null)
                context.Session["sepet"] = new List<cSepet>();

            return (List<cSepet>)context.Session["sepet"];
        }
        public void SepeteEkle(List<cSepet> sepet, cSepet siparis)
        {
            if (sepet.Any(x => x.KoltukNo == siparis.KoltukNo))
            {
                //ürün daha önceden sepete atılmışsa...
                foreach (cSepet item in sepet)
                {
                    if (item.KoltukNo == siparis.KoltukNo)
                    {

                    }
                }
            }
            else
            {
                //ürün ilk defa sepete atılıyorsa...
                sepet.Add(siparis);
            }
            HttpContext.Current.Session["sepet"] = sepet;
            HttpContext.Current.Session["toplamadet"] = ToplamAdet(sepet);
            HttpContext.Current.Session["toplamtutar"] = ToplamTutar(sepet);
        }
        public void SepettenSil(List<cSepet> sepet, cSepet siparis)
        {
            sepet.Remove(siparis);
            HttpContext.Current.Session["sepet"] = sepet;
            HttpContext.Current.Session["toplamadet"] = ToplamAdet(sepet);
            HttpContext.Current.Session["toplamtutar"] = ToplamTutar(sepet);
        }
        public int ToplamAdet(List<cSepet> sepet)
        {
            return sepet.Count();
        }
        public decimal ToplamTutar(List<cSepet> sepet)
        {
            decimal TopTutar = 0;
            foreach (cSepet koltuk in sepet)
            {
                TopTutar += koltuk.fiyat;
            }
            return TopTutar;
        }
    }
}