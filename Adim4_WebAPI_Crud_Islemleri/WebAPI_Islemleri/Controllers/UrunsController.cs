using Database_Islemleri_Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Islemleri.Controllers
{
    public class UrunsController : ApiController
    {
        UrunDAL urunDAL = new UrunDAL();

        public IEnumerable<Uruns> Get()
        {
            return urunDAL.TumUrunleriGetir();
        }


        public Uruns Get(int id)
        {
            return urunDAL.UrunDetayi(id);
        }


        public Uruns Post(Uruns urun)
        {
            return urunDAL.UrunEkle(urun);
        }


        public Uruns Put(int id, Uruns urun)
        {
            return urunDAL.UrunuGuncelle(id, urun);
        }


        public void Delete(int id)
        {
            urunDAL.UrunuSil(id);
        }
    }
}
