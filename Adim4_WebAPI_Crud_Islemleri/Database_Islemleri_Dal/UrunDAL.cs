using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Islemleri_Dal
{
    public class UrunDAL    //DAL => Data Access Layer'ın kısaltmasıdır.
    {
        MvcOnlineTicariOtomasyonEntities1 db = new MvcOnlineTicariOtomasyonEntities1();


        public IEnumerable<Uruns> TumUrunleriGetir()
        {
            return db.Uruns;
        }


        public Uruns UrunDetayi(int id)
        {
            return db.Uruns.Find(id);
        }



        public Uruns UrunEkle(Uruns urun)
        {
            db.Uruns.Add(urun);
            db.SaveChanges();
            return urun;
        }



        public Uruns UrunuGuncelle(int id, Uruns urun)
        {
            db.Entry(urun).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return urun;
        }



        public void UrunuSil(int id)
        {
            db.Uruns.Remove(db.Uruns.Find(id));
            db.SaveChanges();
        }
    }
}
